use crate::{
    config::download_config::IPCDownloadConfig,
    utils::{
        directory::{create_directory, get_directories, get_directory_name},
        file::{copy_file, file_exists, get_extension, get_filename, get_files},
    },
};

pub struct Finalizer {
    pub cfg: IPCDownloadConfig,
}

impl Finalizer {
    pub fn new(config: &IPCDownloadConfig) -> Self {
        Self {
            cfg: config.clone(),
        }
    }

    pub fn finalize(&self, finalize_name: &str) {
        let mut output_path: String = self.cfg.output.path.to_string();

        if output_path.is_empty() {
            let _ = create_directory("Downloads");
            output_path = "Downloads".to_string();
        }

        if self.cfg.input.is_playlist {
            output_path.push_str(&format!("/{}", finalize_name));
            let _ = create_directory(&output_path);
        }

        for file in get_files("MediaDownloader/_temp/convert") {
            let file_dest_path: String = if self.cfg.input.is_playlist {
                format!("{}/{}", output_path, get_filename(&file, true))
            } else {
                let extension: String = match get_extension(&file) {
                    Some(extension) => extension,
                    None => "".to_string(),
                };

                let mut file_dest_path_temp: String =
                    format!("{}/{}.{}", output_path, finalize_name, extension);
                let mut counter: i32 = 0;

                while file_exists(&file_dest_path_temp) {
                    counter += 1;
                    file_dest_path_temp = format!(
                        "{}/{}_{}.{}",
                        output_path, finalize_name, counter, extension
                    );
                }

                file_dest_path_temp
            };
            let _ = copy_file(&file, &file_dest_path);
        }

        for folder in get_directories("MediaDownloader/_temp/convert") {
            let folder_dest_path: String =
                format!("{}/{}", output_path, get_directory_name(&folder));

            let _ = create_directory(&folder_dest_path);
            for file in get_files(&folder) {
                let file_dest_path: String =
                    format!("{}/{}", folder_dest_path, get_filename(&file, true));
                let _ = copy_file(&file, &file_dest_path);
            }
        }
    }
}
