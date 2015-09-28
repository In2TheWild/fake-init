#I "packages/FAKE.4.4.4/tools/"
#r "packages/FAKE.4.4.4/tools/FakeLib.dll"

open Fake

let buildDir = "./build"

Target "Clean" (fun _ -> CleanDir buildDir)
Target "Default" (fun _ -> trace "Hello World from FAKE")

"Clean" ==> "Default"

RunTargetOrDefault "Default"
