use crate::utils::{
    file::{create_directory, get_filename, get_files, remove_directory},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct GifConverter {
    convert_data: IPCConvertData,
}

impl Converter for GifConverter {
    fn new(convert_data: IPCConvertData) -> Self {
        Self {
            convert_data: convert_data,
        }
    }

    fn convert(&self) {
        self.init();

        for input_file in get_files("MediaDownloader/_temp/download") {
            let _ = remove_directory("MediaDownloader/_temp/convert_temp");
            let _ = create_directory("MediaDownloader/_temp/convert_temp");

            let mut pre_convert_args: Vec<String> = Vec::new();
            pre_convert_args.push("-loglevel".to_string());
            pre_convert_args.push("verbose".to_string());
            pre_convert_args.push("-y".to_string());

            pre_convert_args.push("-i".to_string());
            pre_convert_args.push(input_file.clone());

            pre_convert_args.push("-c:v".to_string());
            pre_convert_args.push("libx264".to_string());

            pre_convert_args.push("-an".to_string());

            if !self.convert_data.vbr_bitrate.is_empty() {
                pre_convert_args.push("-b:v".to_string());
                pre_convert_args.push(self.convert_data.vbr_bitrate.clone());
            }

            if self.convert_data.size_change_enable
                && self.convert_data.size_change_width.parse::<i32>().is_ok()
                && self.convert_data.size_change_height.parse::<i32>().is_ok()
            {
                pre_convert_args.push("-vf".to_string());
                pre_convert_args.push(format!(
                    "scale={}:{},setsar=1",
                    self.convert_data.size_change_width, self.convert_data.size_change_height
                ));
            }

            if self.convert_data.fps_change_enable
                && self
                    .convert_data
                    .fps_change_framerate
                    .parse::<i32>()
                    .is_ok()
            {
                pre_convert_args.push("-r".to_string());
                pre_convert_args.push(self.convert_data.fps_change_framerate.clone());
            }

            if self.convert_data.trim_enable {
                if !self.convert_data.trim_start_enable {
                    pre_convert_args.push("-ss".to_string());
                    pre_convert_args.push(self.convert_data.trim_start.clone());
                }
                if !self.convert_data.trim_end_enable {
                    pre_convert_args.push("-to".to_string());
                    pre_convert_args.push(self.convert_data.trim_end.clone());
                }
            }

            pre_convert_args.push("MediaDownloader/_temp/convert_temp/video.mp4".to_string());

            let _ = start_process("MediaDownloader/bin/ffmpeg", &pre_convert_args);

            let mut palette_args: Vec<String> = Vec::new();
            palette_args.push("-loglevel".to_string());
            palette_args.push("verbose".to_string());
            palette_args.push("-y".to_string());

            palette_args.push("-i".to_string());
            palette_args.push("MediaDownloader/_temp/convert_temp/video.mp4".to_string());

            palette_args.push("-vf".to_string());
            palette_args.push("palettegen".to_string());

            palette_args.push("MediaDownloader/_temp/convert_temp/palette.png".to_string());

            let _ = start_process("MediaDownloader/bin/ffmpeg", &palette_args);

            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push("MediaDownloader/_temp/convert_temp/video.mp4".to_string());

            convert_args.push("-i".to_string());
            convert_args.push("MediaDownloader/_temp/convert_temp/palette.png".to_string());

            convert_args.push("-lavfi".to_string());
            convert_args.push("paletteuse".to_string());

            convert_args.push(format!(
                "MediaDownloader/_temp/convert/{}.gif",
                get_filename(&input_file, false)
            ));

            let _ = start_process("MediaDownloader/bin/ffmpeg", &convert_args);
        }
    }
}
