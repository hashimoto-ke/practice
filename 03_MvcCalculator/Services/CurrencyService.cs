using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace _03_MvcCalculator.Services;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// 為替レート (1 USD あたりの 円) を非同期で取得します。
    /// </summary>
    public async Task<decimal> GetJpyToUsdRateAsync()
    {
        // お手本: 外部APIへの HTTP GET リクエストを非同期で送信する例
        // 実際のAPIを呼び出す場合は以下のようにします:
        //   var response = await _httpClient.GetFromJsonAsync<ExchangeRateApiResponse>("https://...");
        //   return response.Rates["JPY"];

        // この学習用コードでは、比較体験のために 3000ms (3秒) の通信遅延をシミュレートしています。
        // await により、3秒待つ間もWebサーバーのスレッドは即座に解放され、他のリクエストを処理できます。
        await Task.Delay(3000);

        decimal currentRate = 150.00m;
        return currentRate;
    }

    /// <summary>
    /// 日本円から米ドルへの換算を非同期で実行します。
    /// </summary>
    public async Task<decimal> ConvertJpyToUsdAsync(decimal jpyAmount)
    {
        // お手本: GetJpyToUsdRateAsync() を await で非同期呼び出し
        decimal rate = await GetJpyToUsdRateAsync();

        if (rate <= 0)
        {
            return 0;
        }

        // 日本円 ÷ レート = 米ドル（小数点第2位で丸め）
        return Math.Round(jpyAmount / rate, 2);
    }

    /// <summary>
    /// 【ハンズオン】米ドルから日本円への換算を非同期で実行するメソッドです。
    /// </summary>
    // TODO: 上の ConvertJpyToUsdAsync をお手本に、以下の仕様でメソッドを実装してください。
    // ヒント: GetJpyToUsdRateAsync() でレートを取得し、usdAmount × rate を計算して返します。
    // （以下はビルドエラーを防ぐための空のスタブです。ハンズオンで中身を書き換えてください）
    public async Task<decimal> ConvertUsdToJpyAsync(decimal usdAmount)
    {
        // TODO: ここを実装してください
        await Task.CompletedTask;
        return 0;
    }

    /// <summary>
    /// 【比較学習用】同期処理で3秒間スレッドを停止させます。
    /// </summary>
    public decimal GetJpyToUsdRateSync()
    {
        Thread.Sleep(1000);
        return 150.00m;
    }

    /// <summary>
    /// 【比較学習用】3つの外部API（USD, EUR, GBP）から同期で順番にデータを取得します（1秒×3回＝約3秒かかる）。
    /// </summary>
    public Dictionary<string, decimal> GetMultipleRatesSync()
    {
        decimal usd = FetchRateSync(150.00m);
        decimal eur = FetchRateSync(162.50m);
        decimal gbp = FetchRateSync(192.00m);

        return new Dictionary<string, decimal>
        {
            { "USD", usd },
            { "EUR", eur },
            { "GBP", gbp }
        };
    }

    private decimal FetchRateSync(decimal rate)
    {
        Thread.Sleep(1000); // 1秒のネットワーク遅延
        return rate;
    }

    /// <summary>
    /// 【比較学習用】3つの外部APIから非同期（Task.WhenAll）で同時に並行取得します（同時に1秒待つ＝約1秒で完了）。
    /// </summary>
    public async Task<Dictionary<string, decimal>> GetMultipleRatesAsync()
    {
        // 3つの非同期タスクを作成して開始（ここではまだ await しない）
        Task<decimal> fetchUsd = FetchRateAsync(150.00m);
        Task<decimal> fetchEur = FetchRateAsync(162.50m);
        Task<decimal> fetchGbp = FetchRateAsync(192.00m);

        // Task.WhenAll で 3つの非同期処理がすべて終わるのを並行待機（3つとも完了すると次に進みます）
        decimal[] results = await Task.WhenAll(fetchUsd, fetchEur, fetchGbp);

        return new Dictionary<string, decimal>
        {
            { "USD", results[0] },
            { "EUR", results[1] },
            { "GBP", results[2] }
        };
    }

    private async Task<decimal> FetchRateAsync(decimal rate)
    {
        await Task.Delay(1000); // 1秒のネットワーク遅延
        return rate;
    }
}

/// <summary>
/// APIのJSONレスポンスを受け取るためのモデルクラス例（System.Text.Json によるデシリアライズ用）
/// </summary>
public class ExchangeRateApiResponse
{
    [JsonPropertyName("base")]
    public string Base { get; set; } = "USD";

    [JsonPropertyName("rates")]
    public Dictionary<string, decimal> Rates { get; set; } = new();
}
