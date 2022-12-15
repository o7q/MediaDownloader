from PIL import Image
import os
import sys

fileCount = next(os.walk("img2ascii\\render_temp\\raw"))[2]

nameIndex = 1
for list_item in fileCount:
    framePath = "img2ascii\\render_temp\\raw\\frame.raw." + str(nameIndex) + ".png"

    widthRead = open("img2ascii\\render_temp\\frame_width", "r")
    frameWidth = widthRead.read()
    frameWidth_int = int(frameWidth)
    widthRead.close()

    heightRead = open("img2ascii\\render_temp\\frame_height", "r")
    frameHeight = heightRead.read()
    frameHeight_int = int(frameHeight)
    heightRead.close()

    area = frameWidth_int * frameHeight_int

    x = 0
    y = 0
    rgb_str = ""

    frame = Image.open(framePath).convert('RGB')
    for i in range(area):
        rgb = frame.getpixel((x, y))
        rgb_str += str(rgb[0]) + "," + str(rgb[1]) + "," + str(rgb[2]) + "|"

        x += 1
        if x == frameWidth_int:
            y += 1
            x = 0

    print(" Converting [frame.raw." + str(nameIndex) + ".png] to RGB")
    output_file = open("img2ascii\\render_temp\\rgb\\frame.rgb." + str(nameIndex) + ".txt", "w")
    output_file.write(rgb_str[:-1])
    output_file.close()

    nameIndex += 1

sys.exit(0)