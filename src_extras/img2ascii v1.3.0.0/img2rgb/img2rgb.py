from PIL import Image
import os
import sys

version = "v1.1.0"

dataRead = open("img2ascii\\_temp", "r")
data_raw = dataRead.read()
dataRead.close()

data = data_raw.split("|")

fileCount = next(os.walk(data[0] + "\\_cache"))[2]

nameIndex = 1
for list_item in fileCount:
    framePath = data[0] + "\\_cache\\frame.raw." + str(nameIndex) + ".png"

    frameWidth_int, frameHeight_int = int(data[1]), int(data[2])
    area, x, y, rgb_str = frameWidth_int * frameHeight_int, 0, 0, ""

    frame = Image.open(framePath).convert('RGB')
    for i in range(area):
        rgb = frame.getpixel((x, y))
        rgb_str += str(rgb[0]) + "!" + str(rgb[1]) + "!" + str(rgb[2]) + "|"

        x += 1
        if x == frameWidth_int:
            y += 1
            x = 0

    print(" Converting [frame.raw." + str(nameIndex) + ".png] to RGB")
    output_file = open(data[0] + "\\_cache\\rgb\\frame.rgb." + str(nameIndex) + ".txt", "w")
    output_file.write(rgb_str[:-1])
    output_file.close()

    nameIndex += 1

sys.exit(0)