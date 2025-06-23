# Ⓚ .NET Kustomize CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler-tech/dotnet-kustomize-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler-tech/dotnet-kustomize-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler-tech/dotnet-kustomize-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler-tech/dotnet-kustomize-cli)

A simple .NET library that embeds the Kustomize CLI.

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 or later
- [Kustomize CLI](https://kubectl.docs.kubernetes.io/installation/kustomize/) installed and available in your system's PATH

### Installation

To get started, you can install the package from NuGet.

```bash
dotnet add package DevantlerTech.KustomizeCLI
```

## 📝 Usage

You can execute the Kustomize CLI commands using the `Kustomize` class.

```csharp
using DevantlerTech.KustomizeCLI;

var (exitCode, output) = await Kustomize.RunAsync(["arg1", "arg2"]);
```
