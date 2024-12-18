using System.Net;
using Dapper;
using Domain.Models;
using Infratructure.DataContext;
using Infratructure.Responses;
using Infratructure.Services;

namespace Infastructure.Services;

public class RequestsService(IContext context):IGenericService<Requests>
{
    public async Task<ApiResponse<List<Requests>>> GetAll()
    {
        using var connection = context.Connection();
        var sql = "select * from Requests";
        var res = (await connection.QueryAsync<Requests>(sql)).ToList();
        return new ApiResponse<List<Requests>>(res);
    }

    public async Task<ApiResponse<Requests>> GetById(int id)
    {
        using var connection = context.Connection();
        var sql = "select * from Requests where RequestId = @ID";
        var res = await connection.QueryFirstOrDefaultAsync<Requests>(sql, new { ID = id });
        return new ApiResponse<Requests>(res);
    }

    public async Task<ApiResponse<bool>> Add(Requests data)
    {
        using var connection = context.Connection();
        var sql = "insert into Requests(Status,CreatedAt,UpdatedAt,FromUserId,ToUserId,RequestedSkillId,OfferedSkillId) values(@Status,@CreatedAt,@UpdatedAt,@FromUserId,@ToUserId,@RequestedSkillId,@OfferedSkillId);";
        var res = await connection.ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<bool>> Update(Requests data)
    {
        using var connection = context.Connection();
        var sql = "update Requests set Status=@Status,CreatedAt=@CreatedAt,UpdatedAt=@UpdatedAt,FromUserId=@FromUserId,ToUserId=@ToUserId,RequestedSkillId=@RequestedSkillId,OfferedSkillId=@OfferedSkillId where RequestId=@RequestId;";
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
        var sql = "delete from Requests where RequestId=@ID";
        var res = await connection.ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);    }
}