msbuild.exe %~dp0SharpAutotests.sln -target:NotInSlnfolder:Rebuild;NewFolder\InSolutionFolder:Clean

set CONFIGTOUSE="ChromeRemoteConfig.xml"

"%~dp0packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" --labels=All --out=TestResult.txt "--result=TestResult.xml;format=nunit2" "%~dp0SharpAutotests\bin\Debug\SharpAutotests.dll"

%~dp0packages\SpecFlow.2.4.1\tools\specflow.exe nunitexecutionreport --ProjectFile %~dp0SharpAutotests\SharpAutotests.csproj --xmlTestResult TestResult.xml --testOutput TestResult.txt --OutputFile TestResult.html