using Microsoft.JSInterop;
using Moq;
using SocOps.Models;
using SocOps.Services;

namespace SocOps.Tests;

/// <summary>
/// Tests for Scavenger Hunt mode behaviour on BingoGameService.
/// All tests fail until:
///   - GameMode enum (Bingo, ScavengerHunt) is added to GameState.cs
///   - GameState.ScavengerHunt value is added
///   - BingoGameService.CurrentGameMode property is added
///   - BingoGameService.StartGame(GameMode) overload/optional-param is added
///   - StartGame(GameMode.Bingo) populates the board and sets GameState.Playing
///   - StartGame(GameMode.ScavengerHunt) sets GameState.ScavengerHunt, leaves board empty
/// </summary>
public class BingoGameServiceScavengerHuntTests
{
    private static BingoGameService CreateService()
    {
        var jsRuntime = new Mock<IJSRuntime>();

        jsRuntime
            .Setup(js => js.InvokeAsync<string?>(
                "localStorage.getItem",
                It.IsAny<object[]>()))
            .ReturnsAsync((string?)null);

        jsRuntime
            .Setup(js => js.InvokeAsync<Microsoft.JSInterop.Infrastructure.IJSVoidResult>(
                "localStorage.setItem",
                It.IsAny<object[]>()))
            .ReturnsAsync(Mock.Of<Microsoft.JSInterop.Infrastructure.IJSVoidResult>());

        return new BingoGameService(jsRuntime.Object);
    }

    // ── CurrentGameMode property ────────────────────────────────────────────

    [Fact]
    public void CurrentGameMode_DefaultsTo_Bingo()
    {
        var svc = CreateService();
        Assert.Equal(GameMode.Bingo, svc.CurrentGameMode);
    }

    // ── StartGame(Bingo) ────────────────────────────────────────────────────

    [Fact]
    public void StartGame_Bingo_SetsCurrentGameMode_Bingo()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.Bingo);
        Assert.Equal(GameMode.Bingo, svc.CurrentGameMode);
    }

    [Fact]
    public void StartGame_Bingo_SetsGameState_Playing()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.Bingo);
        Assert.Equal(GameState.Playing, svc.CurrentGameState);
    }

    [Fact]
    public void StartGame_Bingo_PopulatesBoard_With25Squares()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.Bingo);
        Assert.Equal(25, svc.Board.Count);
    }

    // ── StartGame(ScavengerHunt) ────────────────────────────────────────────

    [Fact]
    public void StartGame_ScavengerHunt_SetsCurrentGameMode_ScavengerHunt()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        Assert.Equal(GameMode.ScavengerHunt, svc.CurrentGameMode);
    }

    [Fact]
    public void StartGame_ScavengerHunt_SetsGameState_ScavengerHunt()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        Assert.Equal(GameState.ScavengerHunt, svc.CurrentGameState);
    }

    [Fact]
    public void StartGame_ScavengerHunt_DoesNotPopulateBoard()
    {
        // Scavenger Hunt has its own list — no bingo board should be generated
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        Assert.Empty(svc.Board);
    }

    [Fact]
    public void StartGame_ScavengerHunt_ShowBingoModal_IsFalse()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        Assert.False(svc.ShowBingoModal);
    }

    [Fact]
    public void StartGame_ScavengerHunt_WinningLine_IsNull()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        Assert.Null(svc.WinningLine);
    }

    [Fact]
    public void StartGame_ScavengerHunt_FiresOnStateChanged()
    {
        var svc = CreateService();
        int callCount = 0;
        svc.OnStateChanged += () => callCount++;

        svc.StartGame(GameMode.ScavengerHunt);

        Assert.True(callCount > 0);
    }

    // ── Mode switching ──────────────────────────────────────────────────────

    [Fact]
    public void StartGame_Bingo_AfterScavengerHunt_ResetsMode()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        svc.StartGame(GameMode.Bingo);
        Assert.Equal(GameMode.Bingo, svc.CurrentGameMode);
    }

    [Fact]
    public void StartGame_Bingo_AfterScavengerHunt_PopulatesBoard()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        svc.StartGame(GameMode.Bingo);
        Assert.Equal(25, svc.Board.Count);
    }

    // ── ResetGame from ScavengerHunt ────────────────────────────────────────

    [Fact]
    public void ResetGame_FromScavengerHunt_SetsGameState_Start()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        svc.ResetGame();
        Assert.Equal(GameState.Start, svc.CurrentGameState);
    }

    [Fact]
    public void ResetGame_FromScavengerHunt_BoardRemainsEmpty()
    {
        var svc = CreateService();
        svc.StartGame(GameMode.ScavengerHunt);
        svc.ResetGame();
        Assert.Empty(svc.Board);
    }
}
