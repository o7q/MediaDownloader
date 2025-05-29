async function startDownloadAsync() {
    const url = document.getElementById("input-url-textbox").value;
    const outputName = document.getElementById("output-name-textbox").value;

    const format_dropdown = document.getElementById("settings-formats-dropdown");
    const format = format_dropdown.value;
    const format_type = format_dropdown.options[format_dropdown.selectedIndex].getAttribute("data-type");

    const ytdlpArguments = document.getElementById("settings-arguments-ytdlp-textarea").value;

    let downloadType;

    switch (format_type) {
        case "image": downloadType = "thumbnail"; break;
        default: downloadType = "default"; break;
    }

    await invoke("download", { downloadType: downloadType, url: url, outputName: outputName, customArguments: ytdlpArguments });
}