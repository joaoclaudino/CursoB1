@ECHO OFF

FOR %%i IN (*.sql) DO (
echo "%%i"

ren "%%i" temp.txt
echo. >"%%i"
type temp.txt >>"%%i"
del temp.txt

ren "%%i" temp.txt
echo.go >"%%i"
type temp.txt >>"%%i"
del temp.txt

ren "%%i" temp.txt
echo. >"%%i"
type temp.txt >>"%%i"
del temp.txt

ren "%%i" temp.txt
echo.use SBODemoBR >"%%i"
type temp.txt >>"%%i"
del temp.txt



)