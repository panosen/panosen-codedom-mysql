@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Mysql\bin\Release\Panosen.CodeDom.Mysql.*.nupkg D:\LocalSavoryNuget\

pause