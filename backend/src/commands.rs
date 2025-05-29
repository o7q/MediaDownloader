use crate::downloader::default_downloader::DefaultDownloader;
use crate::downloader::downloader::Downloader;
use crate::downloader::thumbnail_downloader::ThumbnailDownloader;

#[tauri::command(async)]
pub fn download(download_type: &str, url: &str, output_name: &str, custom_arguments: &str) {
    match download_type {
        "thumbnail" => {
            let mut downloader: ThumbnailDownloader = ThumbnailDownloader::new();
            downloader.set_url(url);
            downloader.set_name(output_name);
            downloader.set_custom_arguments(custom_arguments);
            downloader.download()
        }
        _ => {
            let mut downloader: DefaultDownloader = DefaultDownloader::new();
            downloader.set_url(url);
            downloader.set_name(output_name);
            downloader.set_custom_arguments(custom_arguments);
            downloader.download()
        }
    }

    println!("DONE!!!!!!!!!!!!!!!!");
}
