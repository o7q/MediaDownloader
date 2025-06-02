use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::{Downloader, IPCDownloadData};
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;

use crate::converter::audio_converter::AudioConverter;
use crate::converter::converter::{Converter, IPCConvertData};
use crate::converter::gif_converter::GifConverter;
use crate::converter::image_converter::ImageConverter;
use crate::converter::sequence_converter::SequenceConverter;
use crate::converter::video_converter::VideoConverter;

use crate::utils::file::remove_directory;
use crate::utils::string::clean_string_vector;

#[tauri::command(async)]
pub fn download(mut download_data: IPCDownloadData, download_type: &str) -> String {
    clean_string_vector(&mut download_data.custom_ytdlp_arguments);

    match download_type {
        "thumbnail" => ThumbnailDownloader::new(download_data).download(),
        _ => DefaultDownloader::new(download_data).download(),
    }
}

#[tauri::command(async)]
pub fn convert(mut convert_data: IPCConvertData, convert_type: &str) {
    clean_string_vector(&mut convert_data.custom_ffmpeg_arguments);

    match convert_type {
        "video" => VideoConverter::new(convert_data).convert(),
        "audio" => AudioConverter::new(convert_data).convert(),
        "gif" => GifConverter::new(convert_data).convert(),
        "sequence" => SequenceConverter::new(convert_data).convert(),
        "image" => ImageConverter::new(convert_data).convert(),
        _ => {}
    }
}

#[tauri::command]
pub fn purge_temp() {
    let _ = remove_directory("MediaDownloader/_temp");
}
