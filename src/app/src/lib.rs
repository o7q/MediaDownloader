#[allow(unused_imports)]
use crate::meta::generate_metadata;

mod commands;

mod bootstrap;
mod config;
mod logger;
mod media;
mod meta;
mod processor;
mod utils;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    // generate_metadata();

    tauri::Builder::default()
        .plugin(tauri_plugin_dialog::init())
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![
            commands::download::download,

            commands::data::data_write_user_config,
            commands::data::data_write_download_config,
            commands::data::data_write_queue,
            commands::data::data_write_history,
            commands::data::data_read_user_config,
            commands::data::data_read_download_config,
            commands::data::data_read_queue,
            commands::data::data_read_history,

            commands::bootstrap::bootstrap_check,
            commands::bootstrap::bootstrap_install,

            commands::update::update_check,
            commands::update::update_open_page
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
