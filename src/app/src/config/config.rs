use serde::{Deserialize, Serialize};

use crate::utils::string::clean_string_vector;

#[derive(Serialize, Deserialize, Clone, Default)]
pub struct IPCInputConfig {
    pub url: String,
    pub is_playlist: bool,
    pub download_type: String,
}

#[derive(Serialize, Deserialize, Clone, Default)]
pub struct IPCSettingsConfig {
    pub format: String,
    pub format_type: String,

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

#[derive(Serialize, Deserialize, Clone, Default)]
pub struct IPCOutputConfig {
    pub name: String,
    pub path: String,
}

#[derive(Serialize, Deserialize, Clone, Default)]
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

pub fn serialize_config(config: &IPCConfig) -> String {
    match serde_json::to_string(config) {
        Ok(ipc_config_string) => ipc_config_string,
        Err(e) => {
            eprintln!("Failed to serialize IPCConfig: {}", e);
            String::new()
        }
    }
}

pub fn deserialize_config(config_str: &str) -> IPCConfig {
    match serde_json::from_str(config_str) {
        Ok(ipc_config) => ipc_config,
        Err(e) => {
            eprintln!("Failed to deserialize IPCConfig: {}", e);
            IPCConfig::default()
        }
    }
}
