const { ipcMain } = require("electron");
const { UrlDownloader } = require("../downloader/url-downloader.js");
const { Converter } = require("../downloader/converter.js");
const { createDirectory } = require("../utils/filesystem.js")

function registerDownloaderEvents() {
    ipcMain.handle("download-url", async (event, downloadSettings) => {
        createDirectory("MediaDownloader");
        createDirectory("MediaDownloader/temp");
        createDirectory("MediaDownloader/temp/download");

        const urlDownloader = new UrlDownloader();
        urlDownloader.setURL(downloadSettings.url);
        urlDownloader.setName(downloadSettings.name);
        await urlDownloader.download();
    });
}

module.exports = { registerDownloaderEvents };