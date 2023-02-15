#dotnet publish -c Release -o:C:\Publish\EpisodeScraper
#dotnet publish -r win-x64 -c Release -o C:\Publish\EpisodeScraper -p:PublishReadyToRun=true -p:PublishSingleFile=true -p:PublishTrimmed=false --self-contained false -p:IncludeNativeLibrariesForSelfExtract=true

$version = '2.0.0'
$project = './EpisodeScraper.csproj'

dotnet build $project -c Release -p:Version=$version
dotnet publish $project -c Release --no-build --output C:/Publish/EpisodeScraper -p:Version=$version --nologo