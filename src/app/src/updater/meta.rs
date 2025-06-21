use std::process;

use crate::{
    updater::check::IPCUpdateMetadata,
    utils::serial::{serialize_file_write, WriteType},
};

pub const VERSION_ID: i32 = 510;
pub const VERSION: &str = "v5.1.0";
pub const RELEASE_NOTES: &str = r#""#;

#[allow(dead_code)]
pub fn generate_update_metadata() {
    let metadata: IPCUpdateMetadata = IPCUpdateMetadata {
        version_id: VERSION_ID,
        version: VERSION.to_string(),
        description: RELEASE_NOTES.to_string(),
    };

    serialize_file_write("meta.json", &metadata, WriteType::Pretty);

    process::exit(0);
}
