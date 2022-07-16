using bugraGundoganASP.business.Abstract;
using bugraGundoganASP.business.Concrete;
using bugraGundoganASP.data.Abstract;
using bugraGundoganASP.data.Concrete.EfCore;
using bugraGundoganASP.webUI.EmailServices;
using bugraGundoganASP.webUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => {
    // password
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;      
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".ShopApp.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };
});

builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                 new SmtpEmailSender(
                     builder.Configuration["EmailSender:Host"],
                     builder.Configuration.GetValue<int>("EmailSender:Port"),
                     builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                     builder.Configuration["EmailSender:UserName"],
                     builder.Configuration["EmailSender:Password"]));

builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    SeedDatabase.Seed();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
        name: "orders",
        pattern: "orders",
        defaults: new { controller = "Cart", action = "GetOrders" }
);


app.MapControllerRoute(
    name: "checkout",
    pattern: "checkout",
    defaults: new { controller = "Cart", action = "Checkout" }
);

app.MapControllerRoute(
    name: "cart",
    pattern: "cart",
    defaults: new { controller = "Cart", action = "Index" }
);

app.MapControllerRoute(
   name: "adminusers",
   pattern: "admin/user/list",
   defaults: new { controller = "Admin", action = "UserList" }
);

app.MapControllerRoute(
    name: "adminuseredit",
    pattern: "admin/user/{id?}",
    defaults: new { controller = "Admin", action = "UserEdit" }
);

app.MapControllerRoute(
    name: "adminroles",
    pattern: "admin/role/list",
    defaults: new { controller = "Admin", action = "RoleList" }
);

app.MapControllerRoute(
    name: "adminrolecreate",
    pattern: "admin/role/create",
    defaults: new { controller = "Admin", action = "RoleCreate" }
);

app.MapControllerRoute(
    name: "adminroleedit",
    pattern: "admin/role/{id?}",
    defaults: new { controller = "Admin", action = "RoleEdit" }
);

app.MapControllerRoute(
    name: "adminproducts",
    pattern: "admin/products",
    defaults: new { controller = "Admin", action = "ProductList" }
);

app.MapControllerRoute(
    name: "adminproductcreate",
    pattern: "admin/products/create",
    defaults: new { controller = "Admin", action = "ProductCreate" }
);

app.MapControllerRoute(
    name: "adminproductedit",
    pattern: "admin/products/{id?}",
    defaults: new { controller = "Admin", action = "ProductEdit" }
);

app.MapControllerRoute(
    name: "admincategories",
    pattern: "admin/categories",
    defaults: new { controller = "Admin", action = "CategoryList" }
);

app.MapControllerRoute(
    name: "admincategorycreate",
    pattern: "admin/categories/create",
    defaults: new { controller = "Admin", action = "CategoryCreate" }
);

app.MapControllerRoute(
    name: "admincategoryedit",
    pattern: "admin/categories/{id?}",
    defaults: new { controller = "Admin", action = "CategoryEdit" }
);

app.MapControllerRoute(
    name: "search",
    pattern: "search",
    defaults: new { controller = "Shop", action = "search" });

app.MapControllerRoute(
    name: "products",
    pattern: "products/{category?}",
    defaults: new { controller = "Shop", action = "list" });

app.MapControllerRoute(
    name: "productdetails",
    pattern: "{url}",
    defaults: new { controller = "Shop", action = "details" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    SeedIdentity.Seed(userManager, roleManager, builder.Configuration).Wait();
}

app.Run();
