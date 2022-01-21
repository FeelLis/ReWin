@echo off

:::::::::::::::::::::::::::::::::::::::::
:: Automatically check & get admin rights
:::::::::::::::::::::::::::::::::::::::::
: -------------------------------------
REM  -- Check for permissions.
    IF "%PROCESSOR_ARCHITECTURE%" EQU "amd64" (
>nul 2>&1 "%SYSTEMROOT%\SysWOW64\cacls.exe" "%SYSTEMROOT%\SysWOW64\config\system"
) ELSE (
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
)

REM -- If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params= %*
    echo UAC.ShellExecute "cmd.exe", "/c ""%~s0"" %params:"=""%", "", "runas", 1 >> "%temp%\getadmin.vbs"

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
    pushd "%CD%"
    CD /D "%~dp0"
: --------------------------------------

CLS
ECHO .
ECHO **************************************
ECHO Starting Chocolatey Batch
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

:installStandard
choice /M "Install standard user software package?"
IF '%errorlevel%' == '2' goto installDev
call .\standard\standard.bat

:installDev
choice /M "Install dev software package?"
IF '%errorlevel%' == '2' goto END
call .\dev\dev.bat

:END
choco feature disable --name=allowGlobalConfirmation