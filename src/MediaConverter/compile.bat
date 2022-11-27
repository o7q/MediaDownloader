@echo off
color 7
g++ *.cpp "resources\icon\icon.res" -Wall -O2 -o "MediaConverter.exe" -static-libstdc++ -static-libgcc
echo.
pause