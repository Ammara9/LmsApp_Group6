using LMS.Blazor.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// register api service for calls originating from WASM
builder.Services.AddScoped<IApiService, ClientApiService>();

builder.Services.AddHttpClient(
    "BffClient",
    cfg =>
    {
        cfg.BaseAddress = new Uri("https://localhost:7044/");
    }
);

// Register the default HttpClient for direct use in Razor components
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("BffClient")
);

builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

//course services register
//builder.Services.AddScoped<CourseServices>();

await builder.Build().RunAsync();
