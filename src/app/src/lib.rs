mod config;
mod converter;
mod downloader;
mod utils;
mod wrapper;

mod commands;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    tauri::Builder::default()
        .plugin(tauri_plugin_dialog::init())
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![
            commands::download,
            commands::convert
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
