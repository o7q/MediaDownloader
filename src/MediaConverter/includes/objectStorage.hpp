#pragma once

#include <iostream>
using namespace std;

namespace OBJECT_STORAGE
{
    namespace ENVIRONMENT
    {
        const string VERSION = "v1.0.0 (PROTOTYPE)";
        bool PERSISTENT;
        
        string ROOT_PATH;
        string MAIN_PATH;
        string FFMPEG_PATH;
        string OUTPUT_PATH;
    }
    namespace DATA
    {
        string FFMPEG_INIT = "ffmpeg.exe -loglevel verbose -i ";
        string MODULE_TITLE[] =
        {
            "REMUX", // 1
            "COMPRESS", // 2
            "RESIZE", // 3
            // etc.
            "OPTIONS", // 4
            "GITHUB", // 5
            "INFO" // 6
        };
        string COMMON_MEDIA_FORMAT[] =
        {
            // video
            "avi", // 1
            "mkv", // 2
            "mov", // 3
            "mp4", // 4
            "webm", // 5
            "wmv", // 6
            // audio
            "aac", // 7
            "flac", // 8
            "m4a", // 9
            "mp3", // 10
            "ogg", // 11
            "opus", // 12
            "wav", // 13
            // image
            "ico", // 14
            "jpg", // 15
            "png", // 16
            "webp" // 17
        };
    }
}