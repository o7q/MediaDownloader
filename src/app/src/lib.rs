use crate::bootstrap::bootstrap::install;

mod converter;
mod downloader;
mod finalizer;

mod config;
mod logger;
mod processor;
mod utils;

mod download;

mod bootstrap;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    install();

    tauri::Builder::default()
        .plugin(tauri_plugin_dialog::init())
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![
            download::download,
            download::get_download_name
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
