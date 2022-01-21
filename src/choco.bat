@echo off
call .\admin.bat

:installDefault
choice /M "Install standard user software package?"
IF '%errorlevel%' == '2' goto installDev
call .\default\default.bat

:installDev
choice /M "Install dev software package?"
IF '%errorlevel%' == '2' goto END
call .\dev\dev.bat