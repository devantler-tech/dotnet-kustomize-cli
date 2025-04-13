using System.Runtime.InteropServices;
using CliWrap;
using CliWrap.Buffered;

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
      (PlatformID.Win32NT, Architecture.Arm64, "win-arm64") => "kustomize-win-arm64.exe",
      _ => throw new PlatformNotSupportedException($"Unsupported platform: {Environment.OSVersion.Platform} {RuntimeInformation.ProcessArchitecture}"),
    };
    string binaryPath = Path.Combine(AppContext.BaseDirectory, binary);
    if (!File.Exists(binaryPath))
    {
      throw new FileNotFoundException($"{binaryPath} not found.");
    }
    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
      File.SetUnixFileMode(binaryPath, UnixFileMode.UserExecute | UnixFileMode.GroupExecute | UnixFileMode.OtherExecute);
    }
    return Cli.Wrap(binaryPath);
  }

  /// <summary>
  /// Runs the kustomize CLI command with the given arguments.
  /// </summary>
  /// <param name="arguments"></param>
  /// <param name="validation"></param>
  /// <param name="silent"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public static async Task<(int ExitCode, string Message)> RunAsync(
    string[] arguments,
    CommandResultValidation validation = CommandResultValidation.ZeroExitCode,
    bool silent = false,
    CancellationToken cancellationToken = default)
  {
    using var stdOutConsole = silent ? Stream.Null : Console.OpenStandardOutput();
    using var stdErrConsole = silent ? Stream.Null : Console.OpenStandardError();
    var command = Command.WithArguments(arguments)
      .WithValidation(validation)
      .WithStandardOutputPipe(PipeTarget.ToStream(stdOutConsole))
      .WithStandardErrorPipe(PipeTarget.ToStream(stdErrConsole));
    var result = await command.ExecuteBufferedAsync(cancellationToken);
    return (result.ExitCode, result.StandardOutput.ToString() + result.StandardError.ToString());
  }
}
