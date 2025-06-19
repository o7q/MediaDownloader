use crate::{
    config::download_config::IPCDownloadConfig, logger::logger::IPCLogger,
    media::options::ProcessOptions, processor::processor::Processor,
};

use super::downloader::Downloader;

pub struct DefaultDownloader {
    cfg: IPCDownloadConfig,
    opts: ProcessOptions,
}

impl Downloader for DefaultDownloader {
    fn new(config: &IPCDownloadConfig, options: &ProcessOptions) -> Self {
        Self {
            cfg: config.clone(),
            opts: options.clone(),
        }
    }

    fn get_options(&self) -> ProcessOptions {
        self.opts.clone()
    }

    fn download(&self, logger: &IPCLogger) -> &Self {
        self.init_dir(&self.opts.path_work);

        let _ = Processor::new(logger, &self.opts.bin_ytdlp, &{
            let mut args: Vec<String> = Vec::new();

            args.push("-U".to_string());

            args.push("--ffmpeg-location".to_string());
            args.push(self.opts.bin_ffmpeg.to_string());

            if self.cfg.settings.custom_ytdlp_arguments_enable {
                for arg in &self.cfg.settings.custom_ytdlp_arguments {
                    args.push(arg.clone())
                }
            }

            args.push(String::from("-o"));
            args.push(format!("{}/download/%(title)s", &self.opts.path_work));
            args.push(self.cfg.input.url.clone());

            args
        })
        .start();

        self
    }
}
