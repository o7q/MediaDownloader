#pragma once

#include <iostream>
#include "utils.hpp"
#include "color/color.hpp"
#include "modules/m_remux.hpp"
using namespace std;

void moduleInit();

void moduleInit()
{
    sys("col1");
    sys("title MediaConverter " + version);
    draw_header();

    cout << " SELECT AN OPTION (enter a non-number to exit)\n";
    cout << dye::bright_white("  > [1] REMUX\n"
            "  > [2] COMPRESS\n"
            "  > [3] RESIZE\n");
    draw_cursor();

    string module_select;
    getline(cin, module_select); syncCin();

    if (!isInt(module_select)) _Exit(0);

    sys("col2"); sys("clr"); 
    switch (stoi(module_select))
    {
        case 1: module_remux(); break;
    }
}