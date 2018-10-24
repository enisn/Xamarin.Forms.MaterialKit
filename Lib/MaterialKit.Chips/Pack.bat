@echo off
Nuget.exe Update -self
nuget pack MaterialKit.Chips.nuspec
pause