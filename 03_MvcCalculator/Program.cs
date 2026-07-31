using _03_MvcCalculator.Data;
using _03_MvcCalculator.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// TODO: ここで作成した CalculatorService を ICalculatorService に紐付けて DI コンテナに登録してください。
// ヒント: builder.Services.AddScoped<インターフェース名, 実装クラス名>(); のように記述します。

// 【Step 7】ICurrencyService の DI 登録
// AddHttpClient は HttpClient を DI コンテナで管理するための設定です。
// CurrencyService は IHttpClientFactory ではなく、ここで登録された HttpClient を受け取ります。
builder.Services.AddHttpClient<ICurrencyService, CurrencyService>();

// 【Step 8】CalculatorDbContext の DI 登録（SQLite 接続設定）
// AddDbContext でDbContextをDIコンテナに登録します。
// UseSqlite により、SQLite データベースファイル（calculator.db）に接続します。
builder.Services.AddDbContext<CalculatorDbContext>(options =>
    options.UseSqlite("Data Source=calculator.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
