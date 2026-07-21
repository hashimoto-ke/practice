using Microsoft.AspNetCore.Mvc;
using _03_MvcCalculator.Models;
using _03_MvcCalculator.Services;

namespace _03_MvcCalculator.Controllers;

// コントローラークラスは、複数の「エンドポイント（Webアクセス時の処理の受付窓口）」をまとめるグループです。
// クラス名が「CalculatorController」の場合、URLの「/Calculator/...」の部分に対応します。
public class CalculatorController : Controller
{
    private readonly ICalculatorService _calculatorService = null!;

    // TODO: 【Step 5 (DI)】ここで ICalculatorService をコンストラクタ注入（DI）で受け取るコンストラクタを定義してください。
    // ヒント: クラス名と同名のアクションではない公開メソッド（コンストラクタ）を定義し、引数で ICalculatorService を受け取って、フィールド _calculatorService に代入（保持）します。

    // 【Step 4】フォーム画面を表示するアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Index」 または 「/Calculator」 にアクセスしたとき
    // [HttpGet] は「ブラウザでURLを入力して普通のページを開く（データを取得する）とき」に動くことを指定する属性です。
    [HttpGet]
    public IActionResult Index()
    {
        // クラス（設計図）から「new」キーワードを使ってインスタンス（実体）を生成します。
        // これにより、メモリ上にデータを入れるハコ（オブジェクト）が作られます。
        var model = new CalculatorResultViewModel
        {
            A = 10,
            B = 5
        };
        return View(model);
    }

    // 【Step 3】お手本: Tashizanアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Tashizan」 にアクセスしたとき
    // アクションの上に属性（[HttpGet]など）を省略した場合は、デフォルトで GET リクエストに対応します。
    public IActionResult Tashizan()
    {
        int a = 10;
        int b = 5;
        // TODO: 【Step 5 (DI)】直接の計算式（a + b）から、DI された _calculatorService を使う形に書き換えてください。
        // ヒント: _calculatorService.Tashizan(a, b) のように呼び出します。
        int result = a + b;
        ViewBag.Message = $"{a} + {b} = {result}";
        return View();
    }

    // 【Step 3】ハンズオン: Hikizanアクション
    // 対応するアクセス: GETリクエスト で 「/Calculator/Hikizan」 にアクセスしたとき
    public IActionResult Hikizan()
    {
        // TODO: 引き算結果を ViewBag.Message に代入してください。
        return View();
    }

    // 【Step 4】送信フォームの計算処理
    // 対応するアクセス: POSTリクエスト で 「/Calculator/Calculate」 にアクセスしたとき
    // [HttpPost] は「HTMLのフォーム送信などにより、サーバーへデータを送りつける（POST）とき」に動くことを指定する属性です。
    // ブラウザのURL欄に直接「/Calculator/Calculate」を入力（GETリクエスト）しても、このメソッドは動かない（エラーになる）仕組みです。
    [HttpPost]
    public IActionResult Calculate(CalculatorResultViewModel model)
    {
        // ModelState.IsValid は、送られてきたデータ（model）がクラス内で定義した検証ルール（バリデーション）を満たしているかをチェックします。
        // ルール違反がある場合は false になり、入力された値を保持したまま元のフォーム画面（Indexビュー）を表示します。
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        // TODO: 【Step 5 (DI)】直接の計算式から、DI された _calculatorService を使う形に書き換えてください。
        // ヒント: _calculatorService の Tashizan メソッドや Hikizan メソッドを呼び出します。
        model.Sum = model.A!.Value + model.B!.Value;
        model.Diff = model.A!.Value - model.B!.Value;

        return View("Result", model);
    }
}
