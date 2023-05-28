using AppContas.Web;
using AppContas.Web.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Mapeamento de injeção de dependência para a classe HttpClient
builder.Services.AddScoped(sp => new HttpClient { 

    //Configuração de endereço padrão (default)
    //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    BaseAddress = new Uri("http://appcontasblazor-001-site1.htempurl.com/api/")
});
//Registrando os serviços da biblioteca Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();

//Mapeando injeção de dependência da classe AuthService
builder.Services.AddTransient<AuthService>();

await builder.Build().RunAsync();

