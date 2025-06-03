use serde::Deserialize;

use crate::{
    config::{config::IPCConfig, serial::serialize_config},
    utils::{
        directory::{create_directory, remove_directory},
        file::{get_filename, get_files, write_file},
    },
};

#[derive(Deserialize, Clone)]
pub struct IPCDownloadData {
    pub cfg: IPCConfig,
    pub is_playlist: bool,
}

pub trait Downloader {
    fn new(download_data: IPCDownloadData, bin_dir: &str, working_dir: &str) -> Self;

    fn init_dir(&self, working_dir: &str) {
        let _ = remove_directory(&format!("{}/download", working_dir));
        let _ = create_directory(&format!("{}/download", working_dir));
    }

    fn get_download_data(&self) -> IPCDownloadData;

    // returns the name of the downloaded file (without extension) if no forced name is set
    // else, it just returns the forced name
    fn download(&self) -> String;
    fn finalize(&self, working_dir: &str) -> String {
        let forced_name: String = self.get_download_data().cfg.output.name.clone();

        // determine the downloaded file name, if it's a playlist, use the first file
        // this will ultimately be sent back to the frontend
        let filename: String = if forced_name.is_empty() {
            let downloaded_files: Vec<String> = get_files(&format!("{}/download", working_dir));

            if downloaded_files.len() > 0 {
                get_filename(&downloaded_files[0].clone(), false)
            } else {
                String::from("")
            }
        } else {
            forced_name
        };

        // write the lock file if a downloaded file is found
        // this file is used to detect if a re-download is required the next time the user starts a download
        // such as if the user just changes the format, there would be no need to re-download the entire video
        if !filename.is_empty() {
            let _ = write_file(
                "MediaDownloader/_temp/lock.json",
                &serialize_config(&self.get_download_data().cfg),
            );
        }

        filename
    }

    fn determine_output_name_argument(&self) -> String {
        let data: IPCDownloadData = self.get_download_data();

        if data.cfg.output.name.is_empty() || data.is_playlist {
            String::from("%(title)s")
        } else {
            String::from(data.cfg.output.name)
        }
    }
}
