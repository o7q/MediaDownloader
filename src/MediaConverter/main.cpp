#include <iostream>
#include <direct.h>
#include <fstream>
#include "includes/objectStorage.hpp"
#include "includes/moduleManager.hpp"
using namespace std;

main()
{
    _mkdir("mediaconverter");

    // get the path of the executable
    // return the handle of the exe and use GetModuleFileName() with module handle to get the path
    char exePath[MAX_PATH]; 
    HMODULE hModule = GetModuleHandle(NULL);
    if (hModule != NULL) GetModuleFileName(hModule, exePath, (sizeof(exePath))); 

    string exePath_string = exePath;
    OBJECT_STORAGE::ENVIRONMENT::ROOT_PATH = exePath_string.substr(0, exePath_string.find_last_of("\\/"));
    OBJECT_STORAGE::ENVIRONMENT::MAIN_PATH = OBJECT_STORAGE::ENVIRONMENT::ROOT_PATH + "\\mediaconverter";

    OBJECT_STORAGE::ENVIRONMENT::PERSISTENT = true;
    while (OBJECT_STORAGE::ENVIRONMENT::PERSISTENT) moduleInit();
    return 0;
}