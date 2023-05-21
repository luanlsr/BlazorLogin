using AppContas.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using static System.Net.WebRequestMethods;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Mapeamento de injeção de dependência para a classe HttpClient
builder.Services.AddScoped(sp => new HttpClient { 

    //Configuração de endereço padrão (default)
    //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    BaseAddress = new Uri("http://appcontasblazor-001-site1.htempurl.com/api/")
});

await builder.Build().RunAsync();
