using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _03_MvcCalculator.Data;
using _03_MvcCalculator.Models;

namespace _03_MvcCalculator.Controllers;

// 【Step 8】データ永続化（EF Core × SQLite）の学習専用コントローラーです。
// URL: /History/... に対応します。
// CalculatorController や CurrencyController は一切変更せず、
// このコントローラーにのみ DB 操作を集中させています。
public class HistoryController : Controller
{
    private readonly CalculatorDbContext _db;

    // DbContext は DI コンテナによってコンストラクタに自動注入されます。
    public HistoryController(CalculatorDbContext db)
    {
        _db = db;
    }

    // 計算履歴の一覧表示 (GET /History)
    // ToListAsync() はデータベースの全レコードを非同期で取得します。
    public async Task<IActionResult> Index()
    {
        var histories = await _db.CalculationHistory
            .OrderByDescending(h => h.CreatedAt)
            .ToListAsync();
        return View(histories);
    }

    // 履歴の保存 (POST /History/Create)
    // お手本: AddAsync + SaveChangesAsync による非同期レコード追加
    [HttpPost]
    public async Task<IActionResult> Create(string expression, decimal result)
    {
        var history = new CalculationHistory
        {
            Expression = expression,
            Result = result,
            CreatedAt = DateTime.Now
        };

        // お手本: await で非同期にデータを追加し、DB へ保存します。
        await _db.CalculationHistory.AddAsync(history);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // 履歴の削除 (POST /History/Delete/{id})
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var history = await _db.CalculationHistory.FindAsync(id);
        if (history is not null)
        {
            // お手本: Remove() でエンティティを削除対象にマークし、SaveChangesAsync() で確定します。
            _db.CalculationHistory.Remove(history);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // 【ハンズオン】全履歴の一括削除 (POST /History/DeleteAll)
    [HttpPost]
    public async Task<IActionResult> DeleteAll()
    {
        // TODO: _db.CalculationHistories の全レコードを削除してください。
        // ヒント: await _db.CalculationHistories.ExecuteDeleteAsync(); で全件削除できます。
        // 実装後は上の Delete アクションと比較し、どちらがどんな場面に向いているか考えてみましょう。

        return RedirectToAction(nameof(Index));
    }
}
