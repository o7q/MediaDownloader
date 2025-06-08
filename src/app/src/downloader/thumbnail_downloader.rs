use crate::{
    config::config::IPCConfig,
    logger::logger::IPCLogger,
    processor::processor::{ProcessPaths, Processor},
};

use super::downloader::Downloader;

pub struct ThumbnailDownloader {
    cfg: IPCConfig,
    path: ProcessPaths,
}

impl Downloader for ThumbnailDownloader {
    fn new(config: &IPCConfig, paths: &ProcessPaths) -> Self {
        Self {
            cfg: config.clone(),
            path: paths.clone(),
        }
    }

    fn get_config(&self) -> IPCConfig {
        self.cfg.clone()
    }

    fn get_path(&self) -> ProcessPaths {
        self.path.clone()
    }

    fn download(&self, logger: &IPCLogger) {
        self.init_dir(&self.path.work);

        let _ = Processor::new(logger, &format!("{}/yt-dlp", &self.path.bin), &{
            let mut args: Vec<String> = Vec::new();
            args.push("--ffmpeg-location".to_string());
            args.push(format!("{}/ffmpeg.exe", &self.path.bin));
            args.push("--skip-download".to_string());
            args.push("--write-thumbnail".to_string());

            if self.cfg.settings.custom_ytdlp_arguments_enable {
                for arg in &self.cfg.settings.custom_ytdlp_arguments {
                    args.push(arg.clone())
                }
            }

            args.push("-o".to_string());
            args.push(format!(
                "{}/download/{}",
                &self.path.work,
                self.determine_output_name_argument()
            ));
            args.push(self.cfg.input.url.clone());

            args
        })
        .start();

        self.write_lock();
        self.write_name_lock();
    }
}
