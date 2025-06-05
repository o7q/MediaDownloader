use crate::{
    config::config::IPCConfig,
    utils::{
        file::{get_filename, get_files},
        process::start_process,
    },
};

use super::converter::Converter;

pub struct VideoConverter {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Converter for VideoConverter {
    fn new(ipc_config: IPCConfig, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            cfg: ipc_config,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn convert(&self) {
        self.init_dir(&self.working_dir);

        let (video_codec, audio_codec, extension) = match self.cfg.settings.format.as_str() {
            "mp4-fast" => ("copy", "copy", "mp4"),
            "mp4" => ("libx264", "aac", "mp4"),
            "mp4-nvidia" => ("h264_nvenc", "aac", "mp4"),
            "mp4-amd" => ("h264_amf", "aac", "mp4"),
            "webm" => ("libvpx-vp9", "libopus", "webm"),
            "avi" => ("rawvideo", "pcm_s16le", "avi"),
            _ => ("", "", ""),
        };

        for input_file in get_files(&format!("{}/download", &self.working_dir)) {
            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(input_file.clone());

            convert_args.push("-c:v".to_string());
            convert_args.push(video_codec.to_string());

            convert_args.push("-c:a".to_string());
            convert_args.push(audio_codec.to_string());

            if !self.cfg.settings.vbr_bitrate.is_empty() {
                convert_args.push("-b:v".to_string());
                convert_args.push(self.cfg.settings.vbr_bitrate.clone());
            }
            if !self.cfg.settings.abr_bitrate.is_empty() {
                convert_args.push("-b:a".to_string());
                convert_args.push(self.cfg.settings.abr_bitrate.clone());
            }

            if self.cfg.settings.size_change_enable
                && self.cfg.settings.size_change_width.parse::<i32>().is_ok()
                && self.cfg.settings.size_change_height.parse::<i32>().is_ok()
            {
                convert_args.push("-vf".to_string());
                convert_args.push(format!(
                    "scale={}:{},setsar=1",
                    self.cfg.settings.size_change_width, self.cfg.settings.size_change_height
                ));
            }

            if self.cfg.settings.fps_change_enable
                && self
                    .cfg
                    .settings
                    .fps_change_framerate
                    .parse::<i32>()
                    .is_ok()
            {
                convert_args.push("-r".to_string());
                convert_args.push(self.cfg.settings.fps_change_framerate.clone());
            }

            if self.cfg.settings.trim_enable {
                if !self.cfg.settings.trim_from_start_enable {
                    convert_args.push("-ss".to_string());
                    convert_args.push(self.cfg.settings.trim_start.clone());
                }
                if !self.cfg.settings.trim_to_end_enable {
                    convert_args.push("-to".to_string());
                    convert_args.push(self.cfg.settings.trim_end.clone());
                }
            }

            if self.cfg.settings.custom_ffmpeg_arguments_enable {
                for arg in &self.cfg.settings.custom_ffmpeg_arguments {
                    convert_args.push(arg.clone())
                }
            }

            convert_args.push(format!(
                "{}/convert/{}.{}",
                &self.working_dir,
                get_filename(&input_file, false),
                extension
            ));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &convert_args);
        }
    }
}
