using Domain.Models;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SkillsController(IGenericService<Skills> skillsService):ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Skills>>> GerAll()
    {
        return await skillsService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Skills>> GetById(int id)
    {
        return await skillsService.GetById(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Skills data)
    {
        return await skillsService.Add(data);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> Update(Skills data)
    {
        return await skillsService.Update(data);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await skillsService.Delete(id);
    }
}