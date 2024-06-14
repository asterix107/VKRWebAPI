using Microsoft.EntityFrameworkCore;
using VKRWebAPI.Clients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

string connection = "Data Source=app.db";

string connectionsInfo = "Data Source=Info.db";

builder.Services.AddDbContext<ContextBD>(options => options.UseSqlite(connection));

builder.Services.AddDbContext<InfoContextDB>(options => options.UseSqlite(connectionsInfo));

var app = builder.Build();

app.MapRazorComponents<Home>().AddInteractiveServerRenderMode();

app.UseDefaultFiles();

app.UseAntiforgery();

app.Run();
