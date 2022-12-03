#pragma once

#include <iostream>
#include "utils.hpp"
using namespace std;

void wizard();

void wizard()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION + "   [WIZARD]");
    draw_header();

    cout << " WELCOME TO MEDIACONVERTER! BECAUSE THIS IS THE FIRST TIME YOU ARE RUNNING\n"
            "                            THE PROGRAM THERE IS SOME SETUP TO DO.\n\n"
            "                            IF YOU WANT TO SKIP THE SETUP INPUT 'N',\n"
            "                            INPUT ANYTHING ELSE TO CONTINUE\n"
            "                            YOU CAN CHANGE ANY OF THESE SETTINGS LATER IN OPTIONS\n";
    draw_cursor();

    string skipSelect;
    getline(cin, skipSelect); syncCin();
    if (skipSelect == "N" || skipSelect == "n") return;

    cout << " FFMPEG PATH\n";
    draw_cursor();
    string ffmpegPath;
    getline(cin, ffmpegPath); syncCin();
    OBJECT_STORAGE::ENVIRONMENT::FFMPEG_PATH = getFileInfo(ffmpegPath, true);

    cout << OBJECT_STORAGE::ENVIRONMENT::FFMPEG_PATH;

    sys("ps");

    sys("col2"); sys("clr");
}