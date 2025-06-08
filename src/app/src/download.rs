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

use crate::utils::directory::remove_directory;
use crate::utils::file::read_file;

use crate::config::config::IPCConfig;
use crate::config::serial::deserialize_config;

use crate::logger::logger::IPCLogger;

#[tauri::command(async)]
pub fn get_download_name() -> String {
    match read_file("MediaDownloader/_temp/download_name_lock") {
        Ok(contents) => contents,
        Err(_) => String::new(),
    }
}

#[tauri::command(async)]
pub fn download(app: AppHandle, mut config: IPCConfig) {
    config.purify();

    let logger: IPCLogger = IPCLogger::new(app);

    #[cfg(not(target_os = "linux"))]
    let paths: ProcessPaths = ProcessPaths {
        bin: "MediaDownloader/bin/".to_string(),
        work: "MediaDownloader/_temp".to_string(),
    };

    #[cfg(target_os = "linux")]
    let paths: ProcessPaths = ProcessPaths {
        bin: "".to_string(),
        work: "MediaDownloader/_temp".to_string(),
    };

    // determine if the download should be skipped or not
    let should_download: bool = match read_file("MediaDownloader/_temp/download_lock.json") {
        Ok(contents) => {
            let config_lock: IPCConfig = deserialize_config(&contents);

            config.input.url != config_lock.input.url
                || config.input.download_type != config_lock.input.download_type
        }
        Err(_) => true,
    };

    if should_download {
        let _ = remove_directory("MediaDownloader/_temp");
        step_download(&config, &paths, &logger);
    }

    step_convert(&config, &paths, &logger);
    step_finalize(&config);
}

fn step_download(config: &IPCConfig, paths: &ProcessPaths, logger: &IPCLogger) {
    match config.input.download_type.as_str() {
        "thumbnail" => ThumbnailDownloader::new(config, paths).download(logger),
        "default" => DefaultDownloader::new(config, paths).download(logger),
        _ => {}
    };
}

fn step_convert(ipc_config: &IPCConfig, paths: &ProcessPaths, ipc_logger: &IPCLogger) {
    match ipc_config.settings.format_type.as_str() {
        "video" => VideoConverter::new(ipc_config, paths).convert(ipc_logger),
        "audio" => AudioConverter::new(ipc_config, paths).convert(ipc_logger),
        "gif" => GifConverter::new(ipc_config, paths).convert(ipc_logger),
        "sequence" => SequenceConverter::new(ipc_config, paths).convert(ipc_logger),
        "image" => ImageConverter::new(ipc_config, paths).convert(ipc_logger),
        _ => {}
    }
}

fn step_finalize(config: &IPCConfig) {
    Finalizer::new(config).finalize();
}
