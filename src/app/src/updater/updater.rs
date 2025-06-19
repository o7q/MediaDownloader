use std::process::{self, Command};

use std::thread;
use std::time::Duration;

use crate::utils::{
    file::{copy_file, delete_file},
    net::download_file_sync,
};

pub struct Updater {}

impl Updater {
    pub fn new() -> Self {
        Self {}
    }

    pub fn start(&self) {
        if !self.create_updater() {
            return;
        }

        let _ = Command::new("MediaDownloader_temp.exe")
            .arg("updater-update")
            .spawn();
        process::exit(0);
    }

    fn create_updater(&self) -> bool {
        copy_file("media-downloader.exe", "MediaDownloader_temp.exe").is_ok()
    }

    pub fn update(&self) {
        thread::sleep(Duration::from_millis(5000));

        match delete_file("media-downloader.exe") {
            Err(_) => return,
            _ => {}
        }

        let _ = download_file_sync(
            "https://github.com/o7q/MediaDownloader/releases/latest/download/MediaDownloader.exe",
            "media-downloader.exe",
        );

        let _ = Command::new("media-downloader.exe")
            .arg("updater-cleanup")
            .spawn();
        process::exit(0);
    }

    pub fn cleanup(&self) {
        thread::sleep(Duration::from_millis(1000));
        let _ = delete_file("MediaDownloader_temp.exe");
    }
}
