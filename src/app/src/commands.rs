use tauri::AppHandle;

use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::Downloader;
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;

use crate::converter::audio_converter::AudioConverter;
use crate::converter::converter::Converter;
use crate::converter::gif_converter::GifConverter;
use crate::converter::image_converter::ImageConverter;
use crate::converter::sequence_converter::SequenceConverter;
use crate::converter::video_converter::VideoConverter;

use crate::utils::directory::remove_directory;
use crate::utils::file::read_file;

use crate::config::config::IPCConfig;
use crate::config::serial::deserialize_config;

use crate::logger::logger::IPCLogger;

#[tauri::command(async)]
pub fn download(app: AppHandle, mut ipc_config: IPCConfig) -> String {
    let ipc_logger: IPCLogger = IPCLogger::new(app);

    ipc_config.purify();

    // determine if the download should be skipped or not
    match read_file("MediaDownloader/_temp/lock.json") {
        Ok(contents) => {
            let cfg_lock: IPCConfig = deserialize_config(&contents);

            if cfg_lock.input.url != ipc_config.input.url {
                let _ = remove_directory("MediaDownloader/_temp");
            } else {
                return ipc_config.output.name;
            }
        }
        Err(_) => {
            let _ = remove_directory("MediaDownloader/_temp");
        }
    }

    let bin_dir: &'static str = "MediaDownloader/bin";
    let working_dir: &'static str = "MediaDownloader/_temp";

    match ipc_config.input.download_type.as_str() {
        "thumbnail" => ThumbnailDownloader::new(ipc_config, bin_dir, working_dir).download(ipc_logger),
        "default"   => DefaultDownloader::  new(ipc_config, bin_dir, working_dir).download(ipc_logger),
        _ => String::new(),
    }
}

#[tauri::command(async)]
pub fn convert(app: AppHandle, mut ipc_config: IPCConfig) {
    let ipc_logger: IPCLogger = IPCLogger::new(app);

    ipc_config.purify();

    let bin_dir: &'static str = "MediaDownloader/bin";
    let working_dir: &'static str = "MediaDownloader/_temp";

    match ipc_config.settings.format_type.as_str() {
        "video"    => VideoConverter::   new(ipc_config, bin_dir, working_dir).convert(ipc_logger),
        "audio"    => AudioConverter::   new(ipc_config, bin_dir, working_dir).convert(ipc_logger),
        "gif"      => GifConverter::     new(ipc_config, bin_dir, working_dir).convert(ipc_logger),
        "sequence" => SequenceConverter::new(ipc_config, bin_dir, working_dir).convert(ipc_logger),
        "image"    => ImageConverter::   new(ipc_config, bin_dir, working_dir).convert(ipc_logger),
        _ => {}
    }
}
