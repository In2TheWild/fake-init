#I "packages/FAKE.4.4.4/tools/"
#r "FakeLib.dll"

open Fake
open Fake.FscHelper

Target "moduleA.dll" (fun _ ->
  ["src/fsharp/moduleA.fs"]
  |> Fsc (fun p ->
           { p with Output = "./out/moduleA.dll"
                    FscTarget = Library })
)

Target "moduleB.dll" (fun _ ->
  ["src/fsharp/moduleB.fs"]
  |> Fsc (fun p -> { p with
                        Output = "./out/moduleB.dll"
                        FscTarget = Library })
)

Target "main.exe" (fun _ ->
  ["src/fsharp/main.fs"]
  |> Fsc (fun p ->
           { p with
                Output = "./out/main.exe"
                References =
                      [ "./out/moduleA.dll"
                        "./out/moduleB.dll" ] })
)

"moduleA.dll"
    ==> "moduleB.dll"
    ==> "main.exe"

// RunTargetOrDefault "main.exe"

Target "watch" (fun _ ->
        use watcher =
            !! "src/fsharp/*.fs"
            |> WatchChanges (fun changes ->
                tracefn "%A" changes
                Run "main.exe" )
        System.Console.ReadLine() |> ignore 
        watcher.Dispose()
)

RunTargetOrDefault  "watch"
