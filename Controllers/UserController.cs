using System;
using Microsoft.AspNetCore.Mvc;
using SampleApiController.Data;
using SampleApiController.Entities;

namespace SampleApiController.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController(DataContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = context.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public ActionResult<AppUser> GetUserById(int id){
        var user = context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
