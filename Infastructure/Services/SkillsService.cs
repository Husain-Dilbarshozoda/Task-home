using System.Net;
using Dapper;
using Domain.Models;
using Infratructure.DataContext;
using Infratructure.Responses;
using Infratructure.Services;

namespace Infastructure.Services;

public class SkillsService(IContext context):IGenericService<Skills>
{
    public async Task<ApiResponse<List<Skills>>> GetAll()
    {
        using var connection = context.Connection();
        var sql = "select * from Skills";
        var res = (await connection.QueryAsync<Skills>(sql)).ToList();
        return new ApiResponse<List<Skills>>(res);
    }

    public async Task<ApiResponse<Skills>> GetById(int id)
    {
        using var connection = context.Connection();
        var sql = "select * from Skills where SkillId=@ID";
        var res = await connection.QueryFirstOrDefaultAsync<Skills>(sql, new { ID = id });
        return new ApiResponse<Skills>(res);
    }

    public async Task<ApiResponse<bool>> Add(Skills data)
    {
        using var connection = context.Connection();
        var sql = "insert into Skills(Title,Description,CreatedAt,UserId) values(@Title,@Description,@CreatedAt,@UserId)";
        var res = await connection.ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<bool>> Update(Skills data)
    {
        using var connection = context.Connection();
        var sql = "update Skills set Title=@Title,Description=@Description,CreatedAt=@CreatedAt,UserId=@UserId where SkillId=@SkillId";
        var res = await connection.ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        var sql = "delete from Skills where SkillId=@ID";
        var res = await connection.ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }
}