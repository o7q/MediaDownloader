use crate::{
    config::config::IPCConfig, logger::logger::IPCLogger, processor::processor::Processor,
};

use super::downloader::Downloader;

pub struct DefaultDownloader {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Downloader for DefaultDownloader {
    fn new(ipc_config: IPCConfig, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            cfg: ipc_config,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn get_ipc_config(&self) -> IPCConfig {
        self.cfg.clone()
    }

    fn download(&self, logger: IPCLogger) -> String {
        self.init_dir(&self.working_dir);

        let _ = Processor::new(&logger, &format!("{}/yt-dlp", &self.bin_dir), &{
            let mut args: Vec<String> = Vec::new();
            args.push(String::from("--ffmpeg-location"));
            args.push(format!("{}/ffmpeg.exe", &self.bin_dir));

            if self.cfg.settings.custom_ytdlp_arguments_enable {
                for arg in &self.cfg.settings.custom_ytdlp_arguments {
                    args.push(arg.clone())
                }
            }

            args.push(String::from("-o"));
            args.push(format!(
                "{}/download/{}",
                &self.working_dir,
                self.determine_output_name_argument()
            ));
            args.push(self.cfg.input.url.clone());

            args
        })
        .start();

        self.finalize(&self.working_dir)
    }
}
