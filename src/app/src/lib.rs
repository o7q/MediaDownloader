use std::env;

use crate::meta::generate_metadata;

mod bootstrap;
mod commands;
mod config;
mod logger;
mod media;
mod meta;
mod processor;
mod utils;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    let args: Vec<String> = env::args().collect();

    if args.len() > 1 {
        if args[1] == "generate-metadata" {
            generate_metadata();
            return;
        }
    }

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
            commands::utils::util_open_path_location,
            commands::bootstrap::bootstrap_check,
            commands::bootstrap::bootstrap_install,
            commands::update::update_check,
            commands::update::update_open_page
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
