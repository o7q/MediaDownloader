use serde::Deserialize;

use crate::utils::{
    files::{create_directory, get_filename, get_files, remove_directory},
    process::start_process,
};

#[derive(Deserialize)]
pub struct IPCDownloadData {
    pub url: String,
    pub forced_name: String,
    pub custom_raw_arguments: String,
    pub is_playlist: bool,
}

#[allow(dead_code)]
pub trait Downloader {
    fn new(download_data: IPCDownloadData) -> Self;

    fn init_paths(&self) {
        let _ = remove_directory("MediaDownloader/temp");
        let _ = create_directory("MediaDownloader/temp/download");
    }

    fn set_url(&mut self, url: &str);
    fn set_forced_name(&mut self, name: &str);
    fn set_custom_arguments(&mut self, custom_arguments: &str);
    fn set_as_playlist(&mut self, playlist: bool);

    fn get_forced_name(&self) -> String;
    fn is_playlist(&self) -> bool;

    // returns the name of the downloaded file (without extension) if no forced name is set
    fn download(&self) -> String;
    fn run(&self, args: &Vec<String>) -> String {
        let _ = start_process("MediaDownloader/bin/yt-dlp", args);

        let forced_name: String = self.get_forced_name();
        if forced_name.is_empty() {
            let downloaded_files: Vec<String> = get_files("MediaDownloader/temp/download");

            if downloaded_files.len() > 0 {
                get_filename(&downloaded_files[0].clone(), false)
            } else {
                String::from("")
            }
        } else {
            forced_name
        }
    }

    fn decode_raw_arguments(raw: &str) -> Vec<String> {
        if !raw.is_empty() {
            raw.split('\n').map(String::from).collect()
        } else {
            Vec::new()
        }
    }

    fn determine_output_name_argument(&self) -> String {
        if self.get_forced_name().is_empty() || self.is_playlist() {
            String::from("%(title)s")
        } else {
            String::from(self.get_forced_name())
        }
    }
}
