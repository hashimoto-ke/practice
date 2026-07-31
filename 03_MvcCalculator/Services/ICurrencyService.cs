namespace _03_MvcCalculator.Services;

public interface ICurrencyService
{
    /// <summary>
    /// 日本円 (JPY) から 米ドル (USD) への換算を非同期で実行します。
    /// </summary>
    Task<decimal> ConvertJpyToUsdAsync(decimal jpyAmount);

    /// <summary>
    /// 最新の為替レート (1 USD あたりの JPY) を非同期で取得します。
    /// </summary>
    Task<decimal> GetJpyToUsdRateAsync();

    /// <summary>
    /// 【ハンズオン】米ドル (USD) から 日本円 (JPY) への換算を非同期で実行します。
    /// CurrencyService.cs にてメソッドを実装してください。
    /// </summary>
    Task<decimal> ConvertUsdToJpyAsync(decimal usdAmount);
    /// <summary>
    /// 【比較学習用】最新の為替レートを「同期（Thread.Sleep）」で取得します。
    /// </summary>
    decimal GetJpyToUsdRateSync();

    /// <summary>
    /// 【比較学習用】3つの通貨レート（USD, EUR, GBP）を「同期（順番に待つ）」で取得します。
    /// </summary>
    Dictionary<string, decimal> GetMultipleRatesSync();

    /// <summary>
    /// 【比較学習用】3つの通貨レート（USD, EUR, GBP）を「非同期（Task.WhenAll で同時に待つ）」で取得します。
    /// </summary>
    Task<Dictionary<string, decimal>> GetMultipleRatesAsync();
}

