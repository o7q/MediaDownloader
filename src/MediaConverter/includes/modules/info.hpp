#pragma once

#include <iostream>
#include "../utils.hpp"
using namespace std;

void module_info();

void module_info()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION + "   [INFO]");
    draw_header();

    cout << "TEMP";

    sys("ps");
    sys("col2"); sys("clr");
}