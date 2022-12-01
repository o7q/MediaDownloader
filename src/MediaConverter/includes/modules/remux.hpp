#pragma once

#include <iostream>
#include "../utils.hpp"
using namespace std;

void MOD_REMUX();

void MOD_REMUX()
{
    SYS("col1"); 
    DRAW_HEAD();

    cout << " MEDIA PATH\n";
    cout << " -> ";
    string PATH;
    getline(cin, PATH); SYNC_CIN();

    cout << "\n SELECT A FORMAT OR SPECIFY IN YOUR OWN\n"
            "  VIDEO\n"
            "   > [1] avi \n"
            "   > [2] mkv\n"
            "   > [3] mov\n"
            "   > [4] mp4\n"
            "   > [5] webm\n"
            "   > [6] wmv\n"
            "  AUDIO\n"
            "   > [7] aac \n"
            "   > [8] flac\n"
            "   > [9] m4a\n"
            "   > [10] mp3\n"
            "   > [11] ogg\n"
            "   > [12] opus\n"
            "   > [13] wav\n"
            "  IMAGE\n"
            "   > [14] ico\n"
            "   > [15] jpg\n"
            "   > [16] png\n"
            "   > [17] webp\n";
    cout << " -> ";
    string FORMAT_INPUT;
    getline(cin, FORMAT_INPUT); SYNC_CIN();

    string FORMAT = IS_INT(FORMAT) ? STR_STORE::FORMAT_STORE[stoi(FORMAT) - 1] : FORMAT.front() == '.' ? FORMAT : '.' + FORMAT;

    DRAW_SPACER();
    SYS(STR_STORE::FFMPEG_INIT + GET_FILE_INFO(true, PATH) + " \"" + GET_FILE_INFO(false, PATH) + "_out" + FORMAT + "\"");
    DRAW_SPACER();

    cout << " WANT TO REMUX ANOTHER? (y = yes | anything else = return to main menu)\n -> ";

    string EXIT_PROMPT;
    getline(cin, EXIT_PROMPT);

    SYS("col2"); SYS("clr");

    if (EXIT_PROMPT == "y") MOD_REMUX();
}