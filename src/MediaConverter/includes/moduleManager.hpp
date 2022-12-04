#pragma once

#include <iostream>
#include "utils.hpp"
#include "objectStorage.hpp"
#include "color/color.hpp"
#include "modules/options.hpp"
#include "modules/info.hpp"
#include "modules/processors/remux.hpp"
using namespace std;

void moduleInit();

void moduleInit()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION);
    draw_header();

    cout << " SELECT AN OPTION (enter a non-number to exit)\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::MODULE_TITLE, 1, 3, "  > [#] ", true)) + "\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::MODULE_TITLE, 4, 6, "  > [#] ", true));
    draw_cursor();

    string moduleSelect;
    getline(cin, moduleSelect); syncCin();

    sys("col2"); sys("clr");
    if (!isInt(moduleSelect)) { OBJECT_STORAGE::ENVIRONMENT::PERSISTENT = false; return; }
    switch (stoi(moduleSelect))
    {
        // processors
        case 1: module_remux(); break;
        // etc.
        case 4: module_options(); break;
        case 5: sys("start https://github.com/o7q/MediaDownloader/tree/main/src/MediaConverter"); break;
        case 6: module_info(); break;
    }
}