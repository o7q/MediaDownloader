#[cfg(target_os = "linux")]
use std::io;

use crate::logger::logger::IPCLogger;
use crate::utils::{directory::create_directory, file::file_exists, net::download_file_async};

#[cfg(target_os = "windows")]
pub async fn bootstrap_ytdlp(logger: &IPCLogger) {
    const PATH: &str = "MediaDownloader/bin/yt-dlp.exe";

    if file_exists(PATH) {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");

    logger.log("Downloading yt-dlp...");
    let _ = download_file_async(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe",
        PATH,
    )
    .await;

    logger.log(&format!("Downloaded yt-dlp to \"{}\"", PATH));
}

#[cfg(target_os = "linux")]
pub async fn bootstrap_ytdlp(logger: &IPCLogger) {
    use std::{
        fs::{self, Permissions},
        os::unix::fs::PermissionsExt,
    };

    const PATH: &str = "MediaDownloader/bin/yt-dlp_linux";

    if file_exists(PATH) {
        return;
    }

    let _ = create_directory("MediaDownloader/bin");

    logger.log("Downloading yt-dlp...");
    let _ = download_file_async(
        "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp_linux",
        PATH,
    )
    .await;

    let metadata_result: Result<fs::Metadata, io::Error> =
        fs::metadata(PATH);

    let mut permissions: Permissions = match metadata_result {
        Ok(metadata) => metadata.permissions(),
        Err(e) => {
            eprintln!("Failed to get metadata: {}", e);
            return;
        }
    };

    let current_mode: u32 = permissions.mode();
    permissions.set_mode(current_mode | 0o111);

    if let Err(e) = fs::set_permissions(PATH, permissions) {
        eprintln!("Failed to set permissions: {}", e);
    } else {
        println!("File is now executable.");
    }

    logger.log(&format!("Downloaded yt-dlp to \"{}\"", PATH));
}
