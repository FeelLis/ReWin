@echo off

:: Nice git UI from GitHub
choco install github-desktop

:: Normal notepad
choco install notepadplusplus

:: Visual Studio Code
choco install vscode

:: Useful Sysinternals
choco install procexp
choco install procmon
choco install autoruns

:: Net tools
:NetTools
choice /M "Install net tools (fiddler, wiresharl, etc.) ?"
IF '%errorlevel%' == '2' goto END
choco install fiddler
choco install wireshark
choco install putty.install
 
:END
ECHO .
ECHO "Dev install script finished"
ECHO .