using Microsoft.AspNetCore.HttpOverrides;
using UserControl.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseAuthorization();

app.MapControllers();

app.Run();
