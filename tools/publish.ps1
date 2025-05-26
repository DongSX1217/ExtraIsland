cd .\ExtraIsland
dotnet publish -c Release -p:CreateCipx=true -p:CipxPackageOutputDirectory=../out
cd ..
