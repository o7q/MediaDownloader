const { startProcess } = require("../utils/process");

class UrlDownloader {
    constructor() {
        this.name = "";
        this.downloadType = "video"; // types are: video, thumbnail
    }

    setURL(url) {
        this.url = url;
    }

    setName(name) {
        this.name = name;
    }

    setDownloadType(downloadType) {
        this.downloadType = downloadType;
    }

    async download() {
        const outputName = this.name === "" ? "%(title)s" : this.name;

        let args;
        switch (this.downloadType) {
            case "video":
                args = ["--verbose", "--ffmpeg-location", "bin/ffmpeg.exe", "-o", `MediaDownloader/temp/download/${outputName}`, this.url];
                break;
            case "thumbnail":
                args = ["--verbose", "--skip-download", "--write-thumbnail", "-o", `MediaDownloader/temp/download/${outputName}`, this.url];
                break;
            default:
                args = [];
                break;
        }

        await startProcess("bin/yt-dlp", args);
    }
}

module.exports = { UrlDownloader };