use serde::Deserialize;

use crate::{
    config::config::IPCConfig,
    utils::file::{create_directory, remove_directory},
};

#[derive(Deserialize, Clone)]
pub struct IPCConvertData {
    pub cfg: IPCConfig,
}

pub trait Converter {
    fn new(convert_data: IPCConvertData, bin_dir: &str, working_dir: &str) -> Self;

    fn init_dir(&self, working_dir: &str) {
        let _ = remove_directory(&format!("{}/convert", working_dir));
        let _ = create_directory(&format!("{}/convert", working_dir));
    }

    fn convert(&self);
}
