use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::{Downloader, IPCDownloadData};
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;
use crate::utils::string::clean_string_vector;

#[tauri::command(async)]
pub fn download(mut download_data: IPCDownloadData, download_type: &str) -> String {
    clean_string_vector(&mut download_data.custom_arguments);

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
