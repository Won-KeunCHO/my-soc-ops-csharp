<div align="center">

[Português (BR)](README.pt_BR.md) · [Español](README.es.md)

# Soc Ops

**Break the ice. Find your people. Get five in a row.**

A social bingo game built for in-person mixers — powered by Blazor WebAssembly and GitHub Copilot.

[**Play the Game →**](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/) &nbsp;&nbsp;·&nbsp;&nbsp; [**View Lab Guide →**](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/)

</div>

---

## What Is Soc Ops?

Soc Ops turns networking events into something people actually enjoy. Each player gets a unique 5×5 bingo card filled with questions about their colleagues. Walk the room, find matches, mark your card, and shout **BINGO**.

Built as a hands-on lab, Soc Ops also teaches real-world agentic development with GitHub Copilot — from context engineering to multi-agent workflows.

---

## Lab Guide

Four focused modules. Each one builds on the last.

| | Module | What You'll Learn |
|---|---|---|
| 00 | [Overview & Checklist](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=00-overview) | Scope, goals, and environment setup |
| 01 | [Setup & Context Engineering](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=01-setup) | Teaching Copilot about your codebase |
| 02 | [Design-First Frontend](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=02-design) | Generating polished UI with agents |
| 03 | [Custom Quiz Master](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=03-quiz-master) | Authoring a specialized Copilot agent |
| 04 | [Multi-Agent Development](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=04-multi-agent) | Orchestrating agents that work together |

> Prefer offline? All guides are available in [`workshop/`](workshop/).

---

## Get Started

**Requires:** [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or higher

### Run locally

```bash
cd SocOps
dotnet run
```

### Build

```bash
cd SocOps
dotnet build
```

### Open in GitHub Codespaces

1. Create your own repo from this template
2. On GitHub, click **Code → Codespaces → Create codespace on main**
3. Once setup completes, run `dotnet run` from `SocOps/`

---

## How It Works

- **Unique boards** — each player's card is randomly generated from a shared question pool
- **Free space** — the center square is always pre-marked
- **State persistence** — your board survives page refreshes via `localStorage`
- **Instant win detection** — rows, columns, and diagonals are checked after every mark

---

*Deploys automatically to GitHub Pages on push to `main`.*
