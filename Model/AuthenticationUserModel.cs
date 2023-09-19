using System.ComponentModel.DataAnnotations;

public class AuthenticationUserModel
{
    [Required(ErrorMessage = "Email address is required")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}