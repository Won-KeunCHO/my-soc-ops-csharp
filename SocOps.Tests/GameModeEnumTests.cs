using SocOps.Models;

namespace SocOps.Tests;

/// <summary>
/// Tests that GameMode enum exists with the correct values.
/// These tests fail until GameMode is added to SocOps/Models/GameState.cs.
/// </summary>
public class GameModeEnumTests
{
    [Fact]
    public void GameMode_Bingo_ValueExists()
    {
        var mode = GameMode.Bingo;
        Assert.Equal(GameMode.Bingo, mode);
    }

    [Fact]
    public void GameMode_ScavengerHunt_ValueExists()
    {
        var mode = GameMode.ScavengerHunt;
        Assert.Equal(GameMode.ScavengerHunt, mode);
    }

    [Fact]
    public void GameMode_HasExactlyTwoValues()
    {
        var values = Enum.GetValues<GameMode>();
        Assert.Equal(2, values.Length);
    }

    [Fact]
    public void GameMode_BingoIsDefault()
    {
        // Bingo = 0 so pre-existing stored data that lacks GameMode defaults to Bingo
        Assert.Equal(0, (int)GameMode.Bingo);
    }

    [Fact]
    public void GameMode_ScavengerHuntIsOne()
    {
        Assert.Equal(1, (int)GameMode.ScavengerHunt);
    }

    /// <summary>
    /// GameState must gain a ScavengerHunt value for the routing branch in Home.razor.
    /// Fails until GameState.ScavengerHunt is added alongside the existing Start/Playing/Bingo.
    /// </summary>
    [Fact]
    public void GameState_ScavengerHunt_ValueExists()
    {
        var state = GameState.ScavengerHunt;
        Assert.Equal(GameState.ScavengerHunt, state);
    }

    [Fact]
    public void GameState_HasFourValues()
    {
        // Start, Playing, Bingo, ScavengerHunt
        var values = Enum.GetValues<GameState>();
        Assert.Equal(4, values.Length);
    }
}
