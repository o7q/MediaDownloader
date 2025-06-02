use crate::utils::{
    file::{get_filename, get_files},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct VideoConverter {
    convert_data: IPCConvertData,
}

impl Converter for VideoConverter {
    fn new(convert_data: IPCConvertData) -> Self {
        Self {
            convert_data: convert_data,
        }
    }

    fn convert(&self) {
        self.init();

        let (video_codec, audio_codec, extension) = match self.convert_data.format.as_str() {
            "mp4-fast" => ("copy", "copy", "mp4"),
            "mp4" => ("libx264", "aac", "mp4"),
            "mp4-nvidia" => ("h264_nvenc", "aac", "mp4"),
            "mp4-amd" => ("h264_amf", "aac", "mp4"),
            "webm" => ("libvpx-vp9", "libopus", "webm"),
            "avi" => ("rawvideo", "pcm_s16le", "avi"),
            _ => ("", "", ""),
        };

        for input_file in get_files("MediaDownloader/_temp/download") {
            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(input_file.clone());

            convert_args.push("-c:v".to_string());
            convert_args.push(video_codec.to_string());

            convert_args.push("-c:a".to_string());
            convert_args.push(audio_codec.to_string());

            if !self.convert_data.vbr_bitrate.is_empty() {
                convert_args.push("-b:v".to_string());
                convert_args.push(self.convert_data.vbr_bitrate.clone());
            }
            if !self.convert_data.abr_bitrate.is_empty() {
                convert_args.push("-b:a".to_string());
                convert_args.push(self.convert_data.abr_bitrate.clone());
            }

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

            if self.convert_data.fps_change_enable
                && self
                    .convert_data
                    .fps_change_framerate
                    .parse::<i32>()
                    .is_ok()
            {
                convert_args.push("-r".to_string());
                convert_args.push(self.convert_data.fps_change_framerate.clone());
            }

            if self.convert_data.trim_enable {
                if !self.convert_data.trim_start_enable {
                    convert_args.push("-ss".to_string());
                    convert_args.push(self.convert_data.trim_start.clone());
                }
                if !self.convert_data.trim_end_enable {
                    convert_args.push("-to".to_string());
                    convert_args.push(self.convert_data.trim_end.clone());
                }
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
