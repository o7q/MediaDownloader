#[cfg(target_os = "windows")]
pub fn install_ffmpeg() {
    use crate::utils::{directory::create_directory, net::download_file};

    let _ = create_directory("MediaDownloader/_temp");
    let _ = download_file(
        "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip",
        "MediaDownloader/_temp/ffmpeg.zip",
    );
}

#[cfg(target_os = "linux")]
pub fn install_ffmpeg() {}
