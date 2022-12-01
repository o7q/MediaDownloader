@echo off
set name=MediaConverter
title Compiling %name%
color 7
g++ *.cpp "resources\icon\icon.res" -Wall -O2 -o "%name%.exe" -static-libstdc++ -static-libgcc
title DONE!
echo.
pause