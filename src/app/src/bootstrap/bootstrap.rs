use crate::{
    bootstrap::{ffmpeg::install_ffmpeg, ytdlp::install_ytdlp},
    utils::directory::create_directory,
};

pub fn install() {
    let _ = create_directory("MediaDownloader/bin");
    install_ytdlp();
    install_ffmpeg();
}
