#pragma once

#include <iostream>
#include <string>
#include <regex>
#include "objectStorage.hpp"
#include "color/color.hpp"
using namespace std;

void sys(string input);
string getFileInfo(string rawPath, bool computePath);
string getFileInfo_cut(string rawFile);
string repeatChar(string character, int length);
bool isInt(string input);
void syncCin();
// draw functions
void draw_cursor();
string draw_array(string array[], int from, int to, string charInsert, bool doCount);
void draw_header();
void draw_spacer();

// system cmd function
void sys(string input)
{
    string cmds[] =
    {
        "ps", "pause",
        "clr", "cls",
        "col1", "color 7",
        "col2", "color 8"
    };
    int cmds_size = sizeof(cmds) / sizeof(string);
    int cmds_index = 0;
    for (int i = 0; i < cmds_size; i++) { if (input == cmds[i]) { system(cmds[i + 1].c_str()); return; } cmds_index++; }
    if (cmds_index == cmds_size) system(input.c_str());
}

// get file info function
string getFileInfo(string rawPath, bool computePath)
{
    if (computePath) return '"' + getFileInfo_cut(rawPath) + '"';
    else
    {
        string file = getFileInfo_cut(rawPath.substr(rawPath.find_last_of("/\\") + 1));
        size_t file_lastIndex = file.find_last_of("."); 
        return file.substr(0, file_lastIndex); 
    }
}
string getFileInfo_cut(string rawFile)
{
    return regex_replace(rawFile, regex("\\\""), "");
}

// string character function
string repeatChar(string character, int length)
{
    string output;
    for (int i = 0; i < length; i++) output += character;
    return output;
}

// is integer function
bool isInt(string input)
{
    return !input.empty() && input.find_first_not_of("0123456789");
}

// cin clear function
void syncCin()
{
    cin.clear(); cin.sync();
}

void draw_cursor()
{
    cout << dye::light_yellow(" -> ");
}

// draw array function
string draw_array(string array[], int from, int to, string charInsert, bool doCount)
{
    string output;
    for (int i = from - 1; i < to; i++)
    {
        output += charInsert + array[i] + "\n";
        if (doCount) output = regex_replace(output, regex("\\#"), to_string(i + 1));
    }
    return output;
}

// draw header function
void draw_header()
{
    cout << dye::light_green("    __  ___       ___      _____                      __         \n"
                              "   /  |/  /__ ___/ (_)__ _/ ___/__  ___ _  _____ ____/ /____ ____\n"
                              "  / /|_/ / -_) _  / / _ `/ /__/ _ \\/ _ \\ |/ / -_) __/ __/ -_) __/\n"
                              " /_/  /_/\\__/\\_,_/_/\\_,_/\\___/\\___/_//_/___/\\__/_/  \\__/\\__/_/   ")
         << " " + dye::light_green(OBJECT_STORAGE::ENVIRONMENT::VERSION) + "\n" + repeatChar(" ", 66) + dye::green("by o7q\n");
    draw_spacer();
}

// draw spacer function
void draw_spacer()
{
    cout << dye::grey("\n+" + repeatChar("=", 71) + "+\n\n");
}