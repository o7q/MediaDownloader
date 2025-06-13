use crate::{
    config::download_config::IPCDownloadConfig,
    utils::{
        directory::{create_directory, directory_exists},
        file::file_exists,
        serial::{deserialize_file_read, serialize_file_write, WriteType},
    },
};

#[tauri::command]
pub fn write_current_download_config(config: IPCDownloadConfig) {
    if !directory_exists("MediaDownloader/config") {
        let _ = create_directory("MediaDownloader/config");
    }
    serialize_file_write(
        "MediaDownloader/config/current.json",
        &config,
        WriteType::Pretty,
    );
}

#[tauri::command]
pub fn load_current_download_config() -> IPCDownloadConfig {
    deserialize_file_read("MediaDownloader/config/current.json", false)
}

#[tauri::command]
pub fn does_current_download_config_exist() -> bool {
    file_exists("MediaDownloader/config/current.json")
}

#[tauri::command]
pub fn write_queue(queue: Vec<IPCDownloadConfig>) {
    if !directory_exists("MediaDownloader/config") {
        let _ = create_directory("MediaDownloader/config");
    }
    serialize_file_write(
        "MediaDownloader/config/queue.dat",
        &queue,
        WriteType::Compress,
    );
}

#[tauri::command]
pub fn load_queue() -> Vec<IPCDownloadConfig> {
    deserialize_file_read("MediaDownloader/config/queue.dat", true)
}

#[tauri::command]
pub fn write_history(history: Vec<IPCDownloadConfig>) {
    if !directory_exists("MediaDownloader/config") {
        let _ = create_directory("MediaDownloader/config");
    }
    serialize_file_write(
        "MediaDownloader/config/history.dat",
        &history,
        WriteType::Compress,
    );
}

#[tauri::command]
pub fn load_history() -> Vec<IPCDownloadConfig> {
    deserialize_file_read("MediaDownloader/config/history.dat", true)
}
