using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_MvcCalculator.Models;

// 【Step 8】計算履歴を表す Entity（エンティティ）クラスです。
// EF Core はこのクラスの定義を元に、データベースのテーブル構造を自動的に構築します。
//
// 💡 テーブル名やカラム名の明示指定（データアノテーション属性）:
// 明示的にテーブル名を指定したい場合は [Table("テーブル名")] を付与します。
// 例: [Table("calculation_history")]
public class CalculationHistory
{
    // Id プロパティは EF Core が「主キー（Primary Key）」として自動認識します。
    // データベース側で連番が自動採番されます（オートインクリメント）。
    // 例: [Column("id")] のようにカラム名を明示指定することも可能です。
    public int Id { get; set; }

    [Required]
    // [Column("expression", TypeName = "TEXT")] // DB上のカラム名やデータ型を明示したい場合
    public string Expression { get; set; } = string.Empty; // 計算式（例: "10 + 5"）

    // [Column("result", TypeName = "NUMERIC")]
    public decimal Result { get; set; } // 計算結果

    // [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now; // 記録日時
}
