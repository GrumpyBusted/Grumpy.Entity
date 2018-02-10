param(
    $installPath, 
    $toolsPath, 
    $package, 
    $project
)

$namespace = $project.Properties.Item("RootNamespace").Value
$projectFolder = Split-Path -Path $project.FullName
$projectName = $project.ProjectName

function Add-ProjectItem($project, $file) {
    $found = $true
    $fileName = Split-Path -Path $file -leaf
    $projectItem = $null

    try {
        $projectItem = $project.ProjectItems.Item($fileName)
    }
    catch {
        $found = $false
    }

    if ($projectItem -eq $null) {
        $found = $false
    }

    $projectFoler = Split-Path -Path $project.FullName -Parent 

    Copy-Item -Path "$file" -Destination $projectFolder

    if ($found -eq $false) {
        $project.ProjectItems.AddFromFile($projectFoler  + "\" + $fileName)
    }
}

foreach ($file in Get-ChildItem -Path "$toolsPath\..\content" -Recurse -Include *.*) {
    Add-ProjectItem -project $project -file $file
}