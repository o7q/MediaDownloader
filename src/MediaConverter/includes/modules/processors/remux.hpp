#pragma once

#include <iostream>
#include <sys/stat.h>
#include <dirent.h>
#include "../../utils.hpp"
#include "../../objectStorage.hpp"
#include "../../color/color.hpp"
using namespace std;

void module_remux();

void module_remux()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION + "   [REMUX]");
    draw_header();

    cout << " MEDIA PATH\n";
    draw_cursor();
    string path;
    getline(cin, path); syncCin();

    // decide if the path is a file or directory, set doBulk state
    string rawPath = getFileInfo_cut(path);
    bool doBulk = false;
    struct stat bulkCheck;
    if (stat(rawPath.c_str(), &bulkCheck) == 0)
    {
        if (bulkCheck.st_mode & S_IFDIR) { doBulk = true; }
        else if (bulkCheck.st_mode & S_IFREG) { doBulk = false; }
    }

    cout << "\n SELECT A FORMAT OR ENTER YOUR OWN\n"
         << "  VIDEO\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::COMMON_MEDIA_FORMAT, 1, 6, "   > [#] ", true))
         << "  AUDIO\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::COMMON_MEDIA_FORMAT, 7, 13, "   > [#] ", true))
         << "  IMAGE\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::COMMON_MEDIA_FORMAT, 14, 17, "   > [#] ", true));
    draw_cursor();

    string formatSelect;
    getline(cin, formatSelect); syncCin();

    string format = isInt(formatSelect) ? '.' + OBJECT_STORAGE::DATA::COMMON_MEDIA_FORMAT[stoi(formatSelect) - 1] : formatSelect.front() == '.' ? formatSelect : '.' + formatSelect;

    if (doBulk)
    {
        if (auto dir = opendir(rawPath.c_str()))
        {
            while (auto f = readdir(dir))
            {
                if (!f->d_name || f->d_name[0] == '.') continue;
                
                draw_spacer();
                string filePath = rawPath + "\\" + f->d_name;
                sys(OBJECT_STORAGE::DATA::FFMPEG_INIT + getFileInfo(filePath, true, true) + " \"" + getFileInfo(filePath, false, false) + "_out" + format + "\""); 
            }
            closedir(dir);
            draw_spacer();
        }
    }
    else
    {
        draw_spacer();
        sys(OBJECT_STORAGE::DATA::FFMPEG_INIT + getFileInfo(path, true, true) + " \"" + getFileInfo(path, false, false) + "_out" + format + "\"");
        draw_spacer(); 
    }

    cout << " REMUX ANOTHER? (y = yes | anything else = return to main menu)\n";
    draw_cursor();

    string exitPrompt;
    getline(cin, exitPrompt);

    sys("col2"); sys("clr");

    if (exitPrompt == "Y" || exitPrompt == "y") module_remux();
}