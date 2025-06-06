use crate::{
    config::config::IPCConfig,
    logger::logger::IPCLogger,
    processor::processor::Processor,
    utils::file::{get_files, get_mediasafe_filename},
};

use super::converter::Converter;

pub struct ImageConverter {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Converter for ImageConverter {
    fn new(ipc_config: IPCConfig, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            cfg: ipc_config,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn convert(&self, logger: IPCLogger) {
        self.init_dir(&self.working_dir);

        let extension = match self.cfg.settings.format.as_str() {
            "png" => "png",
            "jpg" => "jpg",
            _ => "",
        };

        for input_file in get_files(&format!("{}/download", &self.working_dir)) {
            let _ = Processor::new(&logger, &format!("{}/ffmpeg", &self.bin_dir), &{
                let mut args: Vec<String> = Vec::new();
                args.push("-y".to_string());

                args.push("-i".to_string());
                args.push(input_file.clone());

                if self.cfg.settings.size_change_enable
                    && self.cfg.settings.size_change_width.parse::<i32>().is_ok()
                    && self.cfg.settings.size_change_height.parse::<i32>().is_ok()
                {
                    args.push("-vf".to_string());
                    args.push(format!(
                        "scale={}:{},setsar=1",
                        self.cfg.settings.size_change_width, self.cfg.settings.size_change_height
                    ));
                }

                if self.cfg.settings.custom_ffmpeg_arguments_enable {
                    for arg in &self.cfg.settings.custom_ffmpeg_arguments {
                        args.push(arg.clone())
                    }
                }

                args.push(format!(
                    "{}/convert/{}.{}",
                    &self.working_dir,
                    get_mediasafe_filename(&input_file, false),
                    extension
                ));

                args
            })
            .start();
        }
    }
}
