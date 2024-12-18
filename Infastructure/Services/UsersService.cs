using System.Net;
using Dapper;
using Domain.Models;
using Infratructure.DataContext;
using Infratructure.Responses;
using Infratructure.Services;

namespace Infastructure.Services;

public class UsersService(IContext context):IGenericService<Users>
{
    public async Task<ApiResponse<List<Users>>> GetAll()
    {
        using var connection = context.Connection();
        var sql = "select * from Users;";
        var res = (await connection.QueryAsync<Users>(sql)).ToList();
        return new ApiResponse<List<Users>>(res);
    }

    public async Task<ApiResponse<Users>> GetById(int id)
    {
        using var connection = context.Connection();
        var sql = "select * from Users where UserId=@ID";
        var res = await connection.QueryFirstOrDefaultAsync<Users>(sql, new { ID = id });
        return new ApiResponse<Users>(res);
    }

    public async Task<ApiResponse<bool>> Add(Users data)
    {
        using var connection = context.Connection();
        var sql = "insert into Users(FullName,Email,Phone,City,CreatedAt) values(@FullName,@Email,@Phone,@City,@CreatedAt)";
        var res = await connection.ExecuteAsync(sql, data);
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<bool>> Update(Users data)
    {
        using var connection = context.Connection();
        var sql = "update Users set FullName=@FullName,Email=@Email,Phone=@Phone,City=@City,CreatedAt=@CreatedAt where UserId=@UserId;";
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
        var sql = "delete from users where userid=@ID;";
        var res =await connection.ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Server error");
        }

        return new ApiResponse<bool>(res != 0);
    }
}