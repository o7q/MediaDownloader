use serde::Deserialize;

use crate::utils::file::{create_directory, remove_directory};

#[derive(Deserialize)]
pub struct IPCConvertData {
    pub trim_enable: bool,
    pub trim_start: String,
    pub trim_end: String,
}

pub trait Converter {
    fn new(convert_data: IPCConvertData) -> Self;

    fn init_paths(&self) {
        let _ = remove_directory("MediaDownloader/temp/convert");
        let _ = create_directory("MediaDownloader/temp/convert");
    }
}
