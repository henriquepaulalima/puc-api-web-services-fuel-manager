using System.ComponentModel.DataAnnotations;

namespace puc_api_web_services_fuel_manager.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
