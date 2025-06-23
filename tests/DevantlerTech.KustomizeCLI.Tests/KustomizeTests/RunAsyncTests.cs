namespace DevantlerTech.KustomizeCLI.Tests.KustomizeTests;

/// <summary>
/// Tests for the RunAsync method.
/// </summary>
public class RunAsyncTests
{
  /// <summary>
  /// Tests that the binary can return the version of the kustomize CLI command.
  /// </summary>
  /// <returns></returns>
  [Fact]
  public async Task RunAsync_Version_ReturnsVersion()
  {
    // Act
    var (exitCode, output) = await Kustomize.RunAsync(["version"]);

    // Assert
    Assert.Equal(0, exitCode);
    Assert.Matches($"v\\d+\\.\\d+\\.\\d+", output);
  }
}
