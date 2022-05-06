using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.Model.Dto.Account
{
    public class RegisterFormDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email daxil ele xair")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
