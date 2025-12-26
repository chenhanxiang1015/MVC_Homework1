var builder = WebApplication.CreateBuilder(args);

// 添加MVC服务到容器
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 配置HTTP请求管道
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // 生产环境异常处理
}

app.UseStaticFiles(); // 启用静态文件访问（核心修正：添加这行）
app.UseRouting(); // 路由中间件
app.UseAuthorization(); // 授权中间件

// 配置默认MVC控制器路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run(); // 启动应用
