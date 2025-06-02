use crate::utils::{
    file::{get_filename, get_files},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct ImageConverter {
    convert_data: IPCConvertData,
}

impl Converter for ImageConverter {
    fn new(convert_data: IPCConvertData) -> Self {
        Self {
            convert_data: convert_data,
        }
    }

    fn convert(&self) {
        self.init();

        let extension = match self.convert_data.format.as_str() {
            "png" => "png",
            "jpg" => "jpg",
            _ => "",
        };

        for input_file in get_files("MediaDownloader/_temp/download") {
            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(input_file.clone());

            if self.convert_data.size_change_enable
                && self.convert_data.size_change_width.parse::<i32>().is_ok()
                && self.convert_data.size_change_height.parse::<i32>().is_ok()
            {
                convert_args.push("-vf".to_string());
                convert_args.push(format!(
                    "scale={}:{},setsar=1",
                    self.convert_data.size_change_width, self.convert_data.size_change_height
                ));
            }

            if self.convert_data.custom_ffmpeg_arguments_enable {
                for arg in &self.convert_data.custom_ffmpeg_arguments {
                    convert_args.push(arg.clone())
                }
            }

            convert_args.push(format!(
                "MediaDownloader/_temp/convert/{}.{}",
                get_filename(&input_file, false),
                extension
            ));

            let _ = start_process("MediaDownloader/bin/ffmpeg", &convert_args);
        }
    }
}
