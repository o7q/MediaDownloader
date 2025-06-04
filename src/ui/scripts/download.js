async function startDownloadAsync() {
    const ipcConfig = generateIPCConfig();

    const download_name = await download(ipcConfig);
    document.getElementById("output-name-textbox").value = download_name;

    await convert(ipcConfig);
}

async function download(ipcConfig) {
    return await tauri_invoke("download", { ipcConfig: ipcConfig });
}

async function convert(ipcConfig) {
    await tauri_invoke("convert", { ipcConfig: ipcConfig });
}