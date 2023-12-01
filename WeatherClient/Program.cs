using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherClient;
using WeatherClient.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("WeatherApi", client =>
        client.BaseAddress = new Uri("https://localhost:7252"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("WeatherApi"));

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = builder.Configuration.GetValue<string>("Okta:Authority");
    options.ProviderOptions.ClientId = builder.Configuration.GetValue<string>("Okta:ClientId"); ;
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
