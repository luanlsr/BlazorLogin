using AppContas.Web;
using AppContas.Web.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Mapeamento de inje��o de depend�ncia para a classe HttpClient
builder.Services.AddScoped(sp => new HttpClient { 

    //Configura��o de endere�o padr�o (default)
    //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    BaseAddress = new Uri("http://appcontasblazor-001-site1.htempurl.com/api/")
});
//Registrando os servi�os da biblioteca Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();

//Mapeando inje��o de depend�ncia da classe AuthService
builder.Services.AddTransient<AuthService>();

await builder.Build().RunAsync();

