use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::{Downloader, IPCDownloadData};
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;

use crate::converter::audio_converter::AudioConverter;
use crate::converter::converter::Converter;
use crate::converter::converter::IPCConvertData;
use crate::converter::gif_converter::GifConverter;
use crate::converter::image_converter::ImageConverter;
use crate::converter::sequence_converter::SequenceConverter;
use crate::converter::video_converter::VideoConverter;

use crate::config::config::IPCConfig;
use crate::config::serial::deserialize_config;

use crate::utils::file::{read_file, remove_directory};

#[tauri::command(async)]
pub fn download(mut download_data: IPCDownloadData, download_type: &str) -> String {
    download_data.cfg.purify();

    // determine if the download should be skipped or not
    match read_file("MediaDownloader/_temp/lock.json") {
        Ok(contents) => {
            let cfg_lock: IPCConfig = deserialize_config(&contents);

            if cfg_lock.input.url != download_data.cfg.input.url {
                let _ = remove_directory("MediaDownloader/_temp");
            } else {
                return download_data.cfg.output.name;
            }
        }
        Err(_) => {
            let _ = remove_directory("MediaDownloader/_temp");
        }
    }

    let bin_dir: &'static str = "MediaDownloader/bin";
    let working_dir: &'static str = "MediaDownloader/_temp";

    match download_type {
        "thumbnail" => ThumbnailDownloader::new(download_data, bin_dir, working_dir).download(),
        "default" => DefaultDownloader::new(download_data, bin_dir, working_dir).download(),
        _ => String::new(),
    }
}

#[tauri::command(async)]
pub fn convert(mut convert_data: IPCConvertData, convert_type: &str) {
    convert_data.cfg.purify();

    let bin_dir: &'static str = "MediaDownloader/bin";
    let working_dir: &'static str = "MediaDownloader/_temp";

    match convert_type {
        "video" => VideoConverter::new(convert_data, bin_dir, working_dir).convert(),
        "audio" => AudioConverter::new(convert_data, bin_dir, working_dir).convert(),
        "gif" => GifConverter::new(convert_data, bin_dir, working_dir).convert(),
        "sequence" => SequenceConverter::new(convert_data, bin_dir, working_dir).convert(),
        "image" => ImageConverter::new(convert_data, bin_dir, working_dir).convert(),
        _ => {}
    }
}
