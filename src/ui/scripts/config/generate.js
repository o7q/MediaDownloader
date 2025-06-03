function generateIPCConfig() {
    const $ = id => document.getElementById(id);

    return {
        input: {
            url: $("input-url-textbox").value
        },

        settings: {
            format:                         $("settings-format-dropdown")            .value,

            trim_enable:                    $("settings-trim-checkbox")              .checked,
            trim_from_start_enable:         $("settings-trim-start-checkbox")        .checked,
            trim_start:                     $("settings-trim-start-textbox")         .value,
            trim_to_end_enable:             $("settings-trim-end-checkbox")          .checked,
            trim_end:                       $("settings-trim-end-textbox")           .value,

            size_change_enable:             $("settings-size-fps-size-checkbox")     .checked,
            size_change_width:              $("settings-size-fps-width-textbox")     .value,
            size_change_height:             $("settings-size-fps-height-textbox")    .value,

            fps_change_enable:              $("settings-size-fps-framerate-checkbox").checked,
            fps_change_framerate:           $("settings-size-fps-framerate-textbox") .value,

            vbr_bitrate:                    $("settings-bitrate-video-textbox")      .value,
            abr_bitrate:                    $("settings-bitrate-audio-textbox")      .value,

            custom_ytdlp_arguments_enable:  $("settings-arguments-ytdlp-checkbox")   .checked,
            custom_ytdlp_arguments:         $("settings-arguments-ytdlp-textarea")   .value.split('\n'),
            custom_ffmpeg_arguments_enable: $("settings-arguments-ffmpeg-checkbox")  .checked,
            custom_ffmpeg_arguments:        $("settings-arguments-ffmpeg-textarea")  .value.split('\n')
        },

        output: {
            name: $("output-name-textbox").value,
            path: $("output-path-textbox").value
        }
    }
}