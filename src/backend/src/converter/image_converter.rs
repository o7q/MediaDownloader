use crate::utils::{
    file::{get_filename, get_files},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct ImageConverter {
    data: IPCConvertData,
    bin_dir: String,
    working_dir: String,
}

impl Converter for ImageConverter {
    fn new(convert_data: IPCConvertData, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            data: convert_data,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn convert(&self) {
        self.init_dir(&self.working_dir);

        let extension = match self.data.cfg.settings.format.as_str() {
            "png" => "png",
            "jpg" => "jpg",
            _ => "",
        };

        for input_file in get_files(&format!("{}/download", &self.working_dir)) {
            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(input_file.clone());

            if self.data.cfg.settings.size_change_enable
                && self
                    .data
                    .cfg
                    .settings
                    .size_change_width
                    .parse::<i32>()
                    .is_ok()
                && self
                    .data
                    .cfg
                    .settings
                    .size_change_height
                    .parse::<i32>()
                    .is_ok()
            {
                convert_args.push("-vf".to_string());
                convert_args.push(format!(
                    "scale={}:{},setsar=1",
                    self.data.cfg.settings.size_change_width,
                    self.data.cfg.settings.size_change_height
                ));
            }

            if self.data.cfg.settings.custom_ffmpeg_arguments_enable {
                for arg in &self.data.cfg.settings.custom_ffmpeg_arguments {
                    convert_args.push(arg.clone())
                }
            }

            convert_args.push(format!(
                "{}/convert/{}.{}",
                &self.working_dir,
                get_filename(&input_file, false),
                extension
            ));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &convert_args);
        }
    }
}
