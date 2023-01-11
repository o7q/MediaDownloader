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
string strRep(string charIn, int amount);

const string version = "v1.1.2";

bool persistent = true;
string path_fix;
string stats[] =
{
    "time",
    "frames",
    "resolution_width",
    "resolution_height",
    "framerate",
    "characters",
    "compression_user",
    "compression_quantize",
    "compression_factor"
};
string statsStore[sizeof(stats) / sizeof(string)];
int framerate;
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
        string path_stats = path_fix + "\\stats\\stat_";

        // LOAD STATS
        for(size_t i = 0; i < sizeof(stats) / sizeof(string); i++)
        {
            ifstream stats_read(path_stats + stats[i]);
            string stat((istreambuf_iterator<char>(stats_read)), istreambuf_iterator<char>());
            statsStore[i] = stat;
        }

        cout << "\n Project Loaded!"
         // "\n - Time Taken: " + statsStore[0] + " seconds"
            "\n - Total Frames: " + statsStore[1] +
            "\n - Resolution: " + statsStore[2] + "x" + statsStore[3] +
            "\n - Framerate: " + statsStore[4] +
            "\n - Characters: " + statsStore[5] +
            "\n - Compression: " + statsStore[6] + " (quantize: " + statsStore[7] + ", factor: " + statsStore[8] + ")";
        cout << "\n";

        cout << "\n PLAYBACK FRAMERATE\n -> ";
        string framerate_str;
        getline(cin, framerate_str);
        framerate = !framerate_str.empty() && framerate_str.find_first_not_of("0123456789") ? stoi(framerate_str) : !statsStore[4].empty() && statsStore[4].find_first_not_of("0123456789") ? stoi(statsStore[4]) : 15;
        // convert fps to chrono
        tick = float(1) / framerate;
        tick *= CLOCKS_PER_SEC;

        playFrames();
    }

    return 0;
}

void playFrames()
{
    system("cls");

    int frameIndex = 1;
    if (auto dir = opendir((path_fix + "\\frames").c_str()))
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
            ifstream frame_read(path_fix + "\\frames\\frame.ascii." + to_string(frameIndex) + ".txt");
            string frame_buffer((istreambuf_iterator<char>(frame_read)), istreambuf_iterator<char>());
            string displayStats = "FRAMESIZE: " + statsStore[2] + "x" + statsStore[3] + "  |  FRAMERATE: " + to_string(framerate) + " ";
            string frameStats = "[FRAME " + to_string(frameIndex) + " / " + statsStore[1] + "]";
            printf((frame_buffer + "\n" + displayStats + strRep(" ", (stoi(statsStore[2]) * 2) - (displayStats.length() + frameStats.length())) + frameStats).c_str());

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

// string repeater function
string strRep(string charIn, int amount)
{
    string output;
    for (int i = 0; i < amount; i++) output += charIn;
    return output;
}