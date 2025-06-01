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
        let (video_codec, audio_codec, extension) = match self.convert_data.format.as_str() {
            "mp4 (fast)" => ("copy", "copy", "mp4"),
            "mp4" => ("libx264", "aac", "mp4"),
            "mp4 (nvidia)" => ("h264_nvenc", "aac", "mp4"),
            "mp4 (amd)" => ("h264_amf", "aac", "mp4"),
            "webm" => ("libvpx-vp9", "libopus", "webm"),
            "avi" => ("rawvideo", "pcm_s16le", "avi"),
            _ => ("", "", ""),
        };

        for input_file in get_files("MediaDownloader/temp/download") {
            let mut args: Vec<String> = Vec::new();

            args.push("-i".to_string());
            args.push(input_file.clone());

            args.push("-c:v".to_string());
            args.push(video_codec.to_string());

            args.push("-c:a".to_string());
            args.push(audio_codec.to_string());

            if self.convert_data.vbr_change_enable {
                args.push("-b:v".to_string());
                args.push(self.convert_data.vbr_change_bitrate.clone());
            }
            if self.convert_data.abr_change_enable {
                args.push("-b:a".to_string());
                args.push(self.convert_data.abr_change_bitrate.clone());
            }

            if self.convert_data.size_change_enable {
                args.push("-vf".to_string());

                args.push(format!(
                    "\"scale={}:{},setsar=1\"",
                    self.convert_data.size_change_width, self.convert_data.size_change_height
                ));
            }

            if self.convert_data.fps_change_enable {
                args.push("-r".to_string());
                args.push(self.convert_data.fps_change_framerate.clone());
            }

            if self.convert_data.trim_enable {
                if !self.convert_data.trim_start_enable {
                    args.push("-ss".to_string());
                    args.push(self.convert_data.trim_start.clone());
                }
                if !self.convert_data.trim_end_enable {
                    args.push("-to".to_string());
                    args.push(self.convert_data.trim_end.clone());
                }
            }

            for arg in &self.convert_data.custom_ffmpeg_arguments {
                args.push(arg.clone())
            }

            if self.convert_data.custom_ffmpeg_arguments_enable {
                args.push(format!(
                    "MediaDownloader/temp/convert/{}.{}",
                    get_filename(&input_file, false),
                    extension
                ));
            }

            let _ = start_process("MediaDownloader/bin/ffmpeg", &args);
        }
    }
}
