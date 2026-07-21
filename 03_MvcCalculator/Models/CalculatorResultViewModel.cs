using System.ComponentModel.DataAnnotations;

namespace _03_MvcCalculator.Models;

public class CalculatorResultViewModel
{
    // お手本: 数値Aに対する必須検証と範囲検証
    [Required(ErrorMessage = "数値 A は必須入力です。")]
    [Range(-9999, 9999, ErrorMessage = "数値 A は -9999 から 9999 の範囲で入力してください。")]
    public int? A { get; set; } // int? (nullable)にすることで、未入力を検知できるようになります。

    // TODO: 数値Bに対しても、必須検証（Required）と範囲検証（Range: -9999〜9999）の属性を追加してください。
    // ヒント: 数値Aに設定されている属性を参考にしてください。
    public int? B { get; set; }

    public int Sum { get; set; }
    public int Diff { get; set; }
}
