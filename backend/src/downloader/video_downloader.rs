use crate::downloader::downloader::Downloader;

use crate::utils::files::create_directory;
use crate::utils::process::start_process;

pub struct VideoDownloader {
    url: String,
    name: String,
}

impl Downloader for VideoDownloader {
    fn new() -> Self {
        Self {
            url: String::new(),
            name: String::new(),
        }
    }

    fn set_url(&mut self, url: &str) {
        self.url = url.to_string();
    }

    fn set_name(&mut self, name: &str) {
        self.name = name.to_string();
    }

    fn get_name(&self) -> String {
        self.name.clone()
    }

    fn download(&self) {
        let _ = create_directory("MediaDownloader/temp/download");

        let output_name: String = self.determine_output_name();

        let args = [
            "--verbose",
            "--ffmpeg-location",
            "MediaDownloader/bin/ffmpeg.exe",
            "-o",
            &format!("MediaDownloader/temp/download/{}", output_name),
            &self.url,
        ];

        start_process("MediaDownloader/bin/yt-dlp", &args);
    }
}
