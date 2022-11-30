using Microsoft.EntityFrameworkCore;
using MuffinCTF.Application.Abstractions;
using MuffinCTF.Application.Services;
using MuffinCTF.Database;
using MuffinCTF.Domain;
using MuffinCTF.Domain.Enum;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<CTFContext>(options =>
{
    options.UseSqlite("Data Source = CTFdatabase.db");
});
builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICookie, Cookie>();
builder.Services.AddScoped<CCService>();

var app = builder.Build();

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
