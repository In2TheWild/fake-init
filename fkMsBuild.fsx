#I "packages/FAKE.4.4.4/tools/"
#r "FakeLib.dll"

open Fake
open Fake.FileSystemHelper
open Fake.MSBuildHelper
open System
open System.IO

//let sln = @"y:/Source/project/tourism/tourism-report-client/ReportClient.sln"
let sln = @"y:/Source/fake/tourism-web/TourismWeb.sln"
let info = FileInfo(sln)

Target "restore" (fun _ ->
    sln
    |> RestoreMSSolutionPackages (fun p ->
         { p with
             OutputPath = Path.Combine(info.Directory.FullName, "packages")
             Retries = 4 })
 )

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

Target "build" (fun _ ->
        build setParams sln |> DoNothing
    )

RunTargetOrDefault fsi.CommandLineArgs.[1]
