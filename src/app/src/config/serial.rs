use crate::config::config::IPCConfig;

pub fn serialize_config(config: &IPCConfig) -> String {
    match serde_json::to_string(config) {
        Ok(ipc_config_string) => ipc_config_string,
        Err(e) => {
            eprintln!("Failed to serialize IPCConfig: {}", e);
            String::new()
        }
    }
}

pub fn deserialize_config(config_str: &str) -> IPCConfig {
    match serde_json::from_str(config_str) {
        Ok(ipc_config) => ipc_config,
        Err(e) => {
            eprintln!("Failed to deserialize IPCConfig: {}", e);
            IPCConfig::default()
        }
    }
}
