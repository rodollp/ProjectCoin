# ProjectCoin

Unity 6 기반의 3D 코인 수집 미니게임입니다.

제한 시간 동안 플레이어를 조작하여 코인을 수집하고 점수를 기록하는 게임으로, 수업 실습을 통해 게임 시스템 구현과 플랫폼별 빌드, 콘텐츠 관리 방법을 학습했습니다.

## 1. 개발 환경

| 항목 | 내용 |
|---|---|
| 개발 언어 | C# |
| 게임 엔진 | Unity 6000.6.9f1 |
| 주요 패키지 | Input System, Addressables, URP |
| 대상 플랫폼 | Windows / Android / Web |
| 파일 서버 | ASP.NET Core (.NET 10) |
| GitHub | https://github.com/rodollp/ProjectCoin |

## 2. 주요 구현 기능

| 기능 | 구현 내용 |
|---|---|
| 플레이어 이동 | Input System 기반 이동 및 이동 범위 제한 |
| 코인 수집 | Trigger 충돌 처리 및 HashSet을 이용한 중복 수집 방지 |
| 게임 진행 | 제한 시간, 점수, 시작·종료 화면 관리 |
| 데이터 저장 | PlayerPrefs를 이용한 최고 점수 저장 |
| 콘텐츠 관리 | Addressables를 이용한 비동기 스테이지 로딩 |
| 외부 설정 | JSON 파일을 통한 제한 시간 변경 및 오류 시 기본값 적용 |
| 플랫폼 대응 | 플랫폼별 FPS 설정, Safe Area 및 앱 일시정지 처리 |
| 파일 서버 | ASP.NET Core 기반 설정·콘텐츠 파일 제공 |

### 주요 코드 구조

- `GameSession.cs` — 게임 진행 및 UI 관리
- `CoinRound.cs` — 점수와 제한 시간 관리
- `CoinPickup.cs` — 코인 수집 처리
- `StageLoader.cs` — Addressables 콘텐츠 로딩
- `PlatformConfigLoader.cs` — 외부 JSON 설정 처리
- `FramePolicy.cs` — 플랫폼별 프레임 설정

## 3. 문제 해결 및 성능 개선

**JSON 설정 오류 대응**

외부 설정 파일이 없거나 잘못된 값이 전달되는 상황에 대비하여 유효 범위(10~120초)를 검사하고, 실패 시 기본값 30초를 적용하도록 구현했습니다.

- 관련 코드: `PlatformConfigLoader.LoadSettings()`
- 구분: 수업 기반 오류 대응
- 실제 오류 로그 및 재검증 자료: 별도 확인 필요

**UI 갱신 처리**

Safe Area와 화면 크기가 변경되지 않았다면 UI 앵커를 다시 계산하지 않도록 처리했습니다.

- 관련 코드: `SafeAreaFitter.Update()`
- Profiler 수정 전후 수치: 미측정
- 동일 조건 비교 자료: 추가 확인 필요

## 4. 실행 방법

1. Unity Hub에서 `NewCoin` 폴더를 엽니다.
2. `Assets/Scenes/PlatformMain.unity`를 실행합니다.
3. Addressables의 `stage-main` 콘텐츠를 빌드합니다.
4. 게임에서 Start 버튼을 눌러 코인을 수집합니다.

파일 서버는 `ContentServer` 폴더에서 다음 명령으로 실행합니다.

```bash
dotnet run --no-launch-profile
```

서버 주소: `https://localhost:5443`

## 5. 구현 범위 및 참고 사항

본 프로젝트는 **수업 실습을 기반으로 구현**했으며, 별도로 확인되지 않은 기능 확장은 직접 개선 사항으로 표시하지 않았습니다.

외부 코드·자산의 출처 및 사용 범위는 별도 확인이 필요합니다. Android·Web 실기기 및 브라우저 검증 결과와 Profiler 측정 자료는 현재 미확인 상태입니다.

게임 플레이 영상, 플랫폼별 빌드 결과물, 오류 해결 및 성능 비교 자료는 제출 파일에 별도로 포함할 수 있습니다.
