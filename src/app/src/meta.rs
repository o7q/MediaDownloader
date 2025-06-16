use crate::{
    commands::update::IPCUpdateMetadata,
    utils::serial::{serialize_file_write, WriteType},
};

pub const VERSION_ID: i32 = 500;
pub const VERSION: &str = "v5.0.0";
pub const RELEASE_NOTES: &str = r#"- MediaDownloader has been completely rewritten from scratch using the Tauri framework
- It is now cross-platform (currently it has only been tested for Windows and Linux)
- Greatly improved the UI (the UI has been redesigned from scratch with a HTML + CSS frontend, enabling a more cohesive experience)
    - The console window is now embedded
    - The window is now resizeable
    - Split common functions into separate windows
- JSON is now used for storing configuration files
- Fixed yt-dlp breaking every once in a while, yt-dlp will now be auto-updated
- Fixed incorrect FFmpeg bitrate argument injections
- Improved the auto-naming feature (it is less annoying now)"#;

#[allow(dead_code)]
pub fn generate_metadata() {
    let metadata: IPCUpdateMetadata = IPCUpdateMetadata {
        version_id: VERSION_ID,
        version: VERSION.to_string(),
        description: RELEASE_NOTES.to_string(),
    };

    serialize_file_write("meta.json", &metadata, WriteType::Pretty);
}
