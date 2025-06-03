async function startDownloadAsync() {
    const ipcConfig = generateIPCConfig();

    const settingsFormatDropdown = document.getElementById("settings-format-dropdown");
    let formatType = settingsFormatDropdown.options[settingsFormatDropdown.selectedIndex].getAttribute("type-value");

    const download_name = await download(ipcConfig, formatType);
    document.getElementById("output-name-textbox").value = download_name;

    await convert(ipcConfig, formatType);
}

async function download(ipcConfig, formatType) {
    let downloadType;
    switch (formatType) {
        case "image": downloadType = "thumbnail"; break;
        default: downloadType = "default"; break;
    }

    const downloadData = {
        cfg: ipcConfig,
        is_playlist: isUrlPlaylist(ipcConfig.input.url)
    }

    return await tauri_invoke("download", { downloadData: downloadData, downloadType: downloadType });
}

async function convert(ipcConfig, formatType) {
    const convertData = {
        cfg: ipcConfig
    }
    await tauri_invoke("convert", { convertData: convertData, convertType: formatType });
}