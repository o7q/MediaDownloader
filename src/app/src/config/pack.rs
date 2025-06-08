use crate::{
    config::config::IPCConfig,
    utils::file::{read_file, write_file},
};

pub fn append_config(pack_file: &str, config: &IPCConfig) {
    let mut pack: Vec<IPCConfig> = match read_file(pack_file) {
        Ok(contents) => deserialize_config_pack(&contents),
        Err(_) => Vec::new(),
    };

    pack.push(config.clone());

    let _ = write_file(pack_file, &serialize_config_pack(&pack));
}

pub fn serialize_config_pack(config: &Vec<IPCConfig>) -> String {
    match serde_json::to_string(config) {
        Ok(ipc_config_string) => ipc_config_string,
        Err(e) => {
            eprintln!("Failed to serialize IPCConfig: {}", e);
            String::new()
        }
    }
}

pub fn deserialize_config_pack(config_vec_str: &str) -> Vec<IPCConfig> {
    match serde_json::from_str(config_vec_str) {
        Ok(ipc_config_vec) => ipc_config_vec,
        Err(e) => {
            eprintln!("Failed to deserialize IPCConfig: {}", e);
            Vec::new()
        }
    }
}
