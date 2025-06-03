use crate::utils::{
    file::{create_directory, get_filename, get_files, remove_directory},
    process::start_process,
};

use super::converter::{Converter, IPCConvertData};

pub struct SequenceConverter {
    data: IPCConvertData,
    bin_dir: String,
    working_dir: String,
}

impl Converter for SequenceConverter {
    fn new(convert_data: IPCConvertData, bin_dir: &str, working_dir: &str) -> Self {
        Self {
            data: convert_data,
            bin_dir: bin_dir.to_string(),
            working_dir: working_dir.to_string(),
        }
    }

    fn convert(&self) {
        self.init_dir(&self.working_dir);

        let extension = match self.data.cfg.settings.format.as_str() {
            "png" => "png",
            "jpg" => "jpg",
            _ => "",
        };

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

            if !self.data.cfg.settings.vbr_bitrate.is_empty() {
                pre_convert_args.push("-b:v".to_string());
                pre_convert_args.push(self.data.cfg.settings.vbr_bitrate.clone());
            }

            if self.data.cfg.settings.size_change_enable
                && self
                    .data
                    .cfg
                    .settings
                    .size_change_width
                    .parse::<i32>()
                    .is_ok()
                && self
                    .data
                    .cfg
                    .settings
                    .size_change_height
                    .parse::<i32>()
                    .is_ok()
            {
                pre_convert_args.push("-vf".to_string());
                pre_convert_args.push(format!(
                    "scale={}:{},setsar=1",
                    self.data.cfg.settings.size_change_width,
                    self.data.cfg.settings.size_change_height
                ));
            }

            if self.data.cfg.settings.fps_change_enable
                && self
                    .data
                    .cfg
                    .settings
                    .fps_change_framerate
                    .parse::<i32>()
                    .is_ok()
            {
                pre_convert_args.push("-r".to_string());
                pre_convert_args.push(self.data.cfg.settings.fps_change_framerate.clone());
            }

            if self.data.cfg.settings.trim_enable {
                if !self.data.cfg.settings.trim_from_start_enable {
                    pre_convert_args.push("-ss".to_string());
                    pre_convert_args.push(self.data.cfg.settings.trim_start.clone());
                }
                if !self.data.cfg.settings.trim_to_end_enable {
                    pre_convert_args.push("-to".to_string());
                    pre_convert_args.push(self.data.cfg.settings.trim_end.clone());
                }
            }

            if self.data.cfg.settings.custom_ffmpeg_arguments_enable {
                for arg in &self.data.cfg.settings.custom_ffmpeg_arguments {
                    pre_convert_args.push(arg.clone())
                }
            }

            pre_convert_args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &pre_convert_args);

            let mut convert_args: Vec<String> = Vec::new();
            convert_args.push("-loglevel".to_string());
            convert_args.push("verbose".to_string());
            convert_args.push("-y".to_string());

            convert_args.push("-i".to_string());
            convert_args.push(format!("{}/convert_temp/video.mp4", &self.working_dir));

            let filename: String = get_filename(&input_file, false);
            let path: String = format!("{}/convert/{}", &self.working_dir, filename);

            let _ = create_directory(&path);

            convert_args.push(format!("{}/{}_%04d.{}", path, filename, extension));
            let _ = start_process(&format!("{}/ffmpeg", &self.bin_dir), &convert_args);
        }
    }
}
