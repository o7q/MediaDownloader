#include <iostream>
#include <regex>
#include <fstream>
#include <chrono>
#include <dirent.h>
using namespace std;
using namespace std::chrono;

const string version = "v1.3.0";

int main()
{
    system("mkdir \"img2ascii\" 2> nul");

    system(("title img2ascii " + version).c_str());
    cout << "  _            ___             _ _ \n"
            " (_)_ __  __ _|_  )__ _ ___ __(_|_)\n"
            " | | '  \\/ _` |/ // _` (_-</ _| | |\n"
            " |_|_|_|_\\__, /___\\__,_/__/\\__|_|_| " + version + "\n"
            "         |___/                      by o7q\n\n";

    cout << " PROJECT NAME\n -> ";
    string name;
    getline(cin, name);

    cout << "\n MEDIA INPUT PATH (an image or video)\n -> ";
    string path;
    getline(cin, path);
    string path_fix = regex_replace(path, regex("\\\""), "");
    
    cout << "\n FRAMESIZE (WIDTHxHEIGHT, example: 100x50)\n -> ";
    string size;
    getline(cin, size);

    cout << "\n FRAMERATE (type ! to use the original fps or if it is an image)\n -> ";
    string fps;
    getline(cin, fps);

    if(!(!fps.empty() && fps.find_first_not_of("0123456789")) && fps != "!") fps = "15";
    string fps_controller = fps == "!" ? "" : " -r " + fps;

    // read size parameters and split them into width*height
    stringstream sizeData(size);
    string sizeRead;
    vector<std::string> sizeRead_list;
    while (getline(sizeData, sizeRead, 'x')) sizeRead_list.push_back(sizeRead);

    // process width/height values
    int width = (size.find('x') != string::npos) ? ((!sizeRead_list[0].empty() && sizeRead_list[0].find_first_not_of("0123456789")) ? stoi(sizeRead_list[0]) : 100) : 100;
    int height = (size.find('x') != string::npos) ? ((!sizeRead_list[1].empty() && sizeRead_list[0].find_first_not_of("0123456789")) ? stoi(sizeRead_list[1]) : 50) : 50;

    int area = width * height;

    cout << "\n ASCII CHARACTERS (choose a number or enter your own):\n"
            "  [1] ascii (standard ascii special characters only)\n"
            "  [2] upper (uppercase letters only)\n"
            "  [3] lower (lowercase letters only)\n"
            "  [4] both (upper and lowercase letters only)\n"
            "  [5] num (numbers only)\n"
            "  [6] all (all characters, very chaotic)\n"
            " -> ";
    string chars;
    getline(cin, chars);

    int chars_length = chars.length();

    // ascii colorspace based on: https://stackoverflow.com/a/74186686
    //  `.-'":_,^=;><+!rc*\/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@
    string chars_index = " `.-'\":_,^=;><+!rc*\\/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";

    if (!chars.empty() && chars.find_first_not_of("0123456789"))
    {
        switch(stoi(chars))
        {
            case 1: chars = " `.-'\":_,^=;><+!*\\/?)(|{}[]#$%&@"; break;
            case 2: chars = "LTJFCIZYESPVOGUAKXHRDBMNWQ"; break;
            case 3: chars = "ltjfcizyespvoguakxhrdbmnwq"; break;
            case 4: chars = "rczsLTvJFiCfItluneoZYxjyaESwqkPhdVpOGbUAKXHmRDBgMNWQ"; break;
            case 5: chars = "7315269480"; break;
            case 6: chars = chars_index; break;
        }
    }
    else
    {
        // sort custom characters from darkest to brightest

        // create indexes
        vector<char> char_index_vector(chars_index.begin(), chars_index.end());
        vector<char> chars_vector(chars.begin(), chars.end());
        string chars_temp;
        // sort characters with jamesort™
        for (size_t i = 0; i < chars_index.length(); i++)
            for(int t = 0; t < chars_length; t++)
                if (chars_vector[t] == chars_index[i])
                    chars_temp += chars_vector[t];
        // remove duplicate characters
        chars = "";
        vector<char> chars_sorted_vector(chars_temp.begin(), chars_temp.end());
        for (int i = 0; i < chars_length; i++)
            if (chars_sorted_vector[i] != chars_sorted_vector[i + 1])
                chars += chars_sorted_vector[i];
    }

    chars_length = chars.length();

    // calculate ascii colorspace
    // split characters string into a char array
    char chars_split[chars_length];
    strcpy(chars_split, chars.c_str());
    // convert the char array into a string array (to fix issues with encoding on file output)
    string asciiChars[chars_length] = {};
    for (int i = 0; i < chars_length; i++) asciiChars[i] = chars_split[i];
    int asciiQuantize = (255 / chars_length) + 1;

    cout << "\n ASCII COMPRESSION (0 - 255, A value of 0 would utilize " + to_string((255 / (asciiQuantize + 0)) + 1) + " characters. A value of 25 would utilize " + to_string((255 / (asciiQuantize + 25)) + 1) + " characters.)\n -> ";
    string asciiQuantize_str;
    getline(cin, asciiQuantize_str);

    asciiQuantize = !asciiQuantize_str.empty() && asciiQuantize_str.find_first_not_of("0123456789") ? asciiQuantize + stoi(asciiQuantize_str) : asciiQuantize + 25;

    // START

    // start execution stopwatch
    auto stopwatch_start = high_resolution_clock::now();   

    string data = name + "|" + to_string(width) + "|" + to_string(height);

    ofstream dataFile;
    dataFile.open("img2ascii\\_temp");
    dataFile << data;
    dataFile.close();

    system(("mkdir \"" + name + "\" 2> nul").c_str());
    system(("mkdir \"" + name + "\\_cache\" 2> nul").c_str());
    system(("mkdir \"" + name + "\\_cache\\rgb\" 2> nul").c_str());

    system(("mkdir \"" + name + "\\frames\" 2> nul").c_str());
    system(("mkdir \"" + name + "\\stats\" 2> nul").c_str());

    cout << "\nCONVERTING TO RAW SEQUENCE\n";
    system(("img2ascii\\ffmpeg.exe -loglevel verbose -i \"" + path_fix + "\" -vf scale=" + to_string(width) + ":" + to_string(height) + fps_controller + " \"" + name + "\\_cache\\frame.raw.%d.png\"").c_str());

    cout << "\nCONVERTING TO RGB SEQUENCE\n";
    system("img2ascii\\img2rgb.exe");

    cout << "\nCONVERTING TO ASCII SEQUENCE\n";
    int imgIndex = 1; 
    if (auto dir = opendir((name + "\\_cache\\rgb").c_str()))
    {
        while (auto f = readdir(dir))
        {
            if (!f->d_name || f->d_name[0] == '.') continue;

            // load rgb frame
            ifstream imgRGB_path(name + "\\_cache\\rgb\\frame.rgb." + to_string(imgIndex) + ".txt");
            string line;
            string imgRGB;
            while (getline(imgRGB_path, line))
            {
                imgRGB += line;
                imgRGB.push_back('\n');
            }

            // split rgb values
            stringstream rgbData(imgRGB);
            string pixelRead;
            vector<std::string> pixelRead_list;
            while (getline(rgbData, pixelRead, '|')) pixelRead_list.push_back(pixelRead);

            // process rgb
            int rgb[512000];
            int readRGB_index = 0;
            for (int i = 0; i < area; i++)
            {
                // split individual rgb values
                stringstream rgbData(pixelRead_list[i]);
                string RGBRead;
                vector<std::string> RGBRead_list;
                while (getline(rgbData, RGBRead, '!')) RGBRead_list.push_back(RGBRead);

                // import rgb values into an rgb array
                for (int t = 0; t < 3; t++) rgb[readRGB_index + t] = stoi(RGBRead_list[t]);

                readRGB_index++;
            }

            // convert rgb pixels to ascii characters
            string asciiImage = "";
            int pixelAverage[512000];
            int widthIndex = 0;
            for (int i = 0; i < readRGB_index; i++)
            {
                if (widthIndex == width)
                {
                    asciiImage += "\n";
                    widthIndex = 0;
                }
                widthIndex++;

                pixelAverage[i] = (rgb[i] + rgb[i + 1] + rgb[i + 2]) / 3;
                string asciiHalfPixel = asciiChars[pixelAverage[i] / asciiQuantize];
                asciiImage += asciiHalfPixel + asciiHalfPixel;
            }

            // write ascii frame
            cout << " Converting [frame.rgb." + to_string(imgIndex) + ".txt] to ASCII\n";
            ofstream asciiFile;
            asciiFile.open(name + "\\frames\\frame.ascii." + to_string(imgIndex) + ".txt");
            asciiFile << asciiImage;
            asciiFile.close();

            imgIndex++;
        }
        closedir(dir);
    }

    int fileFrameIndex = 0;
    if (auto dir = opendir((name + "\\frames").c_str()))
    {
        while (auto f = readdir(dir))
        {
            if (!f->d_name || f->d_name[0] == '.') continue;

            fileFrameIndex++;
        }
        closedir(dir);
    }

    // stop execution stopwatch
    auto stopwatch_stop = high_resolution_clock::now();

    // END

    // process stats
    string stats[] =
    {
        to_string((duration_cast<seconds>(stopwatch_stop - stopwatch_start)).count()), "stat_time",
        to_string(fileFrameIndex), "stat_frames",
        to_string(width), "stat_resolution_width",
        to_string(height), "stat_resolution_height",
        fps == "!" ? "Original" : fps, "stat_framerate",
        chars, "stat_characters",
        !asciiQuantize_str.empty() && asciiQuantize_str.find_first_not_of("0123456789") ? asciiQuantize_str : "n/a", "stat_compression_user",
        to_string(asciiQuantize), "stat_compression_quantize",
        to_string(chars.length()), "stat_compression_factor"
    };
    int statsIndex = 0;
    while (size_t(statsIndex) < sizeof(stats) / sizeof(string))
    {
        ofstream writeStats;
        writeStats.open(name + "\\stats\\" + stats[statsIndex + 1]);
        writeStats << stats[statsIndex];
        writeStats.close();
        statsIndex += 2;
    }

    string formattedStats = " - Conversion Time: " + stats[0] + " seconds"
                            "\n - Total Frames: " + stats[2] +
                            "\n - Resolution: " + stats[4] + "x" + stats[6] +
                            "\n - Framerate: " + stats[8] +
                            "\n - Characters: " + stats[10] +
                            "\n - Compression: " + stats[12] + " (quantize: " + stats[14] + ", factor: " + stats[16] + ")";

    ofstream lockFile;
    lockFile.open(name + "\\lock");
    lockFile.close();

    ofstream readmeFile;
    readmeFile.open(name + "\\readme.txt");
    readmeFile << "Hello! Thank you for using my program to make ASCII stuff!\n\n"
                  "Info for this project:\n" +
                  formattedStats +
                  "\n\nWhat each file/folder does:\n"
                  " - _cache: Stores the temporary conversion files (you can delete this if you want)\n"
                  " - frames: This is where the ASCII frames are stored, you can play them with \"asciiPlayer.exe\"\n"
                  " - stats: This stores conversion and config information for the project that is used by \"asciiPlayer.exe\"\n"
                  " - lock: Verifies that this project is genuine and will function properly with \"asciiPlayer.exe\"\n"
                  " - readme.txt: This file!";
    readmeFile.close();

    // display stats
    cout << "\n Conversion Finished!\n" + formattedStats + "\n\n ";
    system("pause");

    system("del \"img2ascii\\_temp\" /f 2> nul");

    return 0;
}