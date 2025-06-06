use crate::{
    config::config::IPCConfig,
    logger::logger::IPCLogger,
    processor::processor::Processor,
    utils::{
        directory::{create_directory, remove_directory},
        file::{get_files, get_mediasafe_filename},
    },
};

use super::converter::Converter;

pub struct SequenceConverter {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Converter for SequenceConverter {
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
            let _ = remove_directory(&format!("{}/convert_temp", &self.working_dir));
            let _ = create_directory(&format!("{}/convert_temp", &self.working_dir));

            let _ = Processor::new(&logger, &format!("{}/ffmpeg", &self.bin_dir), &{
                let mut args: Vec<String> = Vec::new();
                args.push("-y".to_string());

                args.push("-i".to_string());
                args.push(input_file.clone());

                args.push("-c:v".to_string());
                args.push("libx264".to_string());

                args.push("-an".to_string());

                if !self.cfg.settings.vbr_bitrate.is_empty() {
                    args.push("-b:v".to_string());
                    args.push(self.cfg.settings.vbr_bitrate.clone());
                }

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

                if self.cfg.settings.fps_change_enable
                    && self
                        .cfg
                        .settings
                        .fps_change_framerate
                        .parse::<i32>()
                        .is_ok()
                {
                    args.push("-r".to_string());
                    args.push(self.cfg.settings.fps_change_framerate.clone());
                }

                if self.cfg.settings.trim_enable {
                    if !self.cfg.settings.trim_from_start_enable {
                        args.push("-ss".to_string());
                        args.push(self.cfg.settings.trim_start.clone());
                    }
                    if !self.cfg.settings.trim_to_end_enable {
                        args.push("-to".to_string());
                        args.push(self.cfg.settings.trim_end.clone());
                    }
                }

                if self.cfg.settings.custom_ffmpeg_arguments_enable {
                    for arg in &self.cfg.settings.custom_ffmpeg_arguments {
                        args.push(arg.clone())
                    }
                }

                args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));

                args
            })
            .start();

            let _ = Processor::new(&logger, &format!("{}/ffmpeg", &self.bin_dir), &{
                let mut args: Vec<String> = Vec::new();
                args.push("-y".to_string());

                args.push("-i".to_string());
                args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));

                let filename: String = get_mediasafe_filename(&input_file, false);
                let path: String = format!("{}/convert/{}", &self.working_dir, filename);

                let _ = create_directory(&path);

                args.push(format!("{}/{}_%04d.{}", path, filename, extension));

                args
            })
            .start();
        }
    }
}
