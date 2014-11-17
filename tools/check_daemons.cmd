@echo off
REM Taken from
REM http://waynes-world-it.blogspot.com/2008/07/process-list-with-command-line.html
set DAEMON_NAME=%1
wmic path win32_process Where "CommandLine Like '%%%DAEMON_NAME%%%'" get ExecutablePath,Caption,CommandLine | find "%DAEMON_NAME%" | find "java" >NUL
echo %ERRORLEVEL%