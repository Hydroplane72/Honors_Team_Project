
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26430.4
MinimumVisualStudioVersion = 10.0.40219.1
Project("{E24C65DC-7377-472B-9ABA-BC803B73C61A}") = "qdsgames.com(1)", ".", "{C8A9DE2C-0851-4D70-A2D6-C002B817B389}"
	ProjectSection(WebsiteProperties) = preProject
		TargetFrameworkMoniker = ".NETFramework,Version%3Dv4.0"
		Debug.AspNetCompiler.VirtualPath = "/localhost_59769"
		Debug.AspNetCompiler.PhysicalPath = "D:\DMACC\Honors Folder\Honors_Project\Github-Repos\qdsgames.com\"
		Debug.AspNetCompiler.TargetPath = "PrecompiledWeb\localhost_59769\"
		Debug.AspNetCompiler.Updateable = "true"
		Debug.AspNetCompiler.ForceOverwrite = "true"
		Debug.AspNetCompiler.FixedNames = "false"
		Debug.AspNetCompiler.Debug = "True"
		Release.AspNetCompiler.VirtualPath = "/localhost_59769"
		Release.AspNetCompiler.PhysicalPath = "D:\DMACC\Honors Folder\Honors_Project\Github-Repos\qdsgames.com\"
		Release.AspNetCompiler.TargetPath = "PrecompiledWeb\localhost_59769\"
		Release.AspNetCompiler.Updateable = "true"
		Release.AspNetCompiler.ForceOverwrite = "true"
		Release.AspNetCompiler.FixedNames = "false"
		Release.AspNetCompiler.Debug = "False"
		VWDPort = "59769"
	EndProjectSection
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{C8A9DE2C-0851-4D70-A2D6-C002B817B389}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{C8A9DE2C-0851-4D70-A2D6-C002B817B389}.Debug|Any CPU.Build.0 = Debug|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
