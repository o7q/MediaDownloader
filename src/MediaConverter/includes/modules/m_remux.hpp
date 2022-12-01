#pragma once

#include <iostream>
#include "../utils.hpp"
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

    cout << dye::bright_white("\n SELECT A FORMAT OR SPECIFY IN YOUR OWN\n");
    cout << "  VIDEO\n";
    cout << draw_array(stringStore::formatData, 1, 6, "   > [$] ", true);
    cout << "  AUDIO\n";
    cout << draw_array(stringStore::formatData, 7, 13, "   > [$] ", true);
    cout << "  IMAGE\n";
    cout << draw_array(stringStore::formatData, 14, 17, "   > [$] ", true);
    draw_cursor();
    string formatPrompt;
    getline(cin, formatPrompt); syncCin();

    string format = isInt(formatPrompt) ? '.' + stringStore::formatData[stoi(formatPrompt) - 1] : formatPrompt.front() == '.' ? formatPrompt : '.' + formatPrompt;

    draw_spacer();
    sys(stringStore::ffmpegInit + getFileInfo(true, path) + " \"" + getFileInfo(false, path) + "_out" + format + "\"");
    draw_spacer();

    cout << " WANT TO REMUX ANOTHER? (y = yes | anything else = return to main menu)\n";
    draw_cursor();

    string exitPrompt;
    getline(cin, exitPrompt);

    sys("col2"); sys("clr");

    if (exitPrompt == "y") module_remux();
}