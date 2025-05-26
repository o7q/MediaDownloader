mod downloader;
use downloader::Downloader;

#[tauri::command]
fn download(url: &str) {
    let mut downloader: Downloader = Downloader::new();
    downloader.set_url(url);
    downloader.download();
}

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    tauri::Builder::default()
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![download])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
