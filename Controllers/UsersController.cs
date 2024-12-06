using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApiController.DTOs;
using SampleApiController.Entities;
using SampleApiController.Extensions;
using SampleApiController.Interfaces;

namespace SampleApiController.Controllers;


public class UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService) : BaseApiController
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

    [Authorize]
    [HttpPost("add-photo")]
    public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
    {

        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        var result = await photoService.AddPhotoAsync(file);

        if (result.Error != null) return BadRequest(result.Error.Message);

        var photo = new Photo
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        user.Photos.Add(photo);

        if (await userRepository.SaveAllSync()) return mapper.Map<PhotoDto>(photo);

        return BadRequest("Problem adding photo");
    }
}


