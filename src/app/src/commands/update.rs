use serde::{Deserialize, Serialize};

use crate::{
    meta::VERSION_ID,
    utils::{
        net::{download_text_async, launch_url},
        serial::deserialize,
    },
};

#[derive(Serialize, Deserialize, Default)]
pub struct IPCUpdateMetadata {
    pub version_id: i32,
    pub version: String,
    pub description: String,
}

#[derive(Serialize, Default)]
pub struct IPCUpdateStatus {
    pub has_update: bool,
    pub metadata: IPCUpdateMetadata,
}

#[tauri::command(async)]
pub async fn update_check() -> IPCUpdateStatus {
    let result: Result<String, reqwest::Error> = download_text_async(
        "https://github.com/o7q/Testing/releases/latest/download/meta.json",
    )
    .await;

    match result {
        Ok(text) => {
            let metadata: IPCUpdateMetadata = deserialize(&text);

            IPCUpdateStatus {
                has_update: metadata.version_id > VERSION_ID,
                metadata: metadata,
            }
        }
        Err(_) => IPCUpdateStatus::default(),
    }
}

#[tauri::command]
pub fn update_open_page() {
    launch_url("https://github.com/o7q/MediaDownloader/releases");
}
