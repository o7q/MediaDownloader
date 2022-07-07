#include <iostream>
#include "windows.h"

int main()
{
    try
    {
        std::system("mediadownloader.bat");
        system("pause");
    }
    catch(const std::exception& e)
    {
        std::cerr << e.what() << '\n';
    }
}