using Microsoft.AspNetCore.Mvc;
using _03_MvcCalculator.Models;
using _03_MvcCalculator.Services;

namespace _03_MvcCalculator.Controllers;

// 【Step 7】非同期処理と外部API連携の学習専用コントローラーです。
// URL: /Currency/... に対応します。
// CalculatorController を一切変更せず、このコントローラーにのみ非同期の処理を集中させています。
public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    // 外貨換算フォームの表示 (GET)
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CurrencyExchangeViewModel());
    }

    // 外貨換算の実行 (POST)
    // 通常の IActionResult ではなく Task<IActionResult> を返すことで、
    // このアクションが「非同期メソッド」であることを示します。
    // await を使ってサービスの処理が完了するまで待機し、スレッドをブロックしません。
    [HttpPost]
    public async Task<IActionResult> Index(CurrencyExchangeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // await でサービスの非同期メソッドを呼び出します。非同期メソッドが実行される間、ASP.NET Core は他のリクエストを処理できます（スレッドの解放）。
        if (model.Mode == "UsdToJpy")
        {
            decimal jpy = await _currencyService.ConvertUsdToJpyAsync(model.InputAmount);
            model.Message = $"{model.InputAmount:#,0.##} USD = {jpy:#,0.##} 円";
        }
        else
        {
            decimal usd = await _currencyService.ConvertJpyToUsdAsync(model.InputAmount);
            model.Message = $"{model.InputAmount:#,0.##} 円 = {usd:#,0.##} USD";
        }

        return View(model);
    }

    // 【比較体験用】同期処理による外貨換算 (POST /Currency/Sync)
    // Thread.Sleep(3000) を含む同期メソッドを呼び出すため、3秒間 Web サーバーのスレッドが完全に拘束（ブロック）されます。
    // この間に別タブで他のページを開こうとすると、処理が終わるまで待たされます。
    [HttpPost]
    public IActionResult Sync(CurrencyExchangeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        // 同期で3秒間スレッドをブロックして結果を取得
        model.Rate = _currencyService.GetJpyToUsdRateSync();
        decimal usd = Math.Round(model.InputAmount / model.Rate, 2);
        model.Message = $"【同期処理で実行】{model.InputAmount:#,0.##} 円 = {usd:#,0.##} USD（1 USD = {model.Rate:#,0.##} 円）";

        return View("Index", model);
    }

    // 【比較体験①】同期処理で3つの通貨レートを順番に取得 (POST /Currency/CompareSync)
    [HttpPost]
    [ActionName("CompareSync")]
    public IActionResult CompareSync(CurrencyExchangeViewModel model)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        // 3つの外部APIを順番に同期呼び出し（1秒×3回＝約3秒）
        var rates = _currencyService.GetMultipleRatesSync();

        sw.Stop();
        model.ExecutionTimeMs = sw.ElapsedMilliseconds;
        model.MultipleRatesMessage = $"【同期・順次実行】USD: {rates["USD"]}円 / EUR: {rates["EUR"]}円 / GBP: {rates["GBP"]}円";

        return View("Index", model);
    }

    // 【比較体験②】非同期処理 (Task.WhenAll) で3つの通貨レートを同時に並行取得 (POST /Currency/CompareAsync)
    [HttpPost]
    [ActionName("CompareAsync")]
    public async Task<IActionResult> CompareAsync(CurrencyExchangeViewModel model)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();

        // 3つの外部APIを Task.WhenAll で同時に並行呼び出し（約1秒で完了！）
        var rates = await _currencyService.GetMultipleRatesAsync();

        sw.Stop();
        model.ExecutionTimeMs = sw.ElapsedMilliseconds;
        model.MultipleRatesMessage = $"【非同期・並行実行 (Task.WhenAll)】USD: {rates["USD"]}円 / EUR: {rates["EUR"]}円 / GBP: {rates["GBP"]}円";

        return View("Index", model);
    }
}
