using System;

namespace SampleApiController.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string Username { get; set; }
}
