function getUIValues() {
    const $ = id => document.getElementById(id);
    const settingsTypeDropdown = document.getElementById("settings-types-dropdown");

    return {
        inputUrl: $("input-url-textbox").value,

        settingsType:                  settingsTypeDropdown.value,
        settingsMode:                  settingsTypeDropdown.options[settingsTypeDropdown.selectedIndex].getAttribute("mode"),
        
        settingsTrimEnable:            $("settings-trim-checkbox").checked,
        settingsTrimStartEnable:       $("settings-trim-start-checkbox").checked,
        settingsTrimStart:             $("settings-trim-start-textbox").value,
        settingsTrimEndEnable:         $("settings-trim-end-checkbox").checked,
        settingsTrimEnd:               $("settings-trim-end-textbox").value,

        settingsSizeEnable:            $("settings-size-fps-size-checkbox").checked,
        settingsSizeWidth:             $("settings-size-fps-width-textbox").value,
        settingsSizeHeight:            $("settings-size-fps-height-textbox").value,
        
        settingsFramerateEnable:       $("settings-size-fps-framerate-checkbox").checked,
        settingsFramerate:             $("settings-size-fps-framerate-textbox").value,

        settingsBitrateVideo:          $("settings-bitrate-video-textbox").value,
        settingsBitrateAudio:          $("settings-bitrate-audio-textbox").value,

        settingsArgumentsYtdlpEnable:  $("settings-arguments-ytdlp-checkbox").checked,
        settingsArgumentsYtdlp:        $("settings-arguments-ytdlp-textarea").value.split('\n'),
        settingsArgumentsFfmpegEnable: $("settings-arguments-ffmpeg-checkbox").checked,
        settingsArgumentsFfmpeg:       $("settings-arguments-ffmpeg-textarea").value.split('\n'),

        outputName: $("output-name-textbox").value,
        outputPath: $("output-path-textbox").value
    }
}