#pragma once

#include <iostream>
#include "utils.hpp"
#include "modules/remux.hpp"
using namespace std;

void MODULE_INIT();

void MODULE_INIT()
{
    SYS("col1");
    SYS("title MediaConverter " + VERSION);
    DRAW_HEAD();

    cout << " SELECT AN OPTION\n"
            "  > [1] REMUX\n"
            "  > [2] COMPRESS\n"
            "  > [3] RESIZE\n";
    cout << " -> ";

    string MODULE_PROMPT;
    getline(cin, MODULE_PROMPT); SYNC_CIN();

    if (!IS_INT(MODULE_PROMPT)) _Exit(0);

    SYS("col2"); SYS("clr"); 
    switch (stoi(MODULE_PROMPT))
    {
        case 1: MOD_REMUX(); break;
    }
}