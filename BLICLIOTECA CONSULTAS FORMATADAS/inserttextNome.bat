@ECHO OFF

FOR %%i IN (*.sql) DO (
echo "%%i"


ren "%%i" temp.txt
echo."%%i" >"%%i"
type temp.txt >>"%%i"
del temp.txt


)