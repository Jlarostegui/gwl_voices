using System.ComponentModel.DataAnnotations;


namespace gwl_voices.BusinessModels.Models.login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El campo usuario es Obligatorio")]
        public string? user { get; set; }

        [Required(ErrorMessage = "El campo password es Obligatorio")]
        public string? password { get; set; }
    }
}
