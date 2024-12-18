using Domain.Models;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RequestsController(IGenericService<Requests> RequestsService):ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Requests>>> GerAll()
    {
        return await RequestsService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Requests>> GetById(int id)
    {
        return await RequestsService.GetById(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Requests data)
    {
        return await RequestsService.Add(data);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> Update(Requests data)
    {
        return await RequestsService.Update(data);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await RequestsService.Delete(id);
    }
}