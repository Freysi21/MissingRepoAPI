Get-ChildItem "C:\Users\aft01\Projects\TrialProj\API\Models" -Filter *.cs | 
Foreach-Object {
    $scaffoldCmd = 
    'dotnet-aspnet-codegenerator ' + 
    '-p "C:\Users\aft01\Projects\TrialProj\API\API.csproj" ' +
    'controller ' + 
    '-name ' + $_.BaseName + 'Controller ' +
    '-api ' + 
    '-m API.Models.' + $_.BaseName + ' ' +
    '-dc MissingReportsContext ' +
    '-outDir Controllers ' +
    '-namespace API.Controllers'

    # List commands for testing:
    $scaffoldCmd

    # Excute commands (uncomment this line):
    iex $scaffoldCmd
}