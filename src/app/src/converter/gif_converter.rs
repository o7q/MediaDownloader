use crate::{
    config::config::IPCConfig,
    utils::{
        directory::{create_directory, remove_directory},
        file::{get_filename, get_files},
        process::start_process,
    },
};

use super::converter::Converter;

pub struct GifConverter {
    cfg: IPCConfig,
    bin_dir: String,
    working_dir: String,
}

impl Converter for GifConverter {
    fn new(ipc_config: IPCConfig, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            cfg: ipc_config,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn convert(&self) {
        self.init_dir(&self.working_dir);

        for input_file in get_files(&format!("{}/download", &self.working_dir)) {
            let _ = remove_directory(&format!("{}/convert_temp", &self.working_dir));
            let _ = create_directory(&format!("{}/convert_temp", &self.working_dir));

            let mut pre_convert_args: Vec<String> = Vec::new();
            pre_convert_args.push("-loglevel".to_string());
            pre_convert_args.push("verbose".to_string());
            pre_convert_args.push("-y".to_string());

            pre_convert_args.push("-i".to_string());
            pre_convert_args.push(input_file.clone());

            pre_convert_args.push("-c:v".to_string());
            pre_convert_args.push("libx264".to_string());

            pre_convert_args.push("-an".to_string());

            if !self.cfg.settings.vbr_bitrate.is_empty() {
                pre_convert_args.push("-b:v".to_string());
                pre_convert_args.push(self.cfg.settings.vbr_bitrate.clone());
            }

            if self.cfg.settings.size_change_enable
                && self.cfg.settings.size_change_width.parse::<i32>().is_ok()
                && self.cfg.settings.size_change_height.parse::<i32>().is_ok()
            {
                pre_convert_args.push("-vf".to_string());
                pre_convert_args.push(format!(
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
                pre_convert_args.push("-r".to_string());
                pre_convert_args.push(self.cfg.settings.fps_change_framerate.clone());
            }

            if self.cfg.settings.trim_enable {
                if !self.cfg.settings.trim_from_start_enable {
                    pre_convert_args.push("-ss".to_string());
                    pre_convert_args.push(self.cfg.settings.trim_start.clone());
                }
                if !self.cfg.settings.trim_to_end_enable {
                    pre_convert_args.push("-to".to_string());
                    pre_convert_args.push(self.cfg.settings.trim_end.clone());
                }
            }

            pre_convert_args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &pre_convert_args);

            let mut palette_args: Vec<String> = Vec::new();
            palette_args.push("-loglevel".to_string());
            palette_args.push("verbose".to_string());
            palette_args.push("-y".to_string());

            palette_args.push("-i".to_string());
            palette_args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));

            palette_args.push("-vf".to_string());
            palette_args.push("palettegen".to_string());

            palette_args.push(format!("{}/convert_temp/palette.png", &self.working_dir));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &palette_args);

            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));

            convert_args.push("-i".to_string());
            convert_args.push(format!("{}/convert_temp/palette.png", &self.working_dir));

            convert_args.push("-lavfi".to_string());
            convert_args.push("paletteuse".to_string());

            convert_args.push(format!(
                "{}/convert/{}.gif",
                &self.working_dir,
                get_filename(&input_file, false)
            ));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &convert_args);
        }
    }
}
