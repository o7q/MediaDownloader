use crate::{config::config::IPCConfig, utils::process::start_process};

use super::downloader::Downloader;

pub struct ThumbnailDownloader {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Downloader for ThumbnailDownloader {
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

    fn download(&self) -> String {
        self.init_dir(&self.working_dir);

        let mut args: Vec<String> = Vec::new();
        args.push("--verbose".to_string());
        args.push("--ffmpeg-location".to_string());
        args.push(format!("{}/ffmpeg.exe", &self.bin_dir));
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
            &self.working_dir,
            self.determine_output_name_argument()
        ));
        args.push(self.cfg.input.url.clone());
        let _ = start_process(&format!("{}/yt-dlp", &self.bin_dir), &args);

        self.finalize(&self.working_dir)
    }
}
