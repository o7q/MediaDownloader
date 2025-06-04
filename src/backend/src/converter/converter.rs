use crate::{
    config::config::IPCConfig,
    utils::directory::{create_directory, remove_directory},
};

pub trait Converter {
    fn new(ipc_config: IPCConfig, bin_dir: &str, working_dir: &str) -> Self;

    fn init_dir(&self, working_dir: &str) {
        let _ = remove_directory(&format!("{}/convert", working_dir));
        let _ = create_directory(&format!("{}/convert", working_dir));
    }

    fn convert(&self);
}
