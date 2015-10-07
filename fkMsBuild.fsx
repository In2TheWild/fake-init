#I "packages/FAKE.4.4.4/tools/"
#r "FakeLib.dll"

open Fake
open Fake.FileSystemHelper
open Fake.MSBuildHelper
open System

let buildMode = getBuildParamOrDefault "buildMode" "Release"
let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            Targets = ["Build"]
            Properties =
                [
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", buildMode
                ]
         }
let sln = @"y:/Source/project/tourism/tourism-report-client/ReportClient.sln"

Target "build" (fun _ ->
        build setParams sln |> DoNothing
    )

RunTargetOrDefault "build"
