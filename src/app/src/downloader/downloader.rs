use crate::{
    config::{config::IPCConfig, serial::serialize_config},
    logger::logger::IPCLogger,
    processor::processor::ProcessPaths,
    utils::{
        directory::{create_directory, remove_directory},
        file::{get_files, get_mediasafe_filename, write_file},
    },
};

pub trait Downloader {
    fn new(config: &IPCConfig, paths: &ProcessPaths) -> Self;

    fn init_dir(&self, working_dir: &str) {
        let _ = remove_directory(&format!("{}/download", working_dir));
        let _ = create_directory(&format!("{}/download", working_dir));
    }

    fn get_config(&self) -> IPCConfig;
    fn get_path(&self) -> ProcessPaths;

    // returns the name of the downloaded file (without extension) if no forced name is set
    // else, it just returns the forced name
    fn download(&self, logger: &IPCLogger);

    // write the lock file
    // this file is used to detect if a re-download is required the next time the user starts a download
    // such as if the user just changes the format, there would be no need to re-download the entire video
    fn write_lock(&self) {
        let _ = write_file(
            "MediaDownloader/_temp/download_lock.json",
            &serialize_config(&self.get_config()),
        );
    }

    fn write_name_lock(&self) {
        let config: IPCConfig = self.get_config();
        let path: ProcessPaths = self.get_path();

        let filename: String = if config.output.name.is_empty() {
            let downloaded_files: Vec<String> = get_files(&format!("{}/download", path.work));

            if downloaded_files.len() > 0 {
                get_mediasafe_filename(&downloaded_files[0].clone(), false)
            } else {
                String::from("")
            }
        } else {
            config.output.name
        };

        let _ = write_file("MediaDownloader/_temp/download_name_lock", &filename);
    }

    fn determine_output_name_argument(&self) -> String {
        let config: IPCConfig = self.get_config();

        if config.output.name.is_empty() || config.input.is_playlist {
            String::from("%(title)s")
        } else {
            String::from(config.output.name)
        }
    }
}
