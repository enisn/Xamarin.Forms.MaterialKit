@echo off
Nuget.exe Update -self
nuget pack MaterialKit.Backdrop.nuspec
pause