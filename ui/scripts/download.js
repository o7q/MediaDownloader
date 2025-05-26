async function startDownloadAsync() {
    let url = document.getElementById("url-textbox").value;
    await invoke("download_video", { url: url });
}