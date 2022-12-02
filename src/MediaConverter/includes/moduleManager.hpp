#pragma once

#include <iostream>
#include "utils.hpp"
#include "color/color.hpp"
#include "modules/remux.hpp"
using namespace std;

void moduleInit();

void moduleInit()
{
    sys("col1");
    sys("title MediaConverter " + VERSION);
    draw_header();

    cout << " SELECT AN OPTION (enter a non-number to exit)\n"
         << dye::bright_white(draw_array(stringVault::MODULE_TITLE_DATA, 1, 3, "  > [#] ", true));
    draw_cursor();

    string moduleSelect;
    getline(cin, moduleSelect); syncCin();

    if (!isInt(moduleSelect)) _Exit(0);

    sys("col2"); sys("clr"); 
    switch (stoi(moduleSelect))
    {
        case 1: module_remux(); break;
    }
}