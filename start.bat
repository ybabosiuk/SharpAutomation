"%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"  %~dp0SharpAutotests\SharpAutotests.csproj -target:Build

"%~dp0packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" --params=configFileName=ChromeRemoteConfig.xml --labels=All --out=TestResult.txt "--result=TestResult.xml;format=nunit2" "%~dp0SharpAutotests\bin\Debug\SharpAutotests.dll"

%~dp0packages\SpecFlow.2.4.1\tools\specflow.exe nunitexecutionreport --ProjectFile %~dp0SharpAutotests\SharpAutotests.csproj --xmlTestResult TestResult.xml --testOutput TestResult.txt --OutputFile TestResult.html