@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Mysql\bin\Release\Panosen.CodeDom.Mysql.*.nupkg D:\LocalSavoryNuget\

move /Y Panosen.CodeDom.Mysql.Engine\bin\Release\Panosen.CodeDom.Mysql.Engine.*.nupkg D:\LocalSavoryNuget\

pause