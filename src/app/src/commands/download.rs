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

use crate::utils::directory::remove_directory;
use crate::utils::file::{read_file, write_file};
use crate::utils::serial::{deserialize_file_read, serialize_file_write, WriteType};

use crate::logger::logger::IPCLogger;

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
        let download_name: String = step_download(&config, &paths, &logger);

        // write the lock file
        // this file is used to detect if a re-download is required the next time the user starts a download
        // such as if the user just changes the format, there would be no need to re-download the entire video
        serialize_file_write(
            "MediaDownloader/_temp/download_lock.json",
            &config,
            WriteType::Squash,
        );

        let _ = write_file("MediaDownloader/_temp/download_name.txt", &download_name);
    }

    step_convert(&config, &paths, &logger);

    let finalize_name: String = if config.output.name.is_empty() {
        match read_file("MediaDownloader/_temp/download_name.txt") {
            Ok(contents) => contents,
            Err(_) => "Unnamed".to_string(),
        }
    } else {
        config.output.name.clone()
    };

    step_finalize(&config, &finalize_name);
}

fn step_download(config: &IPCDownloadConfig, paths: &ProcessPaths, logger: &IPCLogger) -> String {
    match config.input.download_type.as_str() {
        "thumbnail" => ThumbnailDownloader::new(config, paths)
            .download(logger)
            .get_download_name(),
        "default" => DefaultDownloader::new(config, paths)
            .download(logger)
            .get_download_name(),
        _ => String::new(),
    }
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

fn step_finalize(config: &IPCDownloadConfig, finalize_name: &str) {
    Finalizer::new(config).finalize(finalize_name);
}
