using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApiController.Data;
using SampleApiController.DTOs;
using SampleApiController.Entities;
using SampleApiController.Interfaces;

namespace SampleApiController.Controllers;


public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();
        return Ok(users);

    }

    [Authorize]
    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUserById(string username)
    {
        var user = await userRepository.GetMemberAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}


