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

## Design Guide

- 기존 UI 패턴과 정보 구조를 유지하고, 시각 스타일만 개선
- 스타일 변경은 [SocOps/wwwroot/css/app.css](SocOps/wwwroot/css/app.css)를 우선 수정
- 컴포넌트는 표시 전용으로 유지하고, 게임 로직은 Service 계층에 유지
- 색상/간격/타이포는 CSS 변수로 통일해 일관성 확보
- 모바일 우선 반응형을 적용하고 360px 폭에서도 깨지지 않게 확인
- 모션은 핵심 순간(초기 진입, 모달, 상태 전환)에만 절제해서 사용
- 접근성 기본 준수: 충분한 대비, 명확한 포커스 링, reduced-motion 대응
- 새 클래스 도입 전 기존 유틸리티/패턴 재사용을 먼저 검토
- 게임 화면 변경 시 빌드 후 수동 플레이 체크를 수행
