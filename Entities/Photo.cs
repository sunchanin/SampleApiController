using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApiController.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    // Navigation properties
    public int UserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

}
