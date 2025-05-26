use crate::downloaders::downloader::Downloader;
use std::process::Command;

pub struct VideoDownloader {
    url: String,
}

impl Downloader for VideoDownloader {
    fn new() -> Self {
        Self {
            url: String::from(""),
        }
    }

    fn set_url(&mut self, url: &str) {
        self.url = String::from(url)
    }

    fn download(&self) {
        let output = Command::new("bin/yt-dlp")
            .arg("--verbose")
            .arg("--ffmpeg-location")
            .arg("bin/ffmpeg.exe")
            .arg("-o")
            .arg("%(title)s")
            .arg(self.url.clone())
            .output()
            .expect("Failed to execute process");

        if output.status.success() {
            let stdout: std::borrow::Cow<'_, str> = String::from_utf8_lossy(&output.stdout);
            println!("Program output:\n{}", stdout);
        } else {
            let stderr: std::borrow::Cow<'_, str> = String::from_utf8_lossy(&output.stderr);
            eprintln!("Program error:\n{}", stderr);
        }
    }
}
