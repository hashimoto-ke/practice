# Graph Report - practice  (2026-09-10)

## Corpus Check
- 50 files · ~5,487 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 242 nodes · 320 edges · 32 communities (13 shown, 6 thin omitted)
- Extraction: 93% EXTRACTED · 7% INFERRED · 0% AMBIGUOUS · INFERRED: 23 edges (avg confidence: 0.85)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `e9c6708b`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- CurrencyExchangeViewModel
- 03_MvcCalculator.Tests
- _03_MvcCalculator.Models
- 🚀 学習ロードマップ
- http
- http
- HistoryController
- CurrencyService
- CalculatorController
- CalculatorService
- Program
- HomeController
- LinqDemoViewModel
- Calculator/Index.cshtml
- Result.cshtml
- Currency/Index.cshtml
- History/Index.cshtml
- CalculationHistory
- Linq/Index.cshtml

## God Nodes (most connected - your core abstractions)
1. `LinqDemoViewModel` - 18 edges
2. `_03_MvcCalculator.Models` - 12 edges
3. `CurrencyExchangeViewModel` - 11 edges
4. `CurrencyService` - 11 edges
5. `🚀 学習ロードマップ` - 10 edges
6. `LinqController` - 9 edges
7. `ICurrencyService` - 9 edges
8. `03_MvcCalculator.Tests` - 8 edges
9. `_03_MvcCalculator.Services` - 8 edges
10. `CalculatorController` - 7 edges

## Surprising Connections (you probably didn't know these)
- `CalculatorController` --references--> `ICalculatorService`  [EXTRACTED]
  03_MvcCalculator/Controllers/CalculatorController.cs → 03_MvcCalculator/Services/ICalculatorService.cs
- `CurrencyController` --references--> `ICurrencyService`  [EXTRACTED]
  03_MvcCalculator/Controllers/CurrencyController.cs → 03_MvcCalculator/Services/ICurrencyService.cs
- `LinqController` --references--> `CalculatorDbContext`  [EXTRACTED]
  03_MvcCalculator/Controllers/LinqController.cs → 03_MvcCalculator/Data/CalculatorDbContext.cs
- `LinqDemoViewModel` --references--> `CalculationHistory`  [EXTRACTED]
  03_MvcCalculator/Models/LinqDemoViewModel.cs → 03_MvcCalculator/Models/CalculationHistory.cs
- `HistoryController` --references--> `CalculatorDbContext`  [EXTRACTED]
  03_MvcCalculator/Controllers/HistoryController.cs → 03_MvcCalculator/Data/CalculatorDbContext.cs

## Import Cycles
- None detected.

## Communities (32 total, 6 thin omitted)

### Community 0 - "CurrencyExchangeViewModel"
Cohesion: 0.17
Nodes (14): CurrencyController, HttpGet, HttpPost, IActionResult, Task, CurrencyExchangeViewModel, ExecutionTimeMs, InputAmount (+6 more)

### Community 1 - "03_MvcCalculator.Tests"
Cohesion: 0.11
Nodes (18): 01_ConsoleApp, net10.0, Microsoft.NET.Sdk, 02_MinimalWebApi, net10.0, Microsoft.NET.Sdk.Web, 03_MvcCalculator, net10.0 (+10 more)

### Community 2 - "_03_MvcCalculator.Models"
Cohesion: 0.23
Nodes (4): _03_MvcCalculator.Data, _03_MvcCalculator.Services, _03_MvcCalculator.Models, _03_MvcCalculator.Controllers

### Community 3 - "🚀 学習ロードマップ"
Cohesion: 0.10
Nodes (19): 📂 1. `01_ConsoleApp` (Step 1: コンソール・C#基礎編), 📂 2. `02_MinimalWebApi` (Step 2: Web API の基本編), 📂 3. `03_MvcCalculator` (Step 3: MVC の基礎編), 📂 4. `03_MvcCalculator` (Step 4: 実践フォーム・オブジェクト指向編), 📂 5. `03_MvcCalculator` (Step 5: Dependency Injection 編), 📂 6. `03_MvcCalculator.Tests` (Step 6: 単体テスト編), 📂 7. `03_MvcCalculator` (Step 7: 非同期処理・外部API連携編), 📂 8. `03_MvcCalculator` (Step 8: データ永続化・EF Core × SQLite編) (+11 more)

### Community 4 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 5 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 6 - "HistoryController"
Cohesion: 0.26
Nodes (9): HistoryController, HttpPost, IActionResult, Task, CalculatorDbContext, CalculationHistory, CalculationHistory, DbContext (+1 more)

### Community 7 - "CurrencyService"
Cohesion: 0.14
Nodes (10): CurrencyService, ExchangeRateApiResponse, Base, Rates, Dictionary, Task, ICurrencyService, Dictionary (+2 more)

### Community 8 - "CalculatorController"
Cohesion: 0.19
Nodes (9): CalculatorController, HttpGet, HttpPost, IActionResult, CalculatorResultViewModel, A, B, Diff (+1 more)

### Community 9 - "CalculatorService"
Cohesion: 0.17
Nodes (7): CalculatorService, ICalculatorService, CalculatorServiceTests, _03_MvcCalculator.Tests, Fact, InlineData, Theory

### Community 11 - "HomeController"
Cohesion: 0.24
Nodes (6): HomeController, IActionResult, ErrorViewModel, RequestId, ShowRequestId, ResponseCache

### Community 12 - "LinqDemoViewModel"
Cohesion: 0.16
Nodes (17): LinqController, CalculationHistory, IActionResult, List, Task, LinqDemoViewModel, AverageResult, CurrentMode (+9 more)

### Community 30 - "CalculationHistory"
Cohesion: 0.29
Nodes (6): CalculationHistory, CreatedAt, Expression, Id, Result, DateTime

## Knowledge Gaps
- **82 isolated node(s):** `net10.0`, `Microsoft.NET.Sdk`, `ConsoleApp`, `net10.0`, `Microsoft.NET.Sdk.Web` (+77 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 116 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **6 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `_03_MvcCalculator.Models` connect `_03_MvcCalculator.Models` to `CurrencyExchangeViewModel`, `CalculatorController`, `HomeController`, `CalculationHistory`?**
  _High betweenness centrality (0.101) - this node is a cross-community bridge._
- **Why does `CurrencyController` connect `CurrencyExchangeViewModel` to `CurrencyService`?**
  _High betweenness centrality (0.088) - this node is a cross-community bridge._
- **Why does `_03_MvcCalculator.Services` connect `_03_MvcCalculator.Models` to `CurrencyExchangeViewModel`, `CalculatorService`, `CurrencyService`?**
  _High betweenness centrality (0.066) - this node is a cross-community bridge._
- **Are the 5 inferred relationships involving `LinqDemoViewModel` (e.g. with `.AggregateDemo()` and `.HandsOn()`) actually correct?**
  _`LinqDemoViewModel` has 5 INFERRED edges - model-reasoned connections that need verification._
- **What connects `net10.0`, `Microsoft.NET.Sdk`, `ConsoleApp` to the rest of the system?**
  _82 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `03_MvcCalculator.Tests` be split into smaller, more focused modules?**
  _Cohesion score 0.1111111111111111 - nodes in this community are weakly interconnected._
- **Should `🚀 学習ロードマップ` be split into smaller, more focused modules?**
  _Cohesion score 0.1 - nodes in this community are weakly interconnected._