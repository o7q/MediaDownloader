#pragma once

#include <iostream>
#include "../utils.hpp"
using namespace std;

void remux()
{
    sys("col1"); 
    drawHead();

    cout << " MEDIA PATH\n";
    cout << " -> ";
    string filePath;
    getline(cin, filePath); cc();

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
    string format;
    getline(cin, format); cc();

    string ext = isInt(format) ? str::exts[stoi(format) - 1] : format.front() == '.' ? format : '.' + format;

    drawSp();
    sys(str::ffmpegSrt + getFInfo(true, filePath) + " \"" + getFInfo(false, filePath) + "_out" + ext + "\"");
    drawSp();

    cout << " WANT TO REMUX ANOTHER? (y = yes | anything else = return to main menu)\n -> ";

    string s;
    getline(cin, s);

    sys("col2"); sys("clr");

    if (s == "y") remux();
}