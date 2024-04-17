using System.ComponentModel.DataAnnotations;

namespace Day9.Models.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
