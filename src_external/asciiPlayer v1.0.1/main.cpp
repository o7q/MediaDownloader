#include <iostream>
#include <regex>
#include <ctime>
#include <dirent.h>
#include <windows.h>
#include <fstream>
#include <sstream>
using namespace std;

void playFrames();
void replayPrompt();

const string version = "v1.0.1";

bool persistent = true;
string path_fix;
float tick;

int main()
{
    while(persistent)
    {
        system(("title asciiPlayer " + version).c_str());

        cout << "              _ _ ___ _                   \n"
                "  __ _ ___ __(_|_) _ \\ |__ _ _  _ ___ _ _ \n"
                " / _` (_-</ _| | |  _/ / _` | || / -_) '_|\n"
                " \\__,_/__/\\__|_|_|_| |_\\__,_|\\_, \\___|_|   " + version + "\n"
                "                             |__/          by o7q\n\n";

        cout << " PROJECT FOLDER PATH\n -> ";
        string path;
        getline(cin, path);
        path_fix = regex_replace(path, regex("\\\""), "");

        cout << "\n FRAMERATE\n -> ";
        string framerate;
        getline(cin, framerate);
        // convert fps to chrono
        tick = float(1) / stoi(framerate);
        tick *= CLOCKS_PER_SEC;

        playFrames();
    }

    return 0;
}

void playFrames()
{
    system("cls");

    int frameIndex = 1;
    if (auto dir = opendir(path_fix.c_str()))
    {
        while (auto f = readdir(dir))
        {
            if (!f->d_name || f->d_name[0] == '.') continue;

            // flush previous frame
            HANDLE oHandle;
            COORD pos;
            oHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            pos.X = 0;
            pos.Y = 0;
            SetConsoleCursorPosition(oHandle, pos);
            // draw current frame
            ifstream frame_read(path_fix + "\\frame.ascii." + to_string(frameIndex) + ".txt");
            string frame_buffer((istreambuf_iterator<char>(frame_read)), istreambuf_iterator<char>());
            printf((frame_buffer + "\n[FRAME " + to_string(frameIndex) + "]").c_str());

            clock_t now = clock();
            while (clock() - now < tick);

            frameIndex++;
        }
        closedir(dir);
    }

    replayPrompt();
}

void replayPrompt()
{
        cout << "\n\n REPLAY? (Y = same video | U = new video | anything else = quit)\n -> ";
        string prompt;
        getline(cin, prompt);

        system("cls");
        if (prompt == "Y" || prompt == "y") playFrames();
        if (!(prompt == "Y" || prompt == "y") && !(prompt == "U" || prompt == "u")) persistent = false;
}