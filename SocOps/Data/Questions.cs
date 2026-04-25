namespace SocOps.Data;

public static class Questions
{
    public const string FREE_SPACE = "FREE SPACE";

    public static readonly List<string> QuestionsList = new()
    {
        // Easy wins (~50%)
        "knows Pikachu's name",
        "has played a Pokémon game",
        "knows what a Poké Ball is",
        "can name a starter Pokémon",
        "has watched the Pokémon anime",
        "knows what 'evolve' means in Pokémon",
        "has caught a Pokémon in Pokémon GO",
        "can name a Legendary Pokémon",
        "knows what type beats Water",
        "knows Ash's partner Pokémon",
        "has owned a Pokémon game cartridge",
        // Medium
        "can name all 3 Kanto starters",
        "knows what a shiny Pokémon is",
        "has battled a friend in Pokémon",
        "knows the full Pokérap (or tried)",
        "can name a Pokémon from every generation",
        "knows what EV training is",
        "has a favourite Eevee evolution",
        "has completed a Pokédex (any game)",
        "knows what a Nuzlocke run is",
        // Bold / wildcards
        "do your best Pikachu impression — right now",
        "challenge someone to name a Pokémon for every letter A–Z",
        "teach the group one Pokémon type matchup",
        "name 10 Pokémon in 10 seconds"
    };
}
