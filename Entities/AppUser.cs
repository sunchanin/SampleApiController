using System;

namespace SampleApiController.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public List<Photo> Photos { get; set; } = [];
}
