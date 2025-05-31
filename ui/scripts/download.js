async function startDownloadAsync() {
    await download();
}

async function download() {
    const url = document.getElementById("input-url-textbox").value;
    const outputName = document.getElementById("output-name-textbox").value;

    const type_dropdown = document.getElementById("settings-types-dropdown");
    const mode = type_dropdown.options[type_dropdown.selectedIndex].getAttribute("mode");

    const ytdlpArguments = document.getElementById("settings-arguments-ytdlp-textarea").value;

    let downloadType;

    switch (mode) {
        case "image": downloadType = "thumbnail"; break;
        default: downloadType = "default"; break;
    }

    const isPlaylist = isUrlPlaylist(url);

    let downloadData = { url: url, forced_name: outputName, custom_raw_arguments: ytdlpArguments, is_playlist: isPlaylist };

    const download_name = await tauri_invoke("download", { downloadData, downloadType });
    document.getElementById("output-name-textbox").value = download_name;
}

async function convert() {

}