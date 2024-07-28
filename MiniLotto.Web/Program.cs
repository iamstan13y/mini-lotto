using MiniLotto.Web.Components;
using MiniLotto.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var url = $"{builder.Configuration["ApiServices:MiniLottoApi"]}";
builder.Services.AddHttpClient<IHttpService, HttpService>(c => 
    c.BaseAddress = new Uri(url));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
