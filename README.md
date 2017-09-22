## lastmile-dms2.0-automation
### Introduction
     Repository contains code for last mile automation project in .net framework for DMS 2.0 .New .net solution created   (LM_DMS2.0_UI_Automation) for lastmile dms 2.0 automation.Have added dll of transport-automation-platform(.net framework) as reference in new .net solution. Have included reusable packages as well as packages including files to be edited with respect to our needs , of Brokerage-web-automation solution(used by Brokerage, Freight Optimizer, Carrier Portal, Customer Portal etc. ) in our new solution.  Repository contains scripts for UI automation as well as API test automation.
    
### last updated
  By : Soumya Indira , Infosys Limited.
  Date : 22/09/2017
  
### Pre requisites 

Software needs to be installed 
 
 Please install Visual Studio 2015 or latest version. Please make sure below dotnet packages also installed.
1. Install dotNetCore.1.1
2. Install DotNetCore.1.0.0.RC2-WindowsHosting
3. Install DotNetCore.1.0.1-VS2015Tools.Preview2.0.3 . 

Data setup to be done:

1) Please download folders BUILD_AUTOMATION and AUTOMATION from below Git Repository and directly paste into C drive.
https://github.com/xpologistics/lastmile-dms2.0-testdata.git

### How to run a sample UI test case.

1) Clone/Download the existing source code from the Lastmil-dms2.0-automation repository[Branch Name : develop] to our local machine.
2) Import the Project in Visual studio. 
3) Build/Rebuild the solution.
4) Go to LMDMSPortal --> LMTests --> inside we have a class file with Login.cs .
5) Open Login.cs file and right click on the [Fact] and select runtests.







