use crate::{
    config::download_config::IPCDownloadConfig,
    utils::{
        directory::{create_directory, directory_exists},
        serial::{deserialize_file_read, serialize_file_write_push, WriteType},
    },
};

#[tauri::command]
pub fn push_queue(config: IPCDownloadConfig) {
    if !directory_exists("MediaDownloader/config") {
        let _ = create_directory("MediaDownloader/config");
    }
    serialize_file_write_push(
        "MediaDownloader/config/queue.json",
        &config,
        WriteType::Compress,
    );
}

#[tauri::command]
pub fn load_queue() -> Vec<IPCDownloadConfig> {
    deserialize_file_read("MediaDownloader/config/queue.json")
}

#[tauri::command]
pub fn load_history() -> Vec<IPCDownloadConfig> {
    deserialize_file_read("MediaDownloader/config/history.json")
}
