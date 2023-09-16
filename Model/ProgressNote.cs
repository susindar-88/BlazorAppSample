using System.ComponentModel.DataAnnotations;

public class ProgressNote
{
    [Required]
    public Patient? Patient { get; set; }

    public int ID { get; set; }

    [Required]
    public string VisitDate { get; set; } = DateTime.Now.ToString();
}