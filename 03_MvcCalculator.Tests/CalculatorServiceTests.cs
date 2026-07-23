using Xunit;
using _03_MvcCalculator.Services;

namespace _03_MvcCalculator.Tests;

public class CalculatorServiceTests
{
    // =========================================================================
    // 【お手本 1】[Fact] を使った単一の固定テスト
    // [Fact] はパラメータを取らない固定のテストケースに使います。
    // 「常に成立すべき事実（Fact）」を検証する際に適しています。
    // =========================================================================
    [Fact]
    public void Tashizan_SimpleValues_ReturnsSum()
    {
        // 1. Arrange (準備): テストに必要なオブジェクトや入力データを準備します
        var service = new CalculatorService();
        int a = 10;
        int b = 5;

        // 2. Act (実行): テスト対象のメソッドを実行します
        int result = service.Tashizan(a, b);

        // 3. Assert (検証): resultが期待通りの結果（15）になっているか確認します
        Assert.Equal(15, result);
    }

    // =========================================================================
    // 【お手本 2】[Theory] と [InlineData] を使った複数データのテスト
    // [Theory] はパラメータを受け取るテストに使います。
    // [InlineData(引数1, 引数2, 期待する結果)] を複数並べることで、
    // 1つのテストメソッドで複数のパターン（0、負の数など）をまとめて検証できます。
    // =========================================================================
    [Theory]
    [InlineData(10, 5, 15)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, 5, 0)]
    [InlineData(100, -50, 50)]
    public void Tashizan_MultipleValues_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Arrange
        var service = new CalculatorService();

        // Act
        int result = service.Tashizan(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    // =========================================================================
    // 【ハンズオン課題】引き算（Hikizan）のテストを作成してみましょう！
    // TODO: AAA(Arrange, Act, Assert)パターンのテストコードを書いてみましょう。
    // TODO: [Theory] と [InlineData] を使って、引き算が正しく動作するか検証してください。
    // =========================================================================
    [Theory]
    [InlineData(10, 5, 5)]
    // TODO: 他のデータパターン（例: 0 - 0 = 0 や 5 - 10 = -5 など）の [InlineData] を追加してみましょう
    public void Hikizan_MultipleValues_ReturnsCorrectDifference(int a, int b, int expected)
    {
        // TODO: ここにテストコードを追加してください。
    }
}
