use crate::config::config::IPCConfig;

pub fn serialize_config(config: &IPCConfig) -> String {
    serde_json::to_string(config).unwrap()
}

pub fn deserialize_config(config_str: &str) -> IPCConfig {
    serde_json::from_str(config_str).unwrap()
}
