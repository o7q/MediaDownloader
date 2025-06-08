use crate::bootstrap::{ffmpeg::bootstrap_ffmpeg, ytdlp::bootstrap_ytdlp};

pub fn bootstrap_check() {
    bootstrap_ytdlp();
    bootstrap_ffmpeg();
}
