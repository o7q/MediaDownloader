use std::env;

use crate::updater::{meta::generate_update_metadata, updater::Updater};

mod bootstrap;
mod commands;
mod config;
mod global;
mod logger;
mod media;
mod processor;
mod updater;
mod utils;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    let args: Vec<String> = env::args().collect();

    if args.len() > 1 {
        match args[1].as_str() {
            "generate-update-metadata" => generate_update_metadata(),

            "updater-start" => Updater::new().start(),
            "updater-update" => Updater::new().update(),
            "updater-cleanup" => Updater::new().cleanup(),
            _ => {}
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
            commands::update::update_start,
            commands::update::update_check
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
