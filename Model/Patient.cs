using System.ComponentModel.DataAnnotations;

public class Patient
{
    public int ID { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;


    [Required]
    public string State { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    public string CreatedAt { get; set; } = string.Empty;

    public string UpdatedAt { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }
}