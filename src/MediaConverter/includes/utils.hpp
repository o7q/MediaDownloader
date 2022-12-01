#pragma once

#include <iostream>
#include <string>
#include <regex>
using namespace std;

void SYS(string INPUT);
string GET_FILE_INFO(bool COMPUTE_PATH, string INPUT);
string GET_FILE_INFO_cut(string INPUT);
string STR_REPEAT(string CHAR_IN, int AMOUNT);
bool IS_INT(string INPUT);
void DRAW_HEAD();
void DRAW_SPACER();
void SYNC_CIN();

const string VERSION = "v1.0.0";

namespace STR_STORE
{
    string FFMPEG_INIT = "ffmpeg.exe -loglevel verbose -i ";

    string FORMAT_STORE[] =
    {
        // video
        ".avi",
        ".mkv",
        ".mov",
        ".mp4",
        ".webm",
        ".wmv",

        // audio
        ".aac",
        ".flac",
        ".m4a",
        ".mp3",
        ".ogg",
        ".opus",
        ".wav",

        // image
        ".ico",
        ".jpg",
        ".png",
        ".webp"
    };
}

// system cmd function
void SYS(string INPUT)
{
    string CMDS[] =
    {
        "ps", "pause",
        "clr", "cls",
        "col1", "color 7",
        "col2", "color 8"
    };
    int CMDS_size = sizeof(CMDS) / sizeof(string);
    int CMDS_index = 0;
    for (int i = 0; i < CMDS_size; i++)
    {
        if (INPUT == CMDS[i]) { system(CMDS[i + 1].c_str()); return; }
        CMDS_index++;
    }
    if (CMDS_index == CMDS_size) system(INPUT.c_str());
}

// get file info function
string GET_FILE_INFO(bool COMPUTE_PATH, string INPUT)
{
    if (COMPUTE_PATH) return '"' + GET_FILE_INFO_cut(INPUT) + '"';
    else
    {
        string FILE = GET_FILE_INFO_cut(INPUT.substr(INPUT.find_last_of("/\\") + 1));
        size_t FILE_lastIndex = FILE.find_last_of("."); 
        return FILE.substr(0, FILE_lastIndex); 
    }
}
string GET_FILE_INFO_cut(string INPUT)
{
    return regex_replace(INPUT, regex("\\\""), "");;
}

// string repeater function
string STR_REPEAT(string CHAR_IN, int AMOUNT)
{
    string OUTPUT;
    for (int i = 0; i < AMOUNT; i++) OUTPUT += CHAR_IN;
    return OUTPUT;
}

// is integer function
bool IS_INT(string INPUT)
{
    return !INPUT.empty() && INPUT.find_first_not_of("0123456789");
}

// draw head function
void DRAW_HEAD()
{
    cout << "    __  ___       ___      _____                      __         \n"
            "   /  |/  /__ ___/ (_)__ _/ ___/__  ___ _  _____ ____/ /____ ____\n"
            "  / /|_/ / -_) _  / / _ `/ /__/ _ \\/ _ \\ |/ / -_) __/ __/ -_) __/\n"
            " /_/  /_/\\__/\\_,_/_/\\_,_/\\___/\\___/_//_/___/\\__/_/  \\__/\\__/_/   ";
    cout << " " + VERSION + "\n" + STR_REPEAT(" ", 66) + "by o7q\n\n+" + STR_REPEAT("=", 71) + "+\n\n";
}

// draw spacer function
void DRAW_SPACER()
{
    cout << "\n+" + STR_REPEAT("=", 71) + "+\n\n";
}

// cin clear function
void SYNC_CIN()
{
    cin.clear(); cin.sync();
}