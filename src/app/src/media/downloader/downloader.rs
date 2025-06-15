use crate::{
    config::download_config::IPCDownloadConfig,
    logger::logger::IPCLogger,
    processor::processor::ProcessPaths,
    utils::{
        directory::{create_directory, remove_directory},
        file::{get_files, get_mediasafe_filename},
    },
};

pub trait Downloader {
    fn new(config: &IPCDownloadConfig, paths: &ProcessPaths) -> Self;

    fn init_dir(&self, working_dir: &str) {
        let _ = remove_directory(&format!("{}/download", working_dir));
        let _ = create_directory(&format!("{}/download", working_dir));
    }

    fn get_path(&self) -> ProcessPaths;

    fn download(&self, logger: &IPCLogger) -> &Self;

    // returns the name of the downloaded file
    fn get_download_name(&self) -> String {
        let path: ProcessPaths = self.get_path();

        let downloaded_files: Vec<String> = get_files(&format!("{}/download", path.work));

        if downloaded_files.len() > 0 {
            get_mediasafe_filename(&downloaded_files[0].clone(), false)
        } else {
            "Unnamed".to_string()
        }
    }
}
