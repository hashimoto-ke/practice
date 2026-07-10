using Microsoft.AspNetCore.Mvc;
using _03_MvcCalculator.Models;

namespace _03_MvcCalculator.Controllers;

// コントローラークラスは、複数の「エンドポイント（Webアクセス時の処理の受付窓口）」をまとめるグループです。
// クラス名が「CalculatorController」の場合、URLの「/Calculator/...」の部分に対応します。
public class CalculatorController : Controller
{
    // 【Step 4】フォーム画面を表示するアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Index」 または 「/Calculator」 にアクセスしたとき
    // [HttpGet] は「ブラウザでURLを入力して普通のページを開く（データを取得する）とき」に動くことを指定する属性です。
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // 【Step 3】お手本: Tashizanアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Tashizan」 にアクセスしたとき
    // アクションの上に属性（[HttpGet]など）を省略した場合は、デフォルトで GET リクエストに対応します。
    public IActionResult Tashizan()
    {
        int a = 10;
        int b = 5;
        int result = a + b;
        ViewBag.Message = $"{a} + {b} = {result}";
        return View();
    }

    // 【Step 3】ハンズオン: Hikizanアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Hikizan」 にアクセスしたとき
    public IActionResult Hikizan()
    {
        // TODO: 引き算結果を ViewBag.Message に代入してください。
        // ヒント: Tashizan アクションでの ViewBag.Message の使い方や計算方法を参考にしてください。
        return View();
    }

    // 【Step 4】送信フォームの計算処理
    // 対応するアクセス: POSTリクエスト で 「/Calculator/Calculate」 にアクセスしたとき
    // [HttpPost] は「HTMLのフォーム送信などにより、サーバーへデータを送りつける（POST）とき」に動くことを指定する属性です。
    // ブラウザのURL欄に直接「/Calculator/Calculate」を入力（GETリクエスト）しても、このメソッドは動かない（エラーになる）仕組みです。
    [HttpPost]
    public IActionResult Calculate(int a, int b)
    {
        // フォームから送られた数値を計算し、実務で推奨される「ViewModel」オブジェクトに格納してビューに渡します
        var viewModel = new CalculatorResultViewModel
        {
            A = a,
            B = b,
            Sum = a + b,
            Diff = a - b
        };
        return View("Result", viewModel);
    }
}
