#pragma once

#include <iostream>
#include <string>
#include <regex>
using namespace std;

void sys(string cmd);
string getFInfo(bool pathOut, string path);
string getFInfo_cut(string in);
string strRep(string charIn, int am);
bool isInt(string in);
void drawHead();
void drawSp();
void cc();

const string ver = "v1.0.0";

namespace str
{
    string ffmpegSrt = "ffmpeg.exe -loglevel verbose -i ";

    string exts[] =
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
void sys(string cmd)
{
    string cmds[] =
    {
        "ps", "pause",
        "clr", "cls",
        "col1", "color 7",
        "col2", "color 8"
    };
    int cmds_size = sizeof(cmds) / sizeof(string);
    int cmds_index = 0;
    for (int i = 0; i < cmds_size; i++)
    {
        if (cmd == cmds[i]) { system(cmds[i + 1].c_str()); return; }
        cmds_index++;
    }
    if (cmds_index == cmds_size) system(cmd.c_str());
}

// get file info function
string getFInfo(bool pathOut, string path)
{
    if (pathOut) return '"' + getFInfo_cut(path) + '"';
    else
    {
        string file = getFInfo_cut(path.substr(path.find_last_of("/\\") + 1));
        size_t lastindex = file.find_last_of("."); 
        return file.substr(0, lastindex); 
    }
}
string getFInfo_cut(string in)
{
    return regex_replace(in, regex("\\\""), "");;
}

// string repeater function
string strRep(string charIn, int am)
{
    string output;
    for (int i = 0; i < am; i++) output += charIn;
    return output;
}

// is integer function
bool isInt(string in)
{
    return !in.empty() && in.find_first_not_of("0123456789");
}

// draw head function
void drawHead()
{
    cout << "    __  ___       ___      _____                      __         \n"
            "   /  |/  /__ ___/ (_)__ _/ ___/__  ___ _  _____ ____/ /____ ____\n"
            "  / /|_/ / -_) _  / / _ `/ /__/ _ \\/ _ \\ |/ / -_) __/ __/ -_) __/\n"
            " /_/  /_/\\__/\\_,_/_/\\_,_/\\___/\\___/_//_/___/\\__/_/  \\__/\\__/_/   ";
    cout << " " + ver + "\n" + strRep(" ", 66) + "by o7q\n\n+" + strRep("=", 71) + "+\n\n";
}

// draw spacer function
void drawSp()
{
    cout << "\n+" + strRep("=", 71) + "+\n\n";
}

// cin clear function
void cc()
{
    cin.clear(); cin.sync();
}