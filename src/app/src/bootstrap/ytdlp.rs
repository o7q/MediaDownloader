use crate::utils::{directory::create_directory, file::file_exists, net::download_file};

#[cfg(target_os = "windows")]
pub fn bootstrap_ytdlp() {
    if file_exists("MediaDownloader/bin/yt-dlp.exe") {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");

    let _ = download_file(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe",
        "MediaDownloader/bin/yt-dlp.exe",
    );
}

#[cfg(target_os = "linux")]
pub fn bootstrap_ytdlp() {}
