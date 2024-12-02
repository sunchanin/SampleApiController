using System;

namespace SampleApiController.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public DateTime Created { get; set; }
    public List<PhotoDto> Photos { get; set; } = [];

}
