#include <iostream>
#include <string>
using namespace std;

void funcSwitch(int func);
// void sys(string cmd, int num);
// void sysExec(string in);
void remux();
string strRep(string charIn, int am);

const string ver = "v1.0.0";

main()
{
    system(("title MediaConverter " + ver).c_str());
    system("color 7");
    cout << "    __  ___       ___      _____                      __         \n"
            "   /  |/  /__ ___/ (_)__ _/ ___/__  ___ _  _____ ____/ /____ ____\n"
            "  / /|_/ / -_) _  / / _ `/ /__/ _ \\/ _ \\ |/ / -_) __/ __/ -_) __/\n"
            " /_/  /_/\\__/\\_,_/_/\\_,_/\\___/\\___/_//_/___/\\__/_/  \\__/\\__/_/   ";
    cout << " " + ver + "\n" + strRep(" ", 66) + "by o7q\n\n+" + strRep("=", 71) + "+\n\n";

    cout << " > SELECT\n  > [1] REMUX\n\n";

    int select;
    cin >> select;

    funcSwitch(select);

    system("pause");
}

void remux()
{
    cout << " > SELECT\n  > VIDEO\n   > [1] mp4\n\n";

    
    cout << "PATH TO INPUT FILE\n";
    string input;
    cin >> input;
    system(("ffmpeg.exe -i " + input + " output.ico").c_str());
    system("pause");
}

void funcSwitch(int func)
{
    switch (func)
    {
        case 1: remux();
    }
}

// void sys(string cmd)
// {
//     string out;
//     if (cmd == "ps") out = "pause";
//     if (cmd == "clr") out = "cls";
//     if (cmd == "col") out = "color " + val;
//     sysExec(out);
// }
// void sysExec(string in)
// {
//     system(in.c_str());
// }

// string repeater function
string strRep(string charIn, int am)
{
    string output;
    for (int i = 0; i < am; i++) output += charIn;
    return output;
}