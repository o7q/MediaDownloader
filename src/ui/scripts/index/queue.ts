import { invoke } from "@tauri-apps/api/core";
import { IPCDownloadConfig } from "./download_config/interface";

export async function addQueueItemAsync(config: IPCDownloadConfig) {
    await invoke("push-queue", { config: config });
}