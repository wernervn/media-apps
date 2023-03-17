$app_version = Get-Content '../AppVersion.txt'
$version = $app_version[0]
$project = './FolderCleaner.csproj'

dotnet build $project -c Release -p:Version=$version
dotnet publish $project -c Release --no-build --output C:/Publish/FolderCleaner -p:Version=$version --nologo