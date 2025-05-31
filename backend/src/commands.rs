use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::{Downloader, IPCDownloadData};
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;

#[tauri::command(async)]
pub fn download(download_data: IPCDownloadData, download_type: &str) -> String {
    match download_type {
        "thumbnail" => {
            let downloader: ThumbnailDownloader = ThumbnailDownloader::new(download_data);
            downloader.download()
        }
        _ => {
            let downloader: DefaultDownloader = DefaultDownloader::new(download_data);
            downloader.download()
        }
    }
}
