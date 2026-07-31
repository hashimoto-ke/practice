using System.ComponentModel.DataAnnotations;

namespace _03_MvcCalculator.Models;

public class CurrencyExchangeViewModel
{
    [Required(ErrorMessage = "金額を入力してください。")]
    [Range(1, 10000000, ErrorMessage = "1から10,000,000の間で入力してください。")]
    public decimal InputAmount { get; set; } = 10000; // 入力値（上書きしない）

    public decimal Rate { get; set; }

    public string Mode { get; set; } = "JpyToUsd";

    public string? Message { get; set; }

    // 比較学習用: 処理所要時間 (ミリ秒) と複数レートメッセージ
    public long ExecutionTimeMs { get; set; }

    public string? MultipleRatesMessage { get; set; }
}
