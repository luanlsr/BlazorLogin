namespace AppContas.Web.Responses
{
    public class RecuperarSenhaResponse
    {
        public string? Messagem { get; set; }
        public UsuarioResponse? Usuario { get; set; }
        public string? AccessToken { get; set; }
    }
}
