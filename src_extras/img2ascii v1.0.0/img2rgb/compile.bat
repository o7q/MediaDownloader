@echo off
set name=img2rgb
title Compiling %name%
color 7
pyinstaller %name%.py --onefile --icon="resources\icon\icon.ico"
title DONE!
echo.
pause