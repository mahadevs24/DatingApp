using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[Authorize]
public class UsersController : BaseAPIController
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {

        _userRepository = userRepository;
        _mapper = mapper;
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetmembersAsyc();
        // var userstoReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(users);

    }

    [HttpGet("{username}")]

    public async Task<ActionResult<MemberDto>> GetUser(string UserName)
    {
        return await _userRepository.GetmemberByUsernameAsync(UserName);

    }
}