#pragma once

#include <iostream>
#include "utils.hpp"
#include "modules/remux.hpp"
using namespace std;

void modInit();

void modInit()
{
    sys("col1");
    system(("title MediaConverter " + ver).c_str());
    drawHead();

    cout << " SELECT AN OPTION\n"
            "  > [1] REMUX\n"
            "  > [2] COMPRESS\n"
            "  > [3] RESIZE\n";
    cout << " -> ";

    string s;
    getline(cin, s); cc();

    if (!isInt(s)) _Exit(0);

    sys("col2"); sys("clr"); 
    switch (stoi(s))
    {
        case 1: remux(); break;
    }
}