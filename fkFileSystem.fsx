#I "packages/FAKE.4.4.4/tools/"
#r "FakeLib.dll"

open Fake
open Fake.FileSystemHelper
open System

Target "exist" (fun _ ->
        let exist = ["./fkHello.fsx"] |> allFilesExist
        Console.WriteLine exist
    )

Target "find" (fun _ ->
        let file = "*.fsx"
        let rs = TryFindFirstMatchingFile file "./"
        Console.WriteLine rs.Value
    )

let arg = fsi.CommandLineArgs.[1]
RunTargetOrDefault arg