# Ⓚ .NET Kustomize CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler-tech/dotnet-kustomize-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler-tech/dotnet-kustomize-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler-tech/dotnet-kustomize-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler-tech/dotnet-kustomize-cli)

<details>
  <summary>Show/hide folder structure</summary>

<!-- readme-tree start -->
```
.
├── .github
│   └── workflows
├── scripts
├── src
│   └── Devantler.KustomizeCLI
│       └── runtimes
│           ├── linux-arm64
│           │   └── native
│           ├── linux-x64
│           │   └── native
│           ├── osx-arm64
│           │   └── native
│           ├── osx-x64
│           │   └── native
│           ├── win-arm64
│           │   └── native
│           └── win-x64
│               └── native
└── tests
    └── Devantler.KustomizeCLI.Tests
        └── KustomizeTests

22 directories
```
<!-- readme-tree end -->

</details>

A simple .NET library that embeds the Kustomize CLI.

## 🚀 Getting Started

To get started, you can install the package from NuGet.

```bash
dotnet add package Devantler.KustomizeCLI
```

## 📝 Usage

You can execute the Kustomize CLI commands using the `Kustomize` class.

```csharp
using Devantler.KustomizeCLI;

var (exitCode, output) = await Kustomize.RunAsync(["arg1", "arg2"]);
```
