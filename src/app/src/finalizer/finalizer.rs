use crate::{
    config::download_config::IPCDownloadConfig,
    utils::{
        directory::{create_directory, get_directories, get_directory_name},
        file::{copy_file, get_filename, get_files, read_file},
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

    pub fn finalize(&self) {
        let mut out: String = self.cfg.output.path.to_string();

        if out.is_empty() {
            let _ = create_directory("Downloads");
            out = "Downloads".to_string();
        }

        if self.cfg.input.is_playlist {
            if self.cfg.output.name.is_empty() {
                match read_file("MediaDownloader/_temp/download_name_lock") {
                    Ok(contents) => {
                        out.push_str(&format!("/{}", contents));
                    }
                    Err(_) => {
                        out.push_str("/Unnamed Playlist");
                    }
                }
            } else {
                out.push_str(&format!("/{}", self.cfg.output.name));
            }
            let _ = create_directory(&out);
        }

        for file in get_files("MediaDownloader/_temp/convert") {
            let dest_path: String = format!("{}/{}", out, get_filename(&file, true));
            let _ = copy_file(&file, &dest_path);
        }

        for folder in get_directories("MediaDownloader/_temp/convert") {
            let folder_dest_path: String = format!("{}/{}", out, get_directory_name(&folder));

            let _ = create_directory(&folder_dest_path);
            for file in get_files(&folder) {
                let file_dest_path: String =
                    format!("{}/{}", folder_dest_path, get_filename(&file, true));
                let _ = copy_file(&file, &file_dest_path);
            }
        }
    }
}
