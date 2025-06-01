async function startDownloadAsync() {
    const uiValues = getUIValues();

    const download_name = await download(uiValues);
    document.getElementById("output-name-textbox").value = download_name;
    
    await convert(uiValues);
}

async function download(uiValues) {
    let downloadType;
    switch (uiValues.settingsMode) {
        case "image": downloadType = "thumbnail"; break;
        default: downloadType = "default"; break;
    }

    const downloadData = {
        url: uiValues.inputUrl,
        url_is_playlist: isUrlPlaylist(uiValues.inputUrl),

        forced_name: uiValues.outputName,

        custom_ytdlp_arguments_enable: uiValues.settingsArgumentsYtdlpEnable,
        custom_ytdlp_arguments: uiValues.settingsArgumentsYtdlp
    };

    return await tauri_invoke("download", { downloadData: downloadData, downloadType: downloadType });
}

async function convert(uiValues) {
    const convertData = {
        format: uiValues.settingsType,

        trim_enable: uiValues.settingsTrimEnable,
        trim_start_enable: uiValues.settingsTrimStartEnable,
        trim_start: uiValues.settingsTrimStart,
        trim_end_enable: uiValues.settingsTrimEndEnable,
        trim_end: uiValues.settingsTrimEnd,

        size_change_enable: uiValues.settingsSizeEnable,
        size_change_width: uiValues.settingsSizeWidth,
        size_change_height: uiValues.settingsSizeHeight,

        fps_change_enable: uiValues.settingsFramerateEnable,
        fps_change_framerate: uiValues.settingsFramerate,

        vbr_bitrate: uiValues.settingsBitrateVideo,
        abr_bitrate: uiValues.settingsBitrateAudio,

        custom_ffmpeg_arguments_enable: uiValues.settingsArgumentsFfmpegEnable,
        custom_ffmpeg_arguments: uiValues.settingsArgumentsFfmpeg
    };

    await tauri_invoke("convert", { convertData: convertData, convertType: uiValues.settingsMode });
}