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

use crate::finalizer::finalizer::Finalizer;

use crate::processor::processor::ProcessPaths;

use crate::config::download_config::IPCDownloadConfig;

use crate::utils::directory::create_directory;
use crate::utils::directory::directory_exists;
use crate::utils::directory::remove_directory;
use crate::utils::file::read_file;
use crate::utils::serial::deserialize_file_read;

use crate::logger::logger::IPCLogger;
use crate::utils::serial::serialize_file_write_push;
use crate::utils::serial::WriteType;

#[tauri::command]
pub fn get_download_name() -> String {
    match read_file("MediaDownloader/_temp/download_name_lock") {
        Ok(contents) => contents,
        Err(_) => String::new(),
    }
}

#[tauri::command(async)]
pub fn download(app: AppHandle, mut config: IPCDownloadConfig) {
    config.purify();

    let logger: IPCLogger = IPCLogger::new(app);

    #[cfg(target_os = "windows")]
    let paths: ProcessPaths = ProcessPaths {
        bin: "MediaDownloader/bin/".to_string(),
        work: "MediaDownloader/_temp".to_string(),
    };

    #[cfg(not(target_os = "windows"))]
    let paths: ProcessPaths = ProcessPaths {
        bin: "".to_string(),
        work: "MediaDownloader/_temp".to_string(),
    };

    // determine if the download should be skipped or not
    let download_lock: IPCDownloadConfig =
        deserialize_file_read("MediaDownloader/_temp/download_lock.json", false);

    let should_download: bool = config.input.url != download_lock.input.url
        || config.input.download_type != download_lock.input.download_type;

    if should_download {
        let _ = remove_directory("MediaDownloader/_temp");
        step_download(&config, &paths, &logger);
    }

    step_convert(&config, &paths, &logger);
    step_finalize(&config);
}

fn step_download(config: &IPCDownloadConfig, paths: &ProcessPaths, logger: &IPCLogger) {
    match config.input.download_type.as_str() {
        "thumbnail" => ThumbnailDownloader::new(config, paths).download(logger),
        "default" => DefaultDownloader::new(config, paths).download(logger),
        _ => {}
    };
}

fn step_convert(config: &IPCDownloadConfig, paths: &ProcessPaths, logger: &IPCLogger) {
    match config.settings.format_type.as_str() {
        "video" => VideoConverter::new(config, paths).convert(logger),
        "audio" => AudioConverter::new(config, paths).convert(logger),
        "gif" => GifConverter::new(config, paths).convert(logger),
        "sequence" => SequenceConverter::new(config, paths).convert(logger),
        "image" => ImageConverter::new(config, paths).convert(logger),
        _ => {}
    }
}

fn step_finalize(config: &IPCDownloadConfig) {
    if !directory_exists("MediaDownloader/config") {
        let _ = create_directory("MediaDownloader/config");
    }
    serialize_file_write_push(
        "MediaDownloader/config/history.json",
        config,
        WriteType::Compress,
    );

    Finalizer::new(config).finalize();
}
