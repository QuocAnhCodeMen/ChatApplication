using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Client;

public class UserInfo
{
    [Required]
    public string? UserName { set; get; } = string.Empty;

    public string? UserId { set; get; } = string.Empty;
}