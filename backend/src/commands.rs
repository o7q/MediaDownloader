use crate::converter::converter::IPCConvertData;
use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::{Downloader, IPCDownloadData};
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;
use crate::utils::string::clean_string_vector;

#[tauri::command(async)]
pub fn download(mut download_data: IPCDownloadData, download_type: &str) -> String {
    clean_string_vector(&mut download_data.custom_ytdlp_arguments);

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

#[tauri::command(async)]
pub fn convert(mut convert_data: IPCConvertData, convert_type: &str) -> String {
    clean_string_vector(&mut convert_data.custom_ffmpeg_arguments);

    match convert_type {
        "video" => {}
        "audio" => {}
        "gif" => {}
        "sequence" => {}
        "image" => {}
        _ => {}
    }

    String::new()
}
