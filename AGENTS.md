# AGENTS.md

Guidance for AI coding agents working in this repository.

## Project At A Glance

- App type: Blazor WebAssembly social bingo game
- Main project: [SocOps/SocOps.csproj](SocOps/SocOps.csproj)
- Target framework: .NET 10 (`net10.0`)
- Local dev URL: `http://localhost:5166` (from [SocOps/Properties/launchSettings.json](SocOps/Properties/launchSettings.json))

For product and workshop context, prefer linking to:
- [README.md](README.md)
- [workshop/GUIDE.md](workshop/GUIDE.md)

## Fast Start Commands

Run from repository root unless noted:

- Build: `dotnet build SocOps/SocOps.csproj`
- Run: `dotnet run --project SocOps/SocOps.csproj`

No automated test project is currently present. Validate changes with a build plus manual app flow checks.

## Architecture And Boundaries

- Composition/root:
  - [SocOps/Program.cs](SocOps/Program.cs)
  - [SocOps/App.razor](SocOps/App.razor)
- Main page and game state wiring:
  - [SocOps/Pages/Home.razor](SocOps/Pages/Home.razor)
  - [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs)
- Pure game logic and board rules:
  - [SocOps/Services/BingoLogicService.cs](SocOps/Services/BingoLogicService.cs)
- UI components:
  - [SocOps/Components](SocOps/Components)
- Data model/question seed:
  - [SocOps/Models](SocOps/Models)
  - [SocOps/Data/Questions.cs](SocOps/Data/Questions.cs)

Prefer this pattern:
- Keep deterministic bingo rules in `BingoLogicService`.
- Keep UI state persistence and eventing in `BingoGameService`.
- Keep Razor components presentation-focused.

## Project Conventions

- Styling uses local utility classes in [SocOps/wwwroot/css/app.css](SocOps/wwwroot/css/app.css), not Tailwind runtime.
- Reuse utility class patterns before introducing new CSS rules.
- The game persists state in browser `localStorage` using key `bingo-game-state`; avoid breaking stored data shape without version handling in [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs).

Additional instruction files for design/styling work:
- [.github/instructions/css-utilities.instructions.md](.github/instructions/css-utilities.instructions.md)
- [.github/instructions/frontend-design.instructions.md](.github/instructions/frontend-design.instructions.md)

## Existing Agent Customizations

Reusable task-specific artifacts already exist and should be reused before creating duplicates:

- Custom agents: [.github/agents](.github/agents)
- Prompt files: [.github/prompts](.github/prompts)

## Known Pitfalls

- `dotnet run` output can warn about `HTTP_PORTS` being overridden; this is expected when launch settings bind to `http://localhost:5166`.
- Template pages like [SocOps/Pages/Counter.razor](SocOps/Pages/Counter.razor) and [SocOps/Pages/Weather.razor](SocOps/Pages/Weather.razor) are scaffold leftovers; avoid assuming they are part of gameplay.
- Use links instead of duplicating long workshop/readme content in new customization files.
