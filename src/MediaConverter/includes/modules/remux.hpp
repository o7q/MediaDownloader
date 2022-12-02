#pragma once

#include <iostream>
#include "../utils.hpp"
#include "../color/color.hpp"
using namespace std;

void module_remux();

void module_remux()
{
    sys("col1"); 
    draw_header();

    cout << " MEDIA PATH\n";
    draw_cursor();
    string path;
    getline(cin, path); syncCin();



//     sys("ps");

    cout << "\n SELECT A FORMAT OR ENTER YOUR OWN\n"
         << "  VIDEO\n"
         << dye::bright_white(draw_array(OBJECT_VAULT::DATA::COMMON_MEDIA_FORMAT, 1, 6, "   > [#] ", true))
         << "  AUDIO\n"
         << dye::bright_white(draw_array(OBJECT_VAULT::DATA::COMMON_MEDIA_FORMAT, 7, 13, "   > [#] ", true))
         << "  IMAGE\n"
         << dye::bright_white(draw_array(OBJECT_VAULT::DATA::COMMON_MEDIA_FORMAT, 14, 17, "   > [#] ", true));
    draw_cursor();

    string formatSelect;
    getline(cin, formatSelect); syncCin();

    string format = isInt(formatSelect) ? '.' + OBJECT_VAULT::DATA::COMMON_MEDIA_FORMAT[stoi(formatSelect) - 1] : formatSelect.front() == '.' ? formatSelect : '.' + formatSelect;

    draw_spacer();
    sys(OBJECT_VAULT::DATA::FFMPEG_INIT + getFileInfo(true, path) + " \"" + getFileInfo(false, path) + "_out" + format + "\"");
    draw_spacer();

    cout << " REMUX ANOTHER? " + OBJECT_VAULT::MESSAGE::EXIT_SELECT + "\n";
    draw_cursor();

    string exitPrompt;
    getline(cin, exitPrompt);

    sys("col2"); sys("clr");

    if (exitPrompt == "y") module_remux();
}