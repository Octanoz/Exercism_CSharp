Get-ChildItem -Path . -Recurse -Filter *.csproj | ForEach-Object {
    $content = Get-Content $_.FullName
    $updatedContent = $content -replace '<TargetFramework>.*</TargetFramework>', '<TargetFramework>net9.0</TargetFramework>'
    
    if ($content -ne $updatedContent) {
        Set-Content $_.FullName -Value $updatedContent
        Write-Output "Updated $($_.FullName)"
    }
}