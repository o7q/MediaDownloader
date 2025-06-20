use std::process::{self, Command};
use std::thread;
use std::time::Duration;

use crate::utils::{
    file::{copy_file, delete_file},
    net::download_file_sync,
};

#[cfg(target_os = "windows")]
const MEDIADOWNLOADER_BINARY: &str = "MediaDownloader.exe";
#[cfg(target_os = "windows")]
const MEDIADOWNLOADER_BINARY_TEMP: &str = "MediaDownloader_temp.exe";
#[cfg(target_os = "windows")]
const MEDIADOWNLOADER_UPDATE_URL: &str =
    "https://github.com/o7q/Testing/releases/latest/download/MediaDownloader.exe";

#[cfg(target_os = "linux")]
const MEDIADOWNLOADER_BINARY: &str = "./MediaDownloader_linux";
#[cfg(target_os = "linux")]
const MEDIADOWNLOADER_BINARY_TEMP: &str = "./MediaDownloader_linux_temp";
#[cfg(target_os = "linux")]
const MEDIADOWNLOADER_UPDATE_URL: &str =
    "https://github.com/o7q/Testing/releases/latest/download/MediaDownloader_linux";

pub struct Updater {}

impl Updater {
    pub fn new() -> Self {
        Self {}
    }

    pub fn start(&self) {
        if !self.create_updater() {
            return;
        }

        let _ = Command::new(MEDIADOWNLOADER_BINARY_TEMP)
            .arg("updater-update")
            .spawn();
        process::exit(0);
    }

    fn create_updater(&self) -> bool {
        copy_file(MEDIADOWNLOADER_BINARY, MEDIADOWNLOADER_BINARY_TEMP).is_ok()
    }

    pub fn update(&self) {
        thread::sleep(Duration::from_millis(1000));
        match delete_file(MEDIADOWNLOADER_BINARY) {
            Err(_) => return,
            _ => {}
        }

        let _ = download_file_sync(MEDIADOWNLOADER_UPDATE_URL, MEDIADOWNLOADER_BINARY);

        #[cfg(target_os = "linux")]
        {
            use crate::utils::linux::linux_permit_file;
            linux_permit_file(MEDIADOWNLOADER_BINARY, 0o111);
        }

        let _ = Command::new(MEDIADOWNLOADER_BINARY)
            .arg("updater-cleanup")
            .spawn();

        process::exit(0);
    }

    pub fn cleanup(&self) {
        thread::sleep(Duration::from_millis(1000));
        let _ = delete_file(MEDIADOWNLOADER_BINARY_TEMP);
    }
}
