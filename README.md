# ExeToService

automatically start executable files upon startup without any delay.

## Preparation

1.  Start CMD with administrator privileges
2.  Execute `sc.exe create FastAutostart binPath= "PATH TO YOUR EXE\ExeAsService.exe" start = auto`

## How To Use

Executables that should be started should be put in the `Startup Fast`-Folder. You can find it by pressing `STRG + R` and launching `%USERPROFILE%\Microsoft\Windows\Start Menu\Programs\Startup Fast`.

## How To Remove

1.  Start CMD with administrator privileges
2.  Execute `SC STOP FastAutostart`
3.  Execute `SC DELETE FastAutostart`
