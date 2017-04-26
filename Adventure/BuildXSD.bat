cd bin\Debug
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\xsd.exe" AdventureDataModel.dll /outputdir:..\..\
cd ..\..\
del GameData.xsd
ren schema0.xsd GameData.xsd
pause