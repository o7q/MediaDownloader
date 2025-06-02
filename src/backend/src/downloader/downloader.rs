use serde::Deserialize;

use crate::utils::{
    file::{create_directory, get_filename, get_files, remove_directory},
    process::start_process,
};

#[derive(Deserialize, Clone)]
pub struct IPCDownloadData {
    pub url: String,
    pub url_is_playlist: bool,

    pub forced_name: String,

    pub custom_ytdlp_arguments_enable: bool,
    pub custom_ytdlp_arguments: Vec<String>,
}

pub trait Downloader {
    fn new(download_data: IPCDownloadData) -> Self;

    fn init(&self) {
        let _ = remove_directory("MediaDownloader/_temp/download");
        let _ = create_directory("MediaDownloader/_temp/download");
    }

    fn get_download_data(&self) -> IPCDownloadData;

    // returns the name of the downloaded file (without extension) if no forced name is set
    // else, it just returns the forced name
    fn download(&self) -> String;
    fn run(&self, args: &Vec<String>) -> String {
        let _ = start_process("MediaDownloader/bin/yt-dlp", args);

        let forced_name: String = self.get_download_data().forced_name.clone();
        if forced_name.is_empty() {
            let downloaded_files: Vec<String> = get_files("MediaDownloader/_temp/download");

            if downloaded_files.len() > 0 {
                get_filename(&downloaded_files[0].clone(), false)
            } else {
                String::from("")
            }
        } else {
            forced_name
        }
    }

    fn determine_output_name_argument(&self) -> String {
        let download_data: IPCDownloadData = self.get_download_data();

        if download_data.forced_name.is_empty() || download_data.url_is_playlist {
            String::from("%(title)s")
        } else {
            String::from(download_data.forced_name)
        }
    }
}
