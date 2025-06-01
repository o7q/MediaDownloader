use serde::Deserialize;

use crate::utils::file::{create_directory, remove_directory};

#[derive(Deserialize)]
pub struct IPCConvertData {
    pub format: String,

    pub trim_enable: bool,
    pub trim_start_enable: bool,
    pub trim_start: String,
    pub trim_end_enable: bool,
    pub trim_end: String,

    pub size_change_enable: bool,
    pub size_change_width: String,
    pub size_change_height: String,

    pub fps_change_enable: bool,
    pub fps_change_framerate: String,

    pub vbr_change_enable: bool,
    pub vbr_change_bitrate: String,

    pub abr_change_enable: bool,
    pub abr_change_bitrate: String,

    pub custom_ffmpeg_arguments_enable: bool,
    pub custom_ffmpeg_arguments: Vec<String>,
}

pub trait Converter {
    fn new(convert_data: IPCConvertData) -> Self;

    fn init_paths(&self) {
        let _ = remove_directory("MediaDownloader/temp/convert");
        let _ = create_directory("MediaDownloader/temp/convert");
    }

    fn convert(&self);
}
