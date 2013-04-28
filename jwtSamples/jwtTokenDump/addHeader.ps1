param($target = ".", $companyname = "KPMG")
$header = "//-----------------------------------------------------------------------
// <copyright file=""{0}"" company=""{1}"">
//     Copyright (c) {1}. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------`r`n"

function Write-Header ($file) {
    $content = Get-Content $file

    $hasComments = $content.StartsWith("//------")

    if (-not $hasComments )
    { 
        $filename = Split-Path -Leaf $file
        $fileheader = $header -f $filename,$companyname
        Set-Content $file $fileheader
        Add-Content $file $content
    }
}


Get-ChildItem $target -Recurse | ? { $_.Extension -like ".cs" } | % {
    Write-Header $_.PSPath.Split(":",3)[2]
}