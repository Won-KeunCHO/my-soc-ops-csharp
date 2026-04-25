namespace SocOps.Data;

public static class TechQuestions
{
    public const string FREE_SPACE = "FREE SPACE";

    public static readonly List<string> QuestionsList = new()
    {
        // IDE & Editor Preferences (~50% - easy to find)
        "uses VS Code as their main editor",
        "has tried Vim or Neovim",
        "prefers dark mode",
        "uses Visual Studio (full)",
        "has customized their editor theme",
        "uses a terminal-based editor",
        "has JetBrains IDE installed",
        "prefers tabs over spaces (or vice versa)",
        "uses keyboard shortcuts religiously",
        "has abandoned an IDE mid-project",

        // Coding Habits & Practices
        "writes tests before code (TDD)",
        "debugs with console.log (or equivalent)",
        "has refactored legacy code today",
        "uses git commit messages like 'fix stuff'",
        "has force-pushed to main by accident",
        "uses meaningful variable names",
        "leaves TODOs scattered in code",
        "has a side project they never finished",
        "prefers working at night",
        "codes better with music",

        // Developer Culture & Experiences
        "has attended a dev conference",
        "contributes to open source",
        "can explain blockchain (or tried)",
        "knows what rubber duck debugging is",
        "has debugged code at 3 AM",
        "uses AI code assistants (like Copilot)",
        "has read Clean Code cover to cover",
        "prefers functional programming",
        "loves a good compile time joke",
        "has done pair programming",

        // Bold / Challenges
        "teach the group a cool VS Code shortcut — live",
        "show your most embarrassing code comment on screen",
        "name 5 programming languages in 30 seconds",
        "explain what this → does: const x = () => x?.y?.[0]?.z",
    };
}
