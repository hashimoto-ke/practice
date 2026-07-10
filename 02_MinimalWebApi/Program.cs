var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to Minimal Web API!");

// お手本: 足し算エンドポイント (/tashizan?a=10&b=5)
app.MapGet("/tashizan", (int a, int b) =>
{
    int result = a + b;
    return $"{a} + {b} = {result}";
});

// ハンズオン: 引き算エンドポイント (/hikizan?a=10&b=5)
app.MapGet("/hikizan", (int a, int b) =>
{
    // TODO: 引き算の結果を返すように実装してください
    return "ここを書き換えてね";
});

app.Run();
