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

foreach ($file in Get-ChildItem -Path "$toolsPath\..\content" -Recurse -Include *.tt) {
    Add-ProjectItem -project $project -file $file
}

$solution = Get-Interface $dte.Solution ([EnvDTE80.Solution2])
$solutionFolder = Split-Path -Path $solution.FullName

Copy-Item -Path "$toolsPath\..\content\PublishDacpac.ps1" -Destination $solutionFolder

$projects = $solution.Projects

$project = $null

for ($i = 1; ($i -le $projects) -and ($project -ne $null).Count; $i++ ) {
    $project = $projects.Item($i)

    if ($project.Name -ne "Scripts") {
        $project = $null
    }
}

if ($project -eq $null) {
    $project = $solution.AddSolutionFolder("Scripts")
}

if ($project -ne $null) {
    $projectItem = $null

    try {
        $projectItem = $project.ProjectItems.Item($fileName)
    }
    catch {
        $projectItem = $null
    }

    if ($projectItem -eq $null) {
        $project.ProjectItems.AddFromFile($solutionFolder + "\PublishDacpac.ps1")
    }
}