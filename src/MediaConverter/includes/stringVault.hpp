#pragma once

#include <iostream>
using namespace std;

const string VERSION = "v1.0.0";
namespace stringVault
{
    string FFMPEG_INIT_DATA = "ffmpeg.exe -loglevel verbose -i ";
    string MODULE_TITLE_DATA[] =
    {
        "REMUX", // 1
        "COMPRESS", // 2
        "RESIZE" // 3
    };
    string COMMON_MEDIA_FORMAT_DATA[] =
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