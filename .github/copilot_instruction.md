# GitHub Instruction

AI 에이전트 작업용 요약 가이드입니다.

## 원칙

- 전역 기준은 [AGENTS.md](AGENTS.md)를 우선 사용
- 중복 설명 대신 기존 문서 링크 활용

## 필수 명령

- 빌드: dotnet build SocOps/SocOps.csproj
- 실행: dotnet run --project SocOps/SocOps.csproj

## 핵심 파일

- [SocOps/Program.cs](SocOps/Program.cs)
- [SocOps/App.razor](SocOps/App.razor)
- [SocOps/Pages/Home.razor](SocOps/Pages/Home.razor)
- [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs)
- [SocOps/Services/BingoLogicService.cs](SocOps/Services/BingoLogicService.cs)

## 관련 커스텀

- [AGENTS.md](AGENTS.md)
- [.github/agents](.github/agents)
- [.github/prompts](.github/prompts)
- [.github/skills/review-gameplay-regression/SKILL.md](.github/skills/review-gameplay-regression/SKILL.md)
