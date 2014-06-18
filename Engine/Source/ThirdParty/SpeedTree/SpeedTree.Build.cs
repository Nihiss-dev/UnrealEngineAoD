﻿// Copyright 1998-2011 Epic Games, Inc. All Rights Reserved.
using UnrealBuildTool;
using System.IO;

public class SpeedTree : ModuleRules
{
	public SpeedTree(TargetInfo Target)
	{
		Type = ModuleType.External;

		var bPlatformAllowed = ((Target.Platform == UnrealTargetPlatform.Win32) ||
								(Target.Platform == UnrealTargetPlatform.Win64) ||
								(Target.Platform == UnrealTargetPlatform.Mac));

		if (bPlatformAllowed &&
			UEBuildConfiguration.bCompileSpeedTree)
		{
			Definitions.Add("WITH_SPEEDTREE=1");
			Definitions.Add("SPEEDTREE_KEY=INSERT_KEY_HERE");

			string SpeedTreePath = UEBuildConfiguration.UEThirdPartySourceDirectory + "SpeedTree/SpeedTree-v7.0/";
			PublicIncludePaths.Add(SpeedTreePath + "Include");

			if (Target.Platform == UnrealTargetPlatform.Win64)
			{
				if (WindowsPlatform.Compiler == WindowsCompiler.VisualStudio2013)
				{
					PublicLibraryPaths.Add(SpeedTreePath + "Lib/Windows/VC12.x64");

					if (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT)
					{
						PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC12_MTDLL64_Static_d.lib");
					}
					else
					{
						PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC12_MTDLL64_Static.lib");
					}
				}
				else if (WindowsPlatform.Compiler == WindowsCompiler.VisualStudio2012)
				{
					PublicLibraryPaths.Add(SpeedTreePath + "Lib/Windows/VC11.x64");

					if (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT)
					{
						PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC11_MTDLL64_Static_d.lib");
					}
					else
					{
						PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC11_MTDLL64_Static.lib");
					}
				}
			}
			else if (Target.Platform == UnrealTargetPlatform.Win32)
			{
				if (WindowsPlatform.Compiler == WindowsCompiler.VisualStudio2013)
				{
					PublicLibraryPaths.Add(SpeedTreePath + "Lib/Windows/VC12");

					if (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT)
					{
                        PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC12_MTDLL_Static_d.lib");
					}
					else
					{
                        PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC12_MTDLL_Static.lib");
					}
				}
				else if (WindowsPlatform.Compiler == WindowsCompiler.VisualStudio2012)
				{
					PublicLibraryPaths.Add(SpeedTreePath + "Lib/Windows/VC11");

					if (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT)
					{
                        PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC11_MTDLL_Static_d.lib");
					}
					else
					{
                        PublicAdditionalLibraries.Add("SpeedTreeCore_Windows_v7.0_VC11_MTDLL_Static.lib");
					}
				}
			}
			else if (Target.Platform == UnrealTargetPlatform.Mac)
			{
				PublicLibraryPaths.Add(SpeedTreePath + "Lib/MacOSX");
				if (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT)
				{
					PublicAdditionalLibraries.Add(SpeedTreePath + "Lib/MacOSX/Debug/libSpeedTreeCore.a");
				}
				else
				{
					PublicAdditionalLibraries.Add(SpeedTreePath + "Lib/MacOSX/Release/libSpeedTreeCore.a");
				}
			}
		}
	}
}

