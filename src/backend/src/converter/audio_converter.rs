use crate::utils::{
    file::{get_filename, get_files},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct AudioConverter {
    convert_data: IPCConvertData,
}

impl Converter for AudioConverter {
    fn new(convert_data: IPCConvertData) -> Self {
        Self {
            convert_data: convert_data,
        }
    }

    fn convert(&self) -> bool {
        self.init();

        let (audio_codec, extension) = match self.convert_data.format.as_str() {
            "mp3" => ("libmp3lame", "mp3"),
            "wav" => ("pcm_s16le", "wav"),
            "flac" => ("flac", "flac"),
            "ogg" => ("libvorbis", "ogg"),
            _ => ("", ""),
        };

        for input_file in get_files("MediaDownloader/temp/download") {
            let mut args: Vec<String> = Vec::new();

            args.push("-i".to_string());
            args.push(input_file.clone());

            args.push("-vn".to_string());

            args.push("-c:a".to_string());
            args.push(audio_codec.to_string());

            if !self.convert_data.abr_bitrate.is_empty() {
                args.push("-b:a".to_string());
                args.push(self.convert_data.abr_bitrate.clone());
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

            if self.convert_data.custom_ffmpeg_arguments_enable {
                for arg in &self.convert_data.custom_ffmpeg_arguments {
                    args.push(arg.clone())
                }
            }

            args.push(format!(
                "MediaDownloader/temp/convert/{}.{}",
                get_filename(&input_file, false),
                extension
            ));

            let _ = start_process("MediaDownloader/bin/ffmpeg", &args);
        }

        true
    }
}
