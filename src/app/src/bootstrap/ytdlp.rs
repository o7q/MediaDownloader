use crate::utils::net::download_file;

#[cfg(target_os = "windows")]
pub fn install_ytdlp() {
    let _ = download_file(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe",
        "MediaDownloader/bin/yt-dlp.exe",
    );

}

#[cfg(target_os = "linux")]
pub fn install_ytdlp() {
    let _ = download_file(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp_linux",
        "MediaDownloader/bin/yt-dlp",
    );

}