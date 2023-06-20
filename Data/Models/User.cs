using System.ComponentModel.DataAnnotations;

namespace Reactjs_api.Data.Models;

public class User
{
    [Key] public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Birthday { get; set; }
    public string? City { get; set; }
    public string? Education { get; set; }
    public string? Website { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public bool IsFollowed { get; set; } = false;
}