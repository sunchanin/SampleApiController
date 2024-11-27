using System;
using System.ComponentModel.DataAnnotations;

namespace SampleApiController.DTOs;

public class LoginDto
{
    [Required]
    public required string Username { get; set; }
    
    [Required]
    public required string Password { get; set; }
}