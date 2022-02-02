@echo off 

@Echo Packaging
dotnet pack ..\Our.Umbraco.OpeningSoon\Our.Umbraco.OpeningSoon.csproj  --output %1 --version-suffix %1 --configuration release

XCOPY %1\*.nupkg c:\source\localgit /y