@echo off

:START
setlocal & pushd .

WHERE choco 1>NUL 2>NUL
if '%errorlevel%' == '0' ( goto chocoInstalled ) else ( goto chocoMissing )

:chocoMissing
ECHO .
choice /M "Chocolatey is required to install the necessary programs! Install now"
IF '%errorlevel%' == '2' goto END

ECHO **************************************
ECHO Installing Chocolatey
ECHO **************************************

:: choco installation commands
powershell Set-ExecutionPolicy AllSigned
powershell Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

:chocoInstalled
choco feature enable -n=allowGlobalConfirmation

:installDefault
choice /M "Install standard user software package"
IF '%errorlevel%' == '2' goto installDev
call .\src\default\default.bat

:installDev
choice /M "Install develop software package"
IF '%errorlevel%' == '2' goto chocoEnd
call .\src\dev\dev.bat

:chocoEnd
choco feature disable --name=allowGlobalConfirmation

:END