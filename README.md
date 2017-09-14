# lastmile-dms2.0-automation
Last mile automation project in .net framework for DMS 2.0

What we have done to setup/Resuse the existing framework?

-	Created a new GIT repository named lastmile-dms2.0-automation for storing  .net automation framework and test script code.
-	New .net solution created (LM_DMS2.0_UI_Automation) for lastmile dms 2.0 automation.
-	Have added dll of transport-automation-platform(.net framework) as reference in new .net solution.
-	Have included reusable packages as well as packages including files to be edited with respect to our needs , of Brokerage-web-automation solution(used by Brokerage, Freight Optimizer, Carrier Portal, Customer Portal etc. ) in our new solution.
-	Have created a sample test script for Login action scenario of DMS 1.0 Login page and script executed.

Software needs to be installed -
 Please install Visual Studio 2015 or latest version. Please make sure below dotnet packages also installed.
1. Install dotNetCore.1.1
2. Install DotNetCore.1.0.0.RC2-WindowsHosting
3. Install DotNetCore.1.0.1-VS2015Tools.Preview2.0.3


Basic steps to be done for script execution?

1) we have to clone/Download the existing source code from the Lastmil-dns2.0-automation repository to our local machine
2) Import the Project in Visual studio 
3) Build/Rebuild the solution
4) Go to LMDMSPortal --> LMTests --> inside we have a class file with Login.cs
5) Open Login.cs file and right click on the [Fact] and select runtests.

Data setup to be done:

1) Please download the build_automation folder from the Git Repository and Paste it in the C the Folder with same Naming conversion.



