using Microsoft.EntityFrameworkCore;
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Application.Services;
using MuffinCTF.Database;
using MuffinCTF.Domain.Enum;
using MuffinCTF.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<CTFContext>(options =>
{
    options.UseSqlite("Data Source = CTFdatabase.db");
});

//IIS Hosting
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICookie, Cookie>();
builder.Services.AddScoped<ICCService, CCService>();
builder.Services.AddScoped<SeedDatabase>();

//Seed database
using (IServiceScope scope = builder.Services.BuildServiceProvider()
                                             .CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CTFContext>();
    context.Database.EnsureCreated();
    if(!context.Challenges.Any()) 
    {
        var seed = services.GetRequiredService<SeedDatabase>();
        await seed.AddToDatabase();
    }
}

var app = builder.Build();

//IIS hosting
app.UsePathBase("/MuffinCTF");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
