#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO
open Fake.DotNet

// Properties
let buildDir = "./build/"
let testDir  = "./tests/"
let publishDir = "./pubish/"

// Targets
Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning --- "

  CreateProcess.fromRawCommand "dotnet" [ "clean" ]
  |> Proc.run
  |> ignore

  Shell.cleanDirs [buildDir; publishDir]
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building --- "

  let buildParams (defaults:DotNet.BuildOptions) =
    { defaults with
        OutputPath = Some(buildDir)
    }

  DotNet.build buildParams "./Demo.sln"

  //CreateProcess.fromRawCommand "dotnet" [ "build" ]
  //|> Proc.run
  //|> ignore
)

Target.create "Default" (fun _ ->
  Trace.log " --- Default target --- "
)

open Fake.Core.TargetOperators

// Dependencies
"Clean"
  ==> "Build"
  ==> "Default"

// Start Build
Target.runOrDefault "Default"
