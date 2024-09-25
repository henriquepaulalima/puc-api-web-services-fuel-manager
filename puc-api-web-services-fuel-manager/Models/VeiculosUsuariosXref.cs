using System.ComponentModel.DataAnnotations.Schema;

namespace puc_api_web_services_fuel_manager.Models
{
    [Table("VeiculosUsuariosXref")]
    public class VeiculosUsuariosXref
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
