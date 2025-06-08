use crate::{
    config::config::IPCConfig,
    logger::logger::IPCLogger,
    processor::processor::{ProcessPaths, Processor},
    utils::file::{get_files, get_mediasafe_filename},
};

use super::converter::Converter;

pub struct AudioConverter {
    cfg: IPCConfig,
    path: ProcessPaths,
}

impl Converter for AudioConverter {
    fn new(config: &IPCConfig, paths: &ProcessPaths) -> Self {
        Self {
            cfg: config.clone(),
            path: paths.clone(),
        }
    }

    fn convert(&self, logger: &IPCLogger) {
        self.init_dir(&self.path.work);

        let (audio_codec, extension) = match self.cfg.settings.format.as_str() {
            "mp3" => ("libmp3lame", "mp3"),
            "wav" => ("pcm_s16le", "wav"),
            "flac" => ("flac", "flac"),
            "ogg" => ("libvorbis", "ogg"),
            _ => ("", ""),
        };

        for input_file in get_files(&format!("{}/download", &self.path.work)) {
            let _ = Processor::new(logger, &format!("{}ffmpeg", &self.path.bin), &{
                let mut args: Vec<String> = Vec::new();
                args.push("-y".to_string());

                args.push("-i".to_string());
                args.push(input_file.clone());

                args.push("-vn".to_string());

                args.push("-c:a".to_string());
                args.push(audio_codec.to_string());

                if !self.cfg.settings.abr_bitrate.is_empty() {
                    args.push("-b:a".to_string());
                    args.push(self.cfg.settings.abr_bitrate.clone());
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

                args.push(format!(
                    "{}/convert/{}.{}",
                    &self.path.work,
                    get_mediasafe_filename(&input_file, false),
                    extension
                ));

                args
            })
            .start();
        }
    }
}
