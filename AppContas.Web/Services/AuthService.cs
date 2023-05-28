using AppContas.Web.Responses;
using Blazored.LocalStorage;
using Newtonsoft.Json;
//using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AppContas.Web.Services
{
    /// <summary>
    /// Classe d serviço para operações de autenticação de usuários
    /// </summary>
    public class AuthService
    {
        private readonly ILocalStorageService _localStorageService;
        private const string _key = "appconta-auth";

        public AuthService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Método para salvar os dados de autenticação do usuário no LocalStorage
        /// </summary>
        public async Task SignIn(AutenticarResponse data)
        {
            var json = JsonConvert.SerializeObject(data);
            await _localStorageService.SetItemAsync(_key, json);
        }

        /// <summary>
        /// Método para verificar se o usuário está autenticado
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsSigningIn()
        {
            var json = await _localStorageService.GetItemAsync<string>(_key);
            if(!string.IsNullOrEmpty(json))
            {
                var data = JsonConvert.DeserializeObject<AutenticarResponse>(json);
                return data.DataExpiracao >= DateTime.Now;
            }
            return false;
        }

        /// <summary>
        /// Método para retornar os dados de autenticação do usuário do LocalStorage
        /// </summary>
        /// <returns></returns>
        public async Task<AutenticarResponse> GetData()
        {
            var json = await _localStorageService.GetItemAsync<string>(_key);
            return JsonConvert.DeserializeObject<AutenticarResponse>(json);
        }

        /// <summary>
        /// Apagar as informações de autenticação do usuário do LocalStorage
        /// </summary>
        /// <returns></returns>
        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }

    }
}
