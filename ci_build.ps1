#log the runtimes
dnvm list
dnvm install 1.0.0-rc1-update1 -r coreclr -a x86
dnvm install 1.0.0-rc1-update1 -r clr -a x86
dnvm install 1.0.0-rc1-update1 -r coreclr -a x64
dnvm install 1.0.0-rc1-update1 -r clr -a x64
dnvm list
dnvm use 1.0.0-rc1-update1 -a x64 -r coreclr
dnu feeds list
dnu restore

#run the build
& "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" src\GenFu.sln

#tests
dnvm use 1.0.0-rc1-update1 -a x64 -r coreclr
dnx -p tests\GenFu.Tests test -xml xunit-results.xml

# upload results to AppVeyor
$wc = New-Object 'System.Net.WebClient'
$wc.UploadFile("https://ci.appveyor.com/api/testresults/xunit/$($env:APPVEYOR_JOB_ID)", (Resolve-Path .\xunit-results.xml))