# Graph Report - practice  (2026-07-31)

## Corpus Check
- 47 files · ~4,376 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 195 nodes · 238 edges · 30 communities (24 shown, 6 thin omitted)
- Extraction: 97% EXTRACTED · 3% INFERRED · 0% AMBIGUOUS · INFERRED: 7 edges (avg confidence: 0.8)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `1cec0e31`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- ICurrencyService
- 03_MvcCalculator.Tests
- _03_MvcCalculator.Models
- 🚀 学習ロードマップ
- http
- http
- HistoryController
- CurrencyService
- CalculatorController
- CalculatorServiceTests
- Program
- HomeController
- _03_MvcCalculator.Models
- Calculator/Index.cshtml
- Result.cshtml
- Currency/Index.cshtml
- History/Index.cshtml

## God Nodes (most connected - your core abstractions)
1. `CurrencyService` - 11 edges
2. `_03_MvcCalculator.Models` - 9 edges
3. `ICurrencyService` - 9 edges
4. `🚀 学習ロードマップ` - 9 edges
5. `03_MvcCalculator.Tests` - 8 edges
6. `_03_MvcCalculator.Services` - 8 edges
7. `CalculatorController` - 7 edges
8. `CurrencyController` - 7 edges
9. `HistoryController` - 7 edges
10. `http` - 6 edges

## Surprising Connections (you probably didn't know these)
- `CalculatorController` --references--> `ICalculatorService`  [EXTRACTED]
  03_MvcCalculator/Controllers/CalculatorController.cs → 03_MvcCalculator/Services/ICalculatorService.cs
- `CurrencyService` --implements--> `ICurrencyService`  [EXTRACTED]
  03_MvcCalculator/Services/CurrencyService.cs → 03_MvcCalculator/Services/ICurrencyService.cs
- `CurrencyController` --references--> `ICurrencyService`  [EXTRACTED]
  03_MvcCalculator/Controllers/CurrencyController.cs → 03_MvcCalculator/Services/ICurrencyService.cs
- `HistoryController` --references--> `CalculatorDbContext`  [EXTRACTED]
  03_MvcCalculator/Controllers/HistoryController.cs → 03_MvcCalculator/Data/CalculatorDbContext.cs
- `CalculatorDbContext` --references--> `CalculationHistory`  [EXTRACTED]
  03_MvcCalculator/Data/CalculatorDbContext.cs → 03_MvcCalculator/Models/CalculationHistory.cs

## Import Cycles
- None detected.

## Communities (30 total, 6 thin omitted)

### Community 0 - "ICurrencyService"
Cohesion: 0.17
Nodes (11): CurrencyController, HttpGet, HttpPost, IActionResult, Task, CurrencyExchangeViewModel, ICurrencyService, Dictionary (+3 more)

### Community 1 - "03_MvcCalculator.Tests"
Cohesion: 0.11
Nodes (18): 01_ConsoleApp, net10.0, Microsoft.NET.Sdk, 02_MinimalWebApi, net10.0, Microsoft.NET.Sdk.Web, 03_MvcCalculator, net10.0 (+10 more)

### Community 2 - "_03_MvcCalculator.Models"
Cohesion: 0.15
Nodes (7): ErrorViewModel, CalculatorService, ICalculatorService, _03_MvcCalculator.Data, _03_MvcCalculator.Services, _03_MvcCalculator.Models, _03_MvcCalculator.Controllers

### Community 3 - "🚀 学習ロードマップ"
Cohesion: 0.11
Nodes (18): 📂 1. `01_ConsoleApp` (Step 1: コンソール・C#基礎編), 📂 2. `02_MinimalWebApi` (Step 2: Web API の基本編), 📂 3. `03_MvcCalculator` (Step 3: MVC の基礎編), 📂 4. `03_MvcCalculator` (Step 4: 実践フォーム・オブジェクト指向編), 📂 5. `03_MvcCalculator` (Step 5: Dependency Injection 編), 📂 6. `03_MvcCalculator.Tests` (Step 6: 単体テスト編), 📂 7. `03_MvcCalculator` (Step 7: 非同期処理・外部API連携編), 📂 8. `03_MvcCalculator` (Step 8: データ永続化・EF Core × SQLite編) (+10 more)

### Community 4 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 5 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 6 - "HistoryController"
Cohesion: 0.23
Nodes (9): HistoryController, HttpPost, IActionResult, Task, CalculatorDbContext, CalculationHistory, DateTime, DbContext (+1 more)

### Community 7 - "CurrencyService"
Cohesion: 0.24
Nodes (5): CurrencyService, ExchangeRateApiResponse, Dictionary, Task, HttpClient

### Community 8 - "CalculatorController"
Cohesion: 0.27
Nodes (5): CalculatorController, HttpGet, HttpPost, IActionResult, CalculatorResultViewModel

### Community 9 - "CalculatorServiceTests"
Cohesion: 0.27
Nodes (5): CalculatorServiceTests, _03_MvcCalculator.Tests, Fact, InlineData, Theory

### Community 11 - "HomeController"
Cohesion: 0.47
Nodes (3): HomeController, IActionResult, ResponseCache

## Knowledge Gaps
- **53 isolated node(s):** `net10.0`, `Microsoft.NET.Sdk`, `ConsoleApp`, `net10.0`, `Microsoft.NET.Sdk.Web` (+48 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **6 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `CurrencyController` connect `ICurrencyService` to `_03_MvcCalculator.Models`?**
  _High betweenness centrality (0.071) - this node is a cross-community bridge._
- **Why does `_03_MvcCalculator.Services` connect `_03_MvcCalculator.Models` to `ICurrencyService`, `CalculatorServiceTests`, `CurrencyService`?**
  _High betweenness centrality (0.069) - this node is a cross-community bridge._
- **Why does `ICurrencyService` connect `ICurrencyService` to `CurrencyService`?**
  _High betweenness centrality (0.053) - this node is a cross-community bridge._
- **What connects `net10.0`, `Microsoft.NET.Sdk`, `ConsoleApp` to the rest of the system?**
  _53 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `03_MvcCalculator.Tests` be split into smaller, more focused modules?**
  _Cohesion score 0.1111111111111111 - nodes in this community are weakly interconnected._
- **Should `_03_MvcCalculator.Models` be split into smaller, more focused modules?**
  _Cohesion score 0.14619883040935672 - nodes in this community are weakly interconnected._
- **Should `🚀 学習ロードマップ` be split into smaller, more focused modules?**
  _Cohesion score 0.10526315789473684 - nodes in this community are weakly interconnected._