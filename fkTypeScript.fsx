#I @"packages/FAKE.4.4.4/tools/"
#r @"FakeLib.dll"

open Fake
open System
open TypeScript

Target "CompileTypeScript" (fun _ ->
        !! "src/TypeScript/**/*.ts"
            |> TypeScriptCompiler (fun p ->
                    { p with
                        ECMAScript = ECMAScript.ES5
                        OutputPath = "./build/TypeScript" })
)

RunTargetOrDefault "CompileTypeScript"
