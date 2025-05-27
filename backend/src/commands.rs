use crate::downloader::downloader::Downloader;
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;
use crate::downloader::video_downloader::VideoDownloader;

#[tauri::command(async)]
pub fn download_video(url: &str, output_name: &str) {
    let mut downloader: VideoDownloader = VideoDownloader::new();
    downloader.set_url(url);
    downloader.set_name(output_name);
    downloader.download();
}

#[tauri::command(async)]
pub fn download_thumbnail(url: &str, output_name: &str) {
    let mut downloader: ThumbnailDownloader = ThumbnailDownloader::new();
    downloader.set_url(url);
    downloader.set_name(output_name);
    downloader.download();
}
