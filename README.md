# Skeleton Project

## Prerequisites

To build this project, you need the following:

- DotNet SDK 5.0
- Fake

## Folders

- `src` - source code for projects
- `tests` - tests for projects found in `src`
- `docs` - documentation
- `build` - build output
- `publish` - package output

## Build

### Use the Fake script

Execute the following command to build the project

```sh
fake run
```

The first time you run this, `fake` will download dependencies listed in the `build.fsx` script. If you modify the script in a way that changes the dependencies, then you need to delete the `build.fsx.lock` file and execute `fake run` to regenerate the Intellisense.

https://stackoverflow.com/questions/66665009/fix-for-package-manager-key-paket-was-not-registered-in-build-fsx

[Paver](https://github.com/paver/paver/)
[Invoke](http://docs.pyinvoke.org/en/latest/)


## Creating the project

```
dotnet new classlib -lang "F#" -o src/Demo
dotnet new console -lang "F#" -o src/Demo.Cli
dotnet new nunit -lang "F#" -o tests/Demo.Tests
dotnet new nunit -lang "F#" -o tests/Demo.Cli.Tests

dotnet add src/Demo.Cli/Demo.Cli.fsproj reference src/Demo/Demo.fsproj
dotnet add tests/Demo.Tests/Demo.Tests.fsproj reference src/Demo/Demo.fsproj
dotnet add tests/Demo.Cli.Tests/Demo.Cli.Tests.fsproj reference src/Demo.Cli/Demo.Cli.fsproj

dotnet new sln -o . -n Demo
dotnet sln add src/Demo/Demo.fsproj
dotnet sln add src/Demo.Cli/Demo.Cli.fsproj
dotnet sln add tests/Demo.Tests/Demo.Tests.fsproj
dotnet sln add tests/Demo.Cli.Tests/Demo.Cli.Tests.fsproj
```