using Auction_TestTaskCrazyChicken;
using Auction_TestTaskCrazyChicken.Interface;
using Auction_TestTaskCrazyChicken.Repository;
using Auction_TestTaskCrazyChicken_TestTaskCrazyChicken;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<AppDBContent>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAuction, AuctionRepositiry>();
builder.Services.AddTransient<IComments, CommentRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auction}/{id}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContent>();
    context.Database.Migrate();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var content = services.GetRequiredService<AppDBContent>();
    DBObject.Initial(content);
}
app.Run();
