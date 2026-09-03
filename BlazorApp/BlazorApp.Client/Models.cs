using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Client;

public class UserInfo
{
    [Required]
    public string? UserName { set; get; } = string.Empty;
}