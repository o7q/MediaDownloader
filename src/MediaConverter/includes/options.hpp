#pragma once

#include <iostream>
#include "utils.hpp"
using namespace std;

void options();

void options()
{
    sys("col1");
    sys("title MediaConverter " + OBJECT_STORAGE::ENVIRONMENT::VERSION + "   [OPTIONS]");
    draw_header();

    string optionSelect;
    getline(cin, optionSelect); syncCin();

    sys("col2"); sys("clr");
    if (!isInt(optionSelect)) return;
    switch (stoi(optionSelect))
    {

    }
}