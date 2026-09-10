namespace _03_MvcCalculator.Models;

public class LinqDemoViewModel
{
    // 実行したクエリのタイトル（例: "結果がプラスの履歴のみ抽出 (Where)"）
    public string QueryTitle { get; set; } = "全件表示";

    // 実行したクエリの説明・コード例
    public string QueryDescription { get; set; } = string.Empty;

    // 抽出された計算履歴リスト
    public List<CalculationHistory> FilteredHistories { get; set; } = new();

    // 集計結果データ
    public int TotalCount { get; set; }
    public decimal? SumResult { get; set; }
    public decimal? AverageResult { get; set; }
    public decimal? MaxResult { get; set; }
    public decimal? MinResult { get; set; }

    // 判定結果（例: Any）
    public string? JudgeMessage { get; set; }

    // 現在選択されているモード
    public string CurrentMode { get; set; } = "All";
}
