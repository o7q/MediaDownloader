#pragma once

#include <iostream>
#include "utils.hpp"
#include "objectStorage.hpp"
#include "color/color.hpp"
#include "options.hpp"
#include "modules/remux.hpp"
using namespace std;

void moduleInit();

void moduleInit()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION);
    draw_header();

    cout << " " + OBJECT_STORAGE::MESSAGE::OPTION_SELECT + " (enter a non-number to exit)\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::MODULE_TITLE, 1, 3, "  > [#] ", true)) + "\n"
         << dye::bright_white(draw_array(OBJECT_STORAGE::DATA::MODULE_TITLE, 4, 6, "  > [#] ", true));
    draw_cursor();

    string moduleSelect;
    getline(cin, moduleSelect); syncCin();

    sys("col2"); sys("clr");
    if (!isInt(moduleSelect)) { OBJECT_STORAGE::ENVIRONMENT::PERSISTENT = false; return; }
    switch (stoi(moduleSelect))
    {
        case 1: module_remux(); break;

        case 4: options(); break;
    }
}