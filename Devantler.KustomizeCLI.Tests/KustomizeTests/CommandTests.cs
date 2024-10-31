using Devantler.CLIRunner;

namespace Devantler.KustomizeCLI.Tests.KustomizeTests;

/// <summary>
/// Tests for the <see cref="Kustomize.Command"/> attribute.
/// </summary>
public class CommandTests
{

  /// <summary>
  /// Test to verify that the command returns a <see cref="PlatformNotSupportedException"/> when the platform is not supported.
  /// </summary>
  [Fact]
  public void Command_GivenValidArguments_Succeeds()
  {
    // Arrange
    var cmd = Kustomize.Command.WithArguments("version");

    // Act
    async void Act() => await CLI.RunAsync(cmd).ConfigureAwait(false);

    // Assert
    Act();
  }
}
