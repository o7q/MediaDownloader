use serde::{Deserialize, Serialize};

use crate::utils::string::clean_string_vector;

#[derive(Serialize, Deserialize, Clone)]
pub struct IPCInputConfig {
    pub url: String,
}

#[derive(Serialize, Deserialize, Clone)]
pub struct IPCSettingsConfig {
    pub format: String,

    pub trim_enable: bool,
    pub trim_from_start_enable: bool,
    pub trim_start: String,
    pub trim_to_end_enable: bool,
    pub trim_end: String,

    pub size_change_enable: bool,
    pub size_change_width: String,
    pub size_change_height: String,

    pub fps_change_enable: bool,
    pub fps_change_framerate: String,

    pub vbr_bitrate: String,
    pub abr_bitrate: String,

    pub custom_ffmpeg_arguments_enable: bool,
    pub custom_ffmpeg_arguments: Vec<String>,

    pub custom_ytdlp_arguments_enable: bool,
    pub custom_ytdlp_arguments: Vec<String>,
}

#[derive(Serialize, Deserialize, Clone)]
pub struct IPCOutputConfig {
    pub name: String,
    pub path: String,
}

#[derive(Serialize, Deserialize, Clone)]
pub struct IPCConfig {
    pub input: IPCInputConfig,
    pub settings: IPCSettingsConfig,
    pub output: IPCOutputConfig,
}

impl IPCConfig {
    pub fn purify(&mut self) {
        clean_string_vector(&mut self.settings.custom_ytdlp_arguments);
        clean_string_vector(&mut self.settings.custom_ffmpeg_arguments);
    }
}
