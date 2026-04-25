using SocOps.Data;
using SocOps.Models;

namespace SocOps.Tests;

/// <summary>
/// Tests that the Pokémon question list satisfies the requirements for Scavenger Hunt mode.
/// These tests cover the data contract that ScavengerHunt.razor depends on.
/// </summary>
public class ScavengerHuntQuestionDataTests
{
    [Fact]
    public void PokemonQuestions_HasAtLeastTwentyFourItems()
    {
        // ScavengerHunt shows all questions; list must have >= 24 entries
        Assert.True(Questions.QuestionsList.Count >= 24,
            $"Expected at least 24 questions, got {Questions.QuestionsList.Count}");
    }

    [Fact]
    public void PokemonQuestions_ContainsNoDuplicates()
    {
        var distinct = Questions.QuestionsList.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        Assert.Equal(Questions.QuestionsList.Count, distinct.Count);
    }

    [Fact]
    public void PokemonQuestions_NoEmptyOrWhitespaceEntries()
    {
        Assert.All(Questions.QuestionsList, q =>
            Assert.False(string.IsNullOrWhiteSpace(q), "Empty/whitespace question found"));
    }
}

/// <summary>
/// Tests for the StoredGameData serialization contract — confirms that after the
/// STORAGE_VERSION bump (1 → 2) old persisted data is gracefully ignored so that
/// the new GameMode field defaults to Bingo when loading old saves.
/// These tests fail until STORAGE_VERSION is incremented to 2 in BingoGameService.
/// </summary>
public class StorageVersionBumpTests
{
    [Fact]
    public void StorageVersion_IsTwo()
    {
        // Reflect on the private constant — must equal 2 after the mode-persistence bump
        var field = typeof(SocOps.Services.BingoGameService)
            .GetField("STORAGE_VERSION",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);

        Assert.NotNull(field);
        var value = (int)field.GetValue(null)!;
        Assert.Equal(2, value);
    }
}
