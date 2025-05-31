use crate::downloader::downloader::Downloader;

use super::downloader::IPCDownloadData;

pub struct DefaultDownloader {
    url: String,
    forced_name: String,
    custom_arguments: Vec<String>,
    is_playlist: bool,
}

impl Downloader for DefaultDownloader {
    fn new(download_data: IPCDownloadData) -> Self {
        Self {
            url: download_data.url,
            forced_name: download_data.forced_name,
            custom_arguments: Self::decode_raw_arguments(&download_data.custom_raw_arguments),
            is_playlist: download_data.is_playlist,
        }
    }

    fn set_url(&mut self, url: &str) {
        self.url = url.to_string();
    }

    fn set_forced_name(&mut self, forced_name: &str) {
        self.forced_name = forced_name.to_string();
    }

    fn set_custom_arguments(&mut self, raw_custom_arguments: &str) {
        self.custom_arguments = Self::decode_raw_arguments(raw_custom_arguments);
    }

    fn set_as_playlist(&mut self, playlist: bool) {
        self.is_playlist = playlist;
    }

    fn get_forced_name(&self) -> String {
        self.forced_name.clone()
    }

    fn download(&self) -> String {
        self.init_paths();

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
            self.determine_output_name_argument()
        ));
        args.push(self.url.clone());

        self.run(&args)
    }
}
