using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7150")
    });

await builder.Build().RunAsync();
