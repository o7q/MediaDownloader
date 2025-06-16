use crate::{
    config::download_config::IPCDownloadConfig,
    logger::logger::IPCLogger,
    processor::processor::{ProcessPaths, Processor},
};

use super::downloader::Downloader;

pub struct ThumbnailDownloader {
    cfg: IPCDownloadConfig,
    path: ProcessPaths,
}

impl Downloader for ThumbnailDownloader {
    fn new(config: &IPCDownloadConfig, paths: &ProcessPaths) -> Self {
        Self {
            cfg: config.clone(),
            path: paths.clone(),
        }
    }

    fn get_path(&self) -> ProcessPaths {
        self.path.clone()
    }

    fn download(&self, logger: &IPCLogger) -> &Self {
        self.init_dir(&self.path.work);

        let _ = Processor::new(logger, &format!("{}yt-dlp", &self.path.bin), &{
            let mut args: Vec<String> = Vec::new();
            args.push("-U".to_string());
            args.push("--skip-download".to_string());
            args.push("--write-thumbnail".to_string());

            if self.cfg.settings.custom_ytdlp_arguments_enable {
                for arg in &self.cfg.settings.custom_ytdlp_arguments {
                    args.push(arg.clone())
                }
            }

            args.push("-o".to_string());
            args.push(format!(
                "{}/download/%(title)s",
                &self.path.work
            ));
            args.push(self.cfg.input.url.clone());

            args
        })
        .start();

        self
    }
}
