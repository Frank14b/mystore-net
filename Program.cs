// using Store.Dto;
using Store.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// homemanag@homemanag.iam.gserviceaccount.com

string? connectionString = builder.Configuration["connectionString"];

// string Server = "tcp:homemanag:us-central1:homemanag.database.windows.net,1433";
// string Catalog = "mystore";
// string User = "Frank14b";
// string? Password = builder.Configuration["password"];
// bool Encrypt = true;
// bool TrustServerCertificate = false;
// bool MultipleActiveResultSets = false;
// int Connection = 30;

string Server = "tcp:homemanag:us-central1:homemanag.database.windows.net,1433";
string Catalog = "mystore";
string User = "Frank14b";
string? Password = builder.Configuration["password"];
bool Encrypt = true;
bool TrustServerCertificate = false;
bool MultipleActiveResultSets = false;
int Connection = 30;

// connectionString = "Server=" + Server + ";Initial Catalog=" + Catalog + ";User ID=" + User + ";Password=" + Password + ";Encrypt=" + Encrypt + ";TrustServerCertificate=" + TrustServerCertificate + ";MultipleActiveResultSets=" + MultipleActiveResultSets + ";Connection Timeout=" + Connection;

connectionString = "Server=tcp:homemanag.database.windows.net,1433;Initial Catalog=mystore;Persist Security Info=False;User ID=Frank14b;Password=Dotrack@2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
// connectionString = "SERVER=" + Server + "; " +
//             "DATABASE=mystore; " +
//             "UID=" + User + "; " +
//             "PWD=" + Password + ";";

if (connectionString == null)
{
    Console.WriteLine("You must set your 'connectionString' environment variable.");
    Environment.Exit(0);
}

Console.WriteLine(connectionString);

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(connectionString ?? "");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
