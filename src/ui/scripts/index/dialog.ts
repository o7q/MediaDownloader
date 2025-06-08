import { open } from '@tauri-apps/plugin-dialog';

export async function openDialogAsync(): Promise<String> {
    const file = await open({
        directory: true,
    });

    return file ? file : "";
}