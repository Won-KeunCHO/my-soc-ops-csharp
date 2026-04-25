---
name: review-gameplay-regression
description: 'Run a focused gameplay regression review for the Soc Ops Blazor app. Use after edits to game logic, components, state persistence, or question data. Checks build health, bingo behavior, and localStorage compatibility.'
argument-hint: '[optional: summarize changed files or target area]'
user-invocable: true
---

# Review Gameplay Regression

Use this skill to perform a consistent regression pass on core game behavior in this repository.

## Use When

- You changed files in [SocOps/Services](SocOps/Services), [SocOps/Components](SocOps/Components), [SocOps/Models](SocOps/Models), or [SocOps/Data](SocOps/Data).
- You touched state or persistence code in [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs).
- You need a release-readiness smoke check for gameplay.

## Workflow

1. Scope the change
- Inspect diffs and list impacted game flows (start game, mark/unmark square, bingo modal, reset game, reload persistence).

2. Validate compile health
- Run: `dotnet build SocOps/SocOps.csproj -nologo -v minimal`
- If build fails, stop and report root causes first.

3. Run and verify startup
- Run: `dotnet run --project SocOps/SocOps.csproj`
- Confirm server binds to the URL from [SocOps/Properties/launchSettings.json](SocOps/Properties/launchSettings.json).

4. Manual gameplay checks
- Start game from home screen.
- Confirm board is 5x5 with FREE SPACE marked at center.
- Mark and unmark at least one non-center square.
- Complete a winning row, column, or diagonal and confirm bingo UI appears.
- Dismiss bingo modal and verify board state remains coherent.
- Reset game and verify state returns to Start.

5. Persistence checks
- During a game, reload the page and confirm board + state restore correctly from localStorage.
- After bingo, reload and confirm winning line/state is still coherent.
- After reset, reload and confirm no stale in-progress board reappears.

6. Regression notes
- Report findings ordered by severity with file references.
- If no issues are found, explicitly state "No regression findings" and list any testing gaps.

## Repo-Specific Signals

- Core state transitions are orchestrated in [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs).
- Deterministic board/bingo rules live in [SocOps/Services/BingoLogicService.cs](SocOps/Services/BingoLogicService.cs).
- Main UI wiring is in [SocOps/Pages/Home.razor](SocOps/Pages/Home.razor).

## Related Guidance

- Base agent instructions: [AGENTS.md](AGENTS.md)
- Utility CSS guidance: [.github/instructions/css-utilities.instructions.md](.github/instructions/css-utilities.instructions.md)
- Workshop context: [workshop/GUIDE.md](workshop/GUIDE.md)
