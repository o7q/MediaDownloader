use futures_util::join;
use tauri::AppHandle;

use crate::{
    bootstrap_utils::{ffmpeg::bootstrap_ffmpeg, ytdlp::bootstrap_ytdlp},
    logger::logger::IPCLogger,
    utils::file::file_exists,
};

#[cfg(target_os = "windows")]
#[tauri::command]
pub fn bootstrap_check() -> bool {
    file_exists("MediaDownloader/bin/yt-dlp.exe") && file_exists("MediaDownloader/bin/ffmpeg.exe")
}

#[cfg(target_os = "windows")]
#[tauri::command(async)]
pub async fn bootstrap_install(app: AppHandle) {
    let ytdlp_logger: IPCLogger = IPCLogger::new(app.clone());
    let ffmpeg_logger: IPCLogger = IPCLogger::new(app.clone());

    join!(
        bootstrap_ytdlp(&ytdlp_logger),
        bootstrap_ffmpeg(&ffmpeg_logger)
    );
}

#[cfg(not(target_os = "windows"))]
#[tauri::command]
pub fn bootstrap_check() -> bool {
    true
}

#[cfg(not(target_os = "windows"))]
#[tauri::command(async)]
pub async fn bootstrap_install() {}
