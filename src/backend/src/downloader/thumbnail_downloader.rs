use super::downloader::{Downloader, IPCDownloadData};

pub struct ThumbnailDownloader {
    download_data: IPCDownloadData,
}

impl Downloader for ThumbnailDownloader {
    fn new(download_data: IPCDownloadData) -> Self {
        Self {
            download_data: download_data,
        }
    }

    fn get_download_data(&self) -> IPCDownloadData {
        self.download_data.clone()
    }

    fn download(&self) -> String {
        self.init();

        let mut args: Vec<String> = Vec::new();
        args.push(String::from("--verbose"));
        args.push(String::from("--ffmpeg-location"));
        args.push(String::from("MediaDownloader/bin/ffmpeg.exe"));
        args.push(String::from("--skip-download"));
        args.push(String::from("--write-thumbnail"));

        if self.download_data.custom_ytdlp_arguments_enable {
            for arg in &self.download_data.custom_ytdlp_arguments {
                args.push(arg.clone())
            }
        }

        args.push(String::from("-o"));
        args.push(format!(
            "MediaDownloader/_temp/download/{}",
            self.determine_output_name_argument()
        ));
        args.push(self.download_data.url.clone());

        self.run(&args)
    }
}
