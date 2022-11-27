#include <iostream>

using namespace std;

string strRep(string character, int amount);

const string ver = "v1.0.0";

main()
{
    system(("title MediaConverter " + ver).c_str());
    cout << "    __  ___       ___      _____                      __         \n"
            "   /  |/  /__ ___/ (_)__ _/ ___/__  ___ _  _____ ____/ /____ ____\n"
            "  / /|_/ / -_) _  / / _ `/ /__/ _ \\/ _ \\ |/ / -_) __/ __/ -_) __/\n"
            " /_/  /_/\\__/\\_,_/_/\\_,_/\\___/\\___/_//_/___/\\__/_/  \\__/\\__/_/   ";
    cout << " " + ver + "\n" + strRep(" ", 66) + "by o7q\n\n";
    system("pause");
}

// string repeater function
string strRep(string character, int amount)
{
    string output;
    for (int i = 0; i < amount; i++) output += character;
    return output;
}