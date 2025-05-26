mod downloaders;

use downloaders::downloader::Downloader;
use downloaders::video_downloader::VideoDownloader;

#[tauri::command(async)]
fn download_video(url: &str) {
    let mut downloader: VideoDownloader = VideoDownloader::new();
    downloader.set_url(url);
    downloader.download();
}

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    tauri::Builder::default()
        .plugin(tauri_plugin_opener::init())
        .invoke_handler(tauri::generate_handler![download_video])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
