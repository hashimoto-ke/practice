using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            Console.WriteLine("--- C# Console Basics ---");

            // お手本: 足し算の実行と出力
            int sum = Tashizan(a, b);
            Console.WriteLine($"Tashizan({a}, {b}) = {sum}");

            // ハンズオン: 引き算の実行（TODO: 以下のコメントアウトを解除し、Hikizanメソッドを実装してください）
            // int difference = Hikizan(a, b);
            // Console.WriteLine($"Hikizan({a}, {b}) = {difference}");
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
