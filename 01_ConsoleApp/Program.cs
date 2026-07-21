using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            // --- 変数と型の基本 ---
            // C# では変数を宣言するとき「型 変数名 = 値;」の形式で書きます。
            string greeting = "Hello, C#!";
            double pi = 3.14;
            bool isLearning = true;

            Console.WriteLine("--- C# Console Basics ---");
            Console.WriteLine($"greeting = {greeting}");
            Console.WriteLine($"pi = {pi}");
            Console.WriteLine($"isLearning = {isLearning}");

            // var を使うと、右辺の値から型を自動で推論してくれます。
            var message = "これは var で宣言した文字列です";
            Console.WriteLine($"message = {message}");

            // TODO: 自分で新しい変数を宣言して Console.WriteLine で出力してみましょう。

            // お手本: 足し算の実行と出力
            int sum = Tashizan(a, b);
            Console.WriteLine($"Tashizan({a}, {b}) = {sum}");

            // ハンズオン: 引き算の実行と出力（TODO: Tashizan の呼び出しを参考に、Hikizan メソッドを呼び出して結果をコンソールに出力してください。）
        }

        static int Tashizan(int x, int y)
        {
            return x + y;
        }

        static int Hikizan(int x, int y)
        {
            // TODO: ここに引き算の処理を書いてください
            return 0;
        }
    }
}
