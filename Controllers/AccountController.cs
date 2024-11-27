using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApiController.Data;
using SampleApiController.DTOs;
using SampleApiController.Entities;
using SampleApiController.Interfaces;
using SampleApiController.Services;

namespace SampleApiController.Controllers;


public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")] // account/register
    
    public async Task<ActionResult<AppUser>> Register([FromBody] RegisterDto registerDto)
    {
        if(await UserExists(registerDto.Username))
        {
            return BadRequest("Username already exists");

        }

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = registerDto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    [HttpPost("login")] // account/login
    public async Task<ActionResult<UserDto>> Login (LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Username == loginDto.Username.ToLower());
        if(user == null)
        {
            return Unauthorized("Invalid username or password");
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i ++)
        {
            if(computedHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid username or password");
            }
        }

        return Ok(new UserDto {
            Username = user.Username,
            Token = tokenService.CreateToken(user)
        });
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower());
    }

}
