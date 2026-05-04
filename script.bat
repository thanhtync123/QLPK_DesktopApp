@echo off

:: ==============================
:: Cấu hình
:: ==============================
set DB_NAME=clinic_db2
set DB_USER=root
set DB_PASS=123456
set DB_HOST=192.168.1.100
set DB_PORT=3306
set MYSQL_PATH="C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe"

set SOURCE_IMAGE_DIR=D:\DesktopAppShare\images
set BACKUP_DIR=D:\DuLieuUD
set IMAGE_BACKUP_DIR=%BACKUP_DIR%\images
set SQL_BACKUP_DIR=%BACKUP_DIR%\sql

:: ==============================
:: Tạo ngày
:: ==============================
for /f %%i in ('wmic os get localdatetime ^| find "."') do set DTS=%%i
set YYYY=%DTS:~0,4%
set MM=%DTS:~4,2%
set DD=%DTS:~6,2%
set TIMESTAMP=%DD%_%MM%_%YYYY%

set SQL_FILE=%SQL_BACKUP_DIR%\%DB_NAME%_%TIMESTAMP%.sql

:: ==============================
:: Tạo thư mục
:: ==============================
if not exist "%BACKUP_DIR%" mkdir "%BACKUP_DIR%"
if not exist "%IMAGE_BACKUP_DIR%" mkdir "%IMAGE_BACKUP_DIR%"
if not exist "%SQL_BACKUP_DIR%" mkdir "%SQL_BACKUP_DIR%"

echo === [%date% %time%] START BACKUP ===

:: Backup SQL
%MYSQL_PATH% -h%DB_HOST% -P%DB_PORT% -u%DB_USER% -p%DB_PASS% %DB_NAME% > "%SQL_FILE%"

if not exist "%SQL_FILE%" exit /b

:: Backup images
robocopy "%SOURCE_IMAGE_DIR%" "%IMAGE_BACKUP_DIR%" /E /XO /Z /MT:8

echo === BACKUP COMPLETED ===