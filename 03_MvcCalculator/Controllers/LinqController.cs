using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _03_MvcCalculator.Data;
using _03_MvcCalculator.Models;

namespace _03_MvcCalculator.Controllers;

// 【Step 8b】LINQ (Language Integrated Query) 基礎の学習専用コントローラーです。
// URL: /Linq/... に対応します。
public class LinqController : Controller
{
    private readonly CalculatorDbContext _db;

    public LinqController(CalculatorDbContext db)
    {
        _db = db;
    }

    // 1. 全件表示 (GET /Linq)
    public async Task<IActionResult> Index()
    {
        var list = await GetSampleHistoriesAsync();

        var vm = new LinqDemoViewModel
        {
            QueryTitle = "全件表示（元のデータ）",
            QueryDescription = "_db.CalculationHistory.ToListAsync()",
            FilteredHistories = list,
            TotalCount = list.Count,
            CurrentMode = "All"
        };

        return View(vm);
    }

    // 2. 抽出 (Where): 結果がプラス（0より大きい）の履歴を抽出
    public async Task<IActionResult> WhereDemo()
    {
        var list = await GetSampleHistoriesAsync();

        // Where で条件に一致する要素のみを抽出（ラムダ式の引数名 'h' は 'x' や 'item' など自由に変更可）
        var filtered = list
            .Where(h => h.Result > 0)
            .ToList();

        var vm = new LinqDemoViewModel
        {
            QueryTitle = "1. 条件抽出 (Where): 結果がプラス (> 0) のみ",
            QueryDescription = "list.Where(h => h.Result > 0).ToList()",
            FilteredHistories = filtered,
            TotalCount = filtered.Count,
            CurrentMode = "Where"
        };

        return View("Index", vm);
    }

    // 3. 並び替え (OrderBy / OrderByDescending): 計算結果が大きい順に並び替え
    public async Task<IActionResult> OrderByDemo()
    {
        var list = await GetSampleHistoriesAsync();

        // OrderByDescending: 降順（大きい順）/ OrderBy: 昇順（小さい順）
        var sorted = list
            .OrderByDescending(x => x.Result)
            .ToList();

        var vm = new LinqDemoViewModel
        {
            QueryTitle = "2. 並び替え (OrderByDescending): 結果が大きい順",
            QueryDescription = "list.OrderByDescending(x => x.Result).ToList()",
            FilteredHistories = sorted,
            TotalCount = sorted.Count,
            CurrentMode = "OrderBy"
        };

        return View("Index", vm);
    }

    // 4. 集計 (Count, Sum, Average, Max, Min): 計算結果の統計
    public async Task<IActionResult> AggregateDemo()
    {
        var list = await GetSampleHistoriesAsync();

        int count = list.Count;
        decimal sum = list.Sum(item => item.Result);
        decimal avg = count > 0 ? list.Average(item => item.Result) : 0;
        decimal max = count > 0 ? list.Max(item => item.Result) : 0;
        decimal min = count > 0 ? list.Min(item => item.Result) : 0;

        var vm = new LinqDemoViewModel
        {
            QueryTitle = "3. 集計 (Count, Sum, Average, Max, Min)",
            QueryDescription = "list.Sum(item => item.Result)\nlist.Average(item => item.Result)\nlist.Max(item => item.Result)",
            FilteredHistories = list,
            TotalCount = count,
            SumResult = sum,
            AverageResult = Math.Round(avg, 2),
            MaxResult = max,
            MinResult = min,
            CurrentMode = "Aggregate"
        };

        return View("Index", vm);
    }

    // 5. 【ハンズオン課題】特定の条件でデータを絞り込み & 集計
    public async Task<IActionResult> HandsOn()
    {
        var list = await GetSampleHistoriesAsync();

        // TODO: ハンズオン課題です！
        // 以下の条件を満たすように LINQ クエリを作成してください：
        // 1. 計算結果 (Result) が 100 以上の履歴のみを抽出する (Where)
        // 2. それを計算結果が大きい順に並び替える (OrderByDescending)
        //
        // ヒント: list.Where(...).OrderByDescending(...).ToList();
        // ラムダ式の変数名は 'h', 'x', 'item' など何でも構いません。

        var resultList = list; // ← ここを書き換えてください

        var vm = new LinqDemoViewModel
        {
            QueryTitle = "4. 【ハンズオン課題】結果が 100 以上の履歴を大きい順で抽出",
            QueryDescription = "TODO: LINQ クエリを書く",
            FilteredHistories = resultList,
            TotalCount = resultList.Count,
            SumResult = resultList.Any() ? resultList.Sum(x => x.Result) : 0,
            CurrentMode = "HandsOn"
        };

        return View("Index", vm);
    }

    // ヘルパー: DBから取得（もしDBが空なら学習用の初期データを返す）
    private async Task<List<CalculationHistory>> GetSampleHistoriesAsync()
    {
        List<CalculationHistory> dbList = new();
        try
        {
            dbList = await _db.CalculationHistory.ToListAsync();
        }
        catch
        {
            // ⚠️【教材用の特別措置】
            // マイグレーション（Step 8）が未実行でもLINQの動作を体験できるよう、DBエラー時は例外を握りつぶしてダミーデータへ流しています。
            // ※ 実務では例外の単なる握りつぶし（空のcatch）は障害原因を隠蔽するため原則禁止です。
            // 　 通常はログ記録（ILogger）やエラー画面への遷移など、適切な例外ハンドリングを行います。
        }

        if (dbList.Any())
        {
            return dbList;
        }

        // DBが空の場合の体験用ダミーデータ
        return new List<CalculationHistory>
        {
            new() { Id = 1, Expression = "10 + 20", Result = 30, CreatedAt = DateTime.Now.AddMinutes(-50) },
            new() { Id = 2, Expression = "500 - 150", Result = 350, CreatedAt = DateTime.Now.AddMinutes(-40) },
            new() { Id = 3, Expression = "5 - 15", Result = -10, CreatedAt = DateTime.Now.AddMinutes(-30) },
            new() { Id = 4, Expression = "100 + 150", Result = 250, CreatedAt = DateTime.Now.AddMinutes(-20) },
            new() { Id = 5, Expression = "0 - 50", Result = -50, CreatedAt = DateTime.Now.AddMinutes(-10) },
            new() { Id = 6, Expression = "80 + 40", Result = 120, CreatedAt = DateTime.Now }
        };
    }
}
