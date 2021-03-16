using System.ComponentModel.DataAnnotations;

namespace AxonCFS.Application.BindingModels
{
    public class LoginBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}