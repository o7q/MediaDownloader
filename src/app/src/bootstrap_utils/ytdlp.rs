use crate::logger::logger::IPCLogger;
use crate::utils::{directory::create_directory, file::file_exists, net::download_file_async};

#[cfg(target_os = "windows")]
pub async fn bootstrap_ytdlp(logger: &IPCLogger) {
    if file_exists("MediaDownloader/bin/yt-dlp.exe") {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");

    logger.log("Downloading yt-dlp...");
    let _ = download_file_async(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe",
        "MediaDownloader/bin/yt-dlp.exe",
    )
    .await;

    logger.log("Downloaded yt-dlp to \"MediaDownloader/bin/yt-dlp.exe\"");
}

#[cfg(target_os = "linux")]
pub fn bootstrap_ytdlp(logger: &IPCLogger) {}
