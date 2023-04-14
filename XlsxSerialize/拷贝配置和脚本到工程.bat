@echo off
echo ----------------------------------------
echo copy Json 文件至工程内:Assets/Config目录
xcopy /e/y ..\config\json ..\project\Assets\Resources\Config\
echo ----------------------------------------
echo copy cs文件至工程内:Assets/Scripts/Spawn目录
xcopy /e/y ..\config\cs ..\project\Assets\Scripts\Spawn\
echo ----------------------------------------
pause