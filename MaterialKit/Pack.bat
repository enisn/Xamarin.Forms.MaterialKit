@echo off
Nuget.exe Update -self
nuget pack MaterialKit.Core.nuspec
pause