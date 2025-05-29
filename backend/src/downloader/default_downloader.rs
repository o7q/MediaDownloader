use crate::downloader::downloader::Downloader;

use crate::utils::files::create_directory;
use crate::utils::process::start_process;

pub struct DefaultDownloader {
    url: String,
    name: String,
    custom_arguments: Vec<String>,
}

impl Downloader for DefaultDownloader {
    fn new() -> Self {
        Self {
            url: String::new(),
            name: String::new(),
            custom_arguments: Vec::new(),
        }
    }

    fn set_url(&mut self, url: &str) {
        self.url = url.to_string();
    }

    fn set_name(&mut self, name: &str) {
        self.name = name.to_string();
    }

    fn set_custom_arguments(&mut self, raw_custom_arguments: &str) {
        self.custom_arguments = self.decode_raw_arguments(raw_custom_arguments);
    }

    fn get_name(&self) -> String {
        self.name.clone()
    }

    fn download(&self) {
        let _ = create_directory("MediaDownloader/temp/download");
        
        let mut args: Vec<String> = Vec::new();
        args.push(String::from("--verbose"));
        args.push(String::from("--ffmpeg-location"));
        args.push(String::from("MediaDownloader/bin/ffmpeg.exe"));

        for arg in &self.custom_arguments {
            args.push(arg.clone())
        }

        args.push(String::from("-o"));
        args.push(format!(
            "MediaDownloader/temp/download/{}",
            self.determine_output_name()
        ));
        args.push(self.url.clone());

        start_process("MediaDownloader/bin/yt-dlp", &args);
    }
}
