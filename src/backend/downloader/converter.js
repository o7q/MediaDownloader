const { getFiles } = require("../utils/filesystem.js");

class Converter {
    constructor() {
        this.format = "mp3";
    }

    setFormat(format) {
        this.format = format;
    }

    async convert() {
        console.log(getFiles("MediaDownloader/temp/download"));
    }
}

module.exports = { Converter };