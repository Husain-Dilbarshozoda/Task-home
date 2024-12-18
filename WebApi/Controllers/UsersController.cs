using Domain.Models;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController(IGenericService<Users> userService):ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Users>>> GerAll()
    {
        return await userService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Users>> GetById(int id)
    {
        return await userService.GetById(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Users data)
    {
        return await userService.Add(data);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> Update(Users data)
    {
        return await userService.Update(data);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await userService.Delete(id);
    }
}