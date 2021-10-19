using System.ComponentModel.DataAnnotations;

namespace MudBlazor.Battleship.Models
{
    public class SignInForm
    {
        [Required]
        [StringLength(8, ErrorMessage = "Username length can't be more than 8.")]
        public string Username { get; set; }
    }
}
