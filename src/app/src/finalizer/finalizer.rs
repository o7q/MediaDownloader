use crate::{
    config::config::IPCConfig,
    utils::{
        directory::create_directory,
        file::{copy_file, get_filename, get_files, read_file},
    },
};

pub struct Finalizer {
    pub cfg: IPCConfig,
}

impl Finalizer {
    pub fn new(ipc_config: &IPCConfig) -> Self {
        Self {
            cfg: ipc_config.clone(),
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
            println!("{dest_path}");
            let _ = copy_file(&file, &dest_path);
        }
    }
}
