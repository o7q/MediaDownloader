use crate::bootstrap::bootstrap::bootstrap_check;

mod commands;

mod converter;
mod downloader;
mod finalizer;

mod bootstrap;
mod config;
mod logger;
mod processor;
mod utils;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    bootstrap_check();

    tauri::Builder::default()
        .plugin(tauri_plugin_dialog::init())
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![
            commands::download::download,
            commands::data::write_current_download_config,
            commands::data::load_current_download_config,
            commands::data::write_queue,
            commands::data::load_queue,
            commands::data::write_history,
            commands::data::load_history
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
