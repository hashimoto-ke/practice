using Microsoft.EntityFrameworkCore;
using _03_MvcCalculator.Models;

namespace _03_MvcCalculator.Data;

// 【Step 8】DbContext はデータベースとのやり取りを管理するクラスです。
// DbContext を継承することで、EF Core の機能（LINQ によるクエリ、Change Tracking など）が使えるようになります。
public class CalculatorDbContext : DbContext
{
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
    {
    }

    // DbSet<T> は「テーブルに対応するプロパティ」です。
    // LINQ クエリやデータ追加・削除はこのプロパティを通じて行います。
    public DbSet<CalculationHistory> CalculationHistory { get; set; }
}
