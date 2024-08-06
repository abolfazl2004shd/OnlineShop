using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region DataBase System Management

builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:OnlineShopDbContextConnection"]
        );
});
#endregion

#region Dependencies
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
#endregion



#region Authentication

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    option =>
    {
        option.LoginPath = "/Account/Login";
        option.LogoutPath = "/Account/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(30);
    });


#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


#region Mapping Route
app.MapRazorPages();
app.MapAreaControllerRoute(
    name: "area01",
    areaName: "Manager",
    pattern: "Manager/{controller=Managers}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "area02",
    areaName: "Customer",
    pattern: "Customer/{controller=Managers}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion


app.Run();