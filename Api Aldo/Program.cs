using Api_Aldo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOpenApi();

builder.Services.AddHttpClient<EpisodeService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EpisodesView}/{action=Index}/{id?}");

app.Run();