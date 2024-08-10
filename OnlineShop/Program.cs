using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region DataBase System Management

builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
    string ConnectionString = "OnlineShopDbContextConnection";
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(ConnectionString));
});

#endregion

#region Dependencies

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

#endregion

#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

#region Mapping Route

// MVC Area Routing for Controllers in "Customer" area
app.MapAreaControllerRoute(
    name: "area01",
    areaName: "Customer",
    pattern: "Customer/{controller=Managers}/{action=Index}/{id?}");

// MVC Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Razor Pages Routing (includes areas by default)
app.MapRazorPages();

#endregion

app.Run();
