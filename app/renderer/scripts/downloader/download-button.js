function downloadStart() {
    window.system.createFolder("MediaDownloader");
    window.system.createFolder("MediaDownloader/temp");
    window.system.createFolder("MediaDownloader/temp/download");

    const url = document.getElementById("url-input").value;

    const downloader = new Downloader();

    downloader.setURL(url);
    downloader.setName("");
    downloader.download();
}