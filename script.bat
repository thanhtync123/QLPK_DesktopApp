@echo off
:: ==============================
:: Cấu hình
:: ==============================
set DB_NAME=clinic_db2
set DB_USER=root
set DB_PASS=123456
set DB_HOST=192.168.2.100
set DB_PORT=3306
set MYSQL_PATH="C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe"

set PROJECT_IMAGE_DIR=D:\DesktopAppShare\images
set BACKUP_DIR=D:\DuLieuUD
set RETENTION_DAYS=7

:: ==============================
:: Tạo tên file backup theo ngày (dd_mm_yyyy)
:: ==============================
for /f %%i in ('wmic os get localdatetime ^| find "."') do set DTS=%%i
set YYYY=%DTS:~0,4%
set MM=%DTS:~4,2%
set DD=%DTS:~6,2%
set TIMESTAMP=%DD%_%MM%_%YYYY%

set SQL_FILE=%BACKUP_DIR%\%DB_NAME%_%TIMESTAMP%.sql
set ZIP_FILE=%BACKUP_DIR%\backup_%TIMESTAMP%.zip

if not exist "%BACKUP_DIR%" mkdir "%BACKUP_DIR%"

echo === [%date% %time%] Backup start...

:: 1. Dump database ra file tạm
%MYSQL_PATH% -h%DB_HOST% -P%DB_PORT% -u%DB_USER% -p%DB_PASS% %DB_NAME% > "%SQL_FILE%"

:: 2. Nén cả file SQL + thư mục ảnh thành 1 file zip
tar -a -c -f "%ZIP_FILE%" "%SQL_FILE%" "%PROJECT_IMAGE_DIR%"

:: 3. Xoá file SQL tạm
del "%SQL_FILE%"

:: 4. Xóa các file backup cũ hơn N ngày
forfiles /p "%BACKUP_DIR%" /s /m *.zip /d -%RETENTION_DAYS% /c "cmd /c del @path"

echo === Backup completed! File saved at: %ZIP_FILE%
pause
