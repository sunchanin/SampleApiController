using System;
using SampleApiController.Entities;

namespace SampleApiController.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}
