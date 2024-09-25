namespace puc_api_web_services_fuel_manager.Models
{
    public class UsuarioDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public Perfil Perfil { get; set; }
    }
}
