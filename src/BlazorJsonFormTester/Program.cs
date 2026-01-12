using BlazorJsonForm;
using BlazorJsonFormTester.Components;
using BlazorJsonFormTester.Core.Localization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices( config =>
{
    config.SnackbarConfiguration.PositionClass
        = Defaults.Classes.Position.BottomCenter;
} );

builder.Services.AddScoped<IJsonFormLocalizer, Localizer>();

var app = builder.Build();

if ( !app.Environment.IsDevelopment() )
    app.UseExceptionHandler( "/Error", createScopeForErrors: true );

app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();