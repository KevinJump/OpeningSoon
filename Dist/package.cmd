@echo off 

@Echo Packaging
nuget pack ..\Our.Umbraco.OpeningSoon\Jumoo.OpeningSoon.nuspec -build  -OutputDirectory %1 -version %1 -properties "depends=%1;Configuration=release"

XCOPY %1\*.nupkg c:\source\localgit /y