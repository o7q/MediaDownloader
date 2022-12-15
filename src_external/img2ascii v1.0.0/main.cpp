#include <iostream>
#include <regex>
#include <fstream>
#include <dirent.h>
#include <string>
using namespace std;

const string version = "v1.0.0";

int main()
{
    system("rmdir \"img2ascii\\render_temp\" /s /q 2> nul");

    system(("title img2ascii " + version).c_str());

    cout << "  _            ___             _ _ \n"
            " (_)_ __  __ _|_  )__ _ ___ __(_|_)\n"
            " | | '  \\/ _` |/ // _` (_-</ _| | |\n"
            " |_|_|_|_\\__, /___\\__,_/__/\\__|_|_| " + version + "\n"
            "         |___/                      by o7q\n\n";

    system("mkdir \"img2ascii\\render_temp\" 2> nul");
    system("mkdir \"img2ascii\\render_temp\\raw\" 2> nul");
    system("mkdir \"img2ascii\\render_temp\\rgb\" 2> nul");

    cout << " PROJECT NAME\n -> ";
    string name;
    getline(cin, name);

    cout << "\n MEDIA INPUT PATH (an image or video)\n -> ";
    string path;
    getline(cin, path);
    string path_fix = regex_replace(path, regex("\\\""), "");
    
    cout << "\n FRAME SIZE (WIDTHxHEIGHT, example: 100x50)\n -> ";
    string size;
    getline(cin, size);

    cout << "\n FRAME SKIP RATE (type ! to ignore or if it is an image)\n -> ";
    string fps;
    getline(cin, fps);

    string fps_controller = fps == "!" ? "" : " -r " + fps;

    // read size parameters and split them into width*height
    stringstream sizeData(size);
    string sizeRead;
    vector<std::string> sizeRead_list;
    while (getline(sizeData, sizeRead, 'x')) sizeRead_list.push_back(sizeRead);

    string width = sizeRead_list[0];
    string height = sizeRead_list[1];

    int width_int = stoi(width);
    int height_int = stoi(height);
    int area = width_int * height_int;

    cout << "\n ASCII CHARACTERS (choose a number or enter your own in brightness levels low to high):\n"
            "  [1] ascii (standard ascii special characters only)\n"
            "  [2] upper (uppercase letters only)\n"
            "  [3] lower (lowercase letters only)\n"
            "  [4] both (upper and lowercase letters only)\n"
            "  [5] num (numbers only)\n"
            "  [6] all (all characters, very chaotic)\n"
            " -> ";
    string chars;
    getline(cin, chars);

    // ascii colorspace based on: https://stackoverflow.com/a/74186686
    //  `.-'":_,^=;><+!rc*\/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@
    if(!chars.empty() && chars.find_first_not_of("0123456789"))
    {
        switch(stoi(chars))
        {
            case 1: chars = " `.-'\":_,^=;><+!*\\/?)(|{}[]#$%&@"; break;
            case 2: chars = "LTJFCIZYESPVOGUAKXHRDBMNWQ"; break;
            case 3: chars = "ltjfcizyespvoguakxhrdbmnwq"; break;
            case 4: chars = "rczsLTvJFiCfItluneoZYxjyaESwqkPhdVpOGbUAKXHmRDBgMNWQ"; break;
            case 5: chars = "7315269480"; break;
            case 6: chars = " `.-'\":_,^=;><+!rc*\\/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@"; break;
        }
    }

    // calculate ascii colorspace
    int chars_length = chars.length();
    // split characters string into a char array
    char chars_split[chars_length];
    strcpy(chars_split, chars.c_str());
    // convert the char array into a string array (to fix issues with encoding on file output)
    string asciiChars[chars_length] = {};
    for (int i = 0; i < chars_length; i++) asciiChars[i] = chars_split[i];
    int asciiQuantize = (255 / chars_length) + 1;

    cout << "\n ASCII COMPRESSION (0 - 255, A value of 0 would utilize " + to_string((255 / (asciiQuantize + 0)) + 1) + " characters. A value of 50 would utilize " + to_string((255 / (asciiQuantize + 50)) + 1) + " characters.)\n -> ";
    string asciiQuantize_str;
    getline(cin, asciiQuantize_str);

    asciiQuantize = stoi(asciiQuantize_str) + asciiQuantize;

    system(("mkdir \"" + name + "\" 2> nul").c_str());

    ofstream widthFile;
    widthFile.open("img2ascii\\render_temp\\frame_width");
    widthFile << width;
    widthFile.close();

    ofstream heightFile;
    heightFile.open("img2ascii\\render_temp\\frame_height");
    heightFile << height;
    heightFile.close();

    cout << "\n";
    system(("img2ascii\\ffmpeg.exe -loglevel verbose -i \"" + path_fix + "\" -vf scale=" + width + ":" + height + fps_controller + " \"img2ascii\\render_temp\\raw\\frame.raw.%d.png\"").c_str());

    cout << "\n";
    system("img2ascii\\img2rgb.exe");
    cout << "\n";

    int imgIndex = 1;

    if (auto dir = opendir("img2ascii\\render_temp\\rgb"))
    {
        while (auto f = readdir(dir))
        {
            if (!f->d_name || f->d_name[0] == '.') continue;

            // load rgb frame
            ifstream imgRGB_path("img2ascii\\render_temp\\rgb\\frame.rgb." + to_string(imgIndex) + ".txt");
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
            int rs[128000];
            int gs[128000];
            int bs[128000];
            int readRGB_index = 0;
            for (int i = 0; i < area; i++)
            {
                // split individual rgb values
                stringstream rgbData(pixelRead_list[i]);
                string RGBRead;
                vector<std::string> RGBRead_list;
                while (getline(rgbData, RGBRead, ',')) RGBRead_list.push_back(RGBRead);

                // import rgb values into isolated arrays
                rs[readRGB_index] = stoi(RGBRead_list[0]);
                gs[readRGB_index] = stoi(RGBRead_list[1]);
                bs[readRGB_index] = stoi(RGBRead_list[2]);

                readRGB_index++;
            }

            // convert rgb pixels to ascii characters
            string asciiImage = "";
            int pixelAverage[128000];
            int widthIndex = 0;
            for (int i = 0; i < readRGB_index; i++)
            {
                if (widthIndex == width_int)
                {
                    asciiImage += "\n";
                    widthIndex = 0;
                }
                widthIndex++;

                pixelAverage[i] = (rs[i] + gs[i] + bs[i]) / 3;
                string asciiHalfPixel = asciiChars[pixelAverage[i] / asciiQuantize];
                asciiImage += asciiHalfPixel + asciiHalfPixel;
            }

            // write ascii frame
            cout << " Converting [frame.rgb." + to_string(imgIndex) + ".txt] to ASCII\n";
            ofstream asciiFile;
            asciiFile.open(name + "\\frame.ascii." + to_string(imgIndex) + ".txt");
            asciiFile << asciiImage;
            asciiFile.close();

            imgIndex++;
        }
        closedir(dir);
    }

    cout << "\n RENDER FINISHED!\n DO YOU WANT TO KEEP THE TEMPORARY RENDER FILES? (img2ascii\\render_temp) (Y = yes | anything else = no)\n -> ";
    string keepTempPrompt;
    getline(cin, keepTempPrompt);

    if (!(keepTempPrompt == "Y" || keepTempPrompt == "y")) system("rmdir \"img2ascii\\render_temp\" /s /q 2> nul");

    cout << "\n";
    return 0;
}