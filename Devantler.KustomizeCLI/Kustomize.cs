using System.Runtime.InteropServices;
using CliWrap;

namespace Devantler.KustomizeCLI;

/// <summary>
/// A class to run Kustomize CLI commands.
/// </summary>
public static class Kustomize
{
  /// <summary>
  /// The Kustomize CLI command.
  /// </summary>
  public static Command Command => GetCommand();
  internal static Command GetCommand(PlatformID? platformID = default, Architecture? architecture = default, string? runtimeIdentifier = default)
  {
    platformID ??= Environment.OSVersion.Platform;
    architecture ??= RuntimeInformation.ProcessArchitecture;
    runtimeIdentifier ??= RuntimeInformation.RuntimeIdentifier;

    string binary = (platformID, architecture, runtimeIdentifier) switch
    {
      (PlatformID.Unix, Architecture.X64, "osx-x64") => "kustomize-osx-x64",
      (PlatformID.Unix, Architecture.Arm64, "osx-arm64") => "kustomize-osx-arm64",
      (PlatformID.Unix, Architecture.X64, "linux-x64") => "kustomize-linux-x64",
      (PlatformID.Unix, Architecture.Arm64, "linux-arm64") => "kustomize-linux-arm64",
      (PlatformID.Win32NT, Architecture.X64, "win-x64") => "kustomize-win-x64.exe",
      (PlatformID.Win32NT, Architecture.X64, "win-arm64") => "kustomize-win-arm64.exe",
      _ => throw new PlatformNotSupportedException($"Unsupported platform: {Environment.OSVersion.Platform} {RuntimeInformation.ProcessArchitecture}"),
    };
    string binaryPath = Path.Combine(AppContext.BaseDirectory, binary);
    return !File.Exists(binaryPath) ?
      throw new FileNotFoundException($"{binaryPath} not found.") :
      Cli.Wrap(binaryPath);
  }
}
