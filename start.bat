"%~dp0\packages\NUnit.ConsoleRunner.3.8.0\tools\nunit3-console.exe" --labels=All --out=TestResult.txt "--result=TestResult.xml;format=nunit2" "%~dp0\SharpAutotests\bin\Debug\SharpAutotests.dll"

%~dp0\packages\SpecFlow.2.3.1\tools\specflow.exe nunitexecutionreport %~dp0\SharpAutotests\SharpAutotests.csproj /out:MyResult.html