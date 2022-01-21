@echo off

call .\src\admin.bat

CLS
ECHO .
ECHO **************************************
ECHO Starting ReWin Batch
ECHO **************************************

:START
setlocal & pushd .

WHERE choco 1>NUL 2>NUL
if '%errorlevel%' == '0' ( goto chocoInstalled ) else ( goto chocoMissing )

:chocoMissing
ECHO .
choice /M "Chocolatey is required to install the necessary programs! Install now?"
IF '%errorlevel%' == '2' exit /B

ECHO .
ECHO **************************************
ECHO Installing Chocolatey
ECHO **************************************

powershell Set-ExecutionPolicy AllSigned
powershell Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))


:chocoInstalled
choco feature enable -n=allowGlobalConfirmation

:: Software install
call .\src\choco.bat

choco feature disable --name=allowGlobalConfirmation

:END