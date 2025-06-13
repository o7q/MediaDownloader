interface IPCDownloadInputConfig {
    url:           string;
    is_playlist:   boolean;
    download_type: string;
}

interface IPCDownloadSettingsConfig {
    format:                         string;
    format_type:                    string;

    trim_enable:                    boolean;
    trim_from_start_enable:         boolean;
    trim_start:                     string;
    trim_to_end_enable:             boolean;
    trim_end:                       string;

    size_change_enable:             boolean;
    size_change_width:              string;
    size_change_height:             string;

    fps_change_enable:              boolean;
    fps_change_framerate:           string;

    vbr_bitrate:                    string;
    abr_bitrate:                    string;

    custom_ffmpeg_arguments_enable: boolean;
    custom_ffmpeg_arguments:        string[];

    custom_ytdlp_arguments_enable:  boolean;
    custom_ytdlp_arguments:         string[];
}

interface IPCDownloadOutputConfig {
    name: string;
    path: string;
}

export interface IPCDownloadConfig {
    input:    IPCDownloadInputConfig;
    settings: IPCDownloadSettingsConfig;
    output:   IPCDownloadOutputConfig;
}

export function createIPCDownloadConfig() {
    const config: IPCDownloadConfig = {
        input: {
            url:           "",
            is_playlist:   false,
            download_type: ""
        },

        settings: {
            format:                         "",
            format_type:                    "",

            trim_enable:                    false,
            trim_from_start_enable:         false,
            trim_start:                     "",
            trim_to_end_enable:             false,
            trim_end:                       "",

            size_change_enable:             false,
            size_change_width:              "",
            size_change_height:             "",

            fps_change_enable:              false,
            fps_change_framerate:           "",

            vbr_bitrate:                    "",
            abr_bitrate:                    "",

            custom_ytdlp_arguments_enable:  false,
            custom_ytdlp_arguments:         [],
            custom_ffmpeg_arguments_enable: false,
            custom_ffmpeg_arguments:        []
        },

        output: {
            name: "",
            path: ""
        }
    };

    return config;
}