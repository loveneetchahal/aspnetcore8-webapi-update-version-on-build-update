# Path to version.txt file
$versionFile = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)\version.txt"

# Read current version
$currentVersion = Get-Content $versionFile

# Parse the version components
$major = 0
$minor = 0
$patch = 0
$revision = 0

if ($currentVersion -match '(\d+)\.(\d+)\.(\d+)\.(\d+)') {
    $major = [int]$matches[1]
    $minor = [int]$matches[2]
    $patch = [int]$matches[3]
    $revision = [int]$matches[4]
}

# Increment revision number
$revision++

# Format the new version
$newVersion = "$major.$minor.$patch.$revision"

# Write new version to version.txt
$newVersion | Set-Content $versionFile -Force

# Output the new version (optional, for debugging)
Write-Output "New version: $newVersion"
