interface IPCInputConfig {
    url:           string;
    is_playlist:   boolean;
    download_type: string;
}

interface IPCSettingsConfig {
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

interface IPCOutputConfig {
    name: string;
    path: string;
}

export interface IPCConfig {
    input:    IPCInputConfig;
    settings: IPCSettingsConfig;
    output:   IPCOutputConfig;
}