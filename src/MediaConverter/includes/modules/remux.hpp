#pragma once

#include <iostream>
// #include <experimental/filesystem>
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

//     int count { };

//    std::filesystem::path p1 { path };

//    for (auto& p : std::filesystem::directory_iterator(p1))
//    {
//       ++count;
//    }

//    std::cout << "# of files in " << p1 << ": " << count << '\n';

// cout << count;

//     sys("ps");

    cout << dye::bright_white("\n SELECT A FORMAT OR ENTER YOUR OWN\n")
         << "  VIDEO\n"
         << dye::bright_white(draw_array(stringVault::COMMON_MEDIA_FORMAT_DATA, 1, 6, "   > [#] ", true))
         << "  AUDIO\n"
         << dye::bright_white(draw_array(stringVault::COMMON_MEDIA_FORMAT_DATA, 7, 13, "   > [#] ", true))
         << "  IMAGE\n"
         << dye::bright_white(draw_array(stringVault::COMMON_MEDIA_FORMAT_DATA, 14, 17, "   > [#] ", true));
    draw_cursor();

    string formatSelect;
    getline(cin, formatSelect); syncCin();

    string format = isInt(formatSelect) ? '.' + stringVault::COMMON_MEDIA_FORMAT_DATA[stoi(formatSelect) - 1] : formatSelect.front() == '.' ? formatSelect : '.' + formatSelect;

    draw_spacer();
    sys(stringVault::FFMPEG_INIT_DATA + getFileInfo(true, path) + " \"" + getFileInfo(false, path) + "_out" + format + "\"");
    draw_spacer();

    cout << " REMUX ANOTHER? (y = yes | anything else = return to main menu)\n";
    draw_cursor();

    string exitPrompt;
    getline(cin, exitPrompt);

    sys("col2"); sys("clr");

    if (exitPrompt == "y") module_remux();
}