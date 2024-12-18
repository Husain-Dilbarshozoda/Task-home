using Domain.Models;
using Infastructure.Services;
using Infratructure.DataContext;
using Infratructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IContext, DapperContext>();
builder.Services.AddScoped<IGenericService<Users>,UsersService>();
builder.Services.AddScoped<IGenericService<Skills>, SkillsService>();
builder.Services.AddScoped<IGenericService<Requests>,RequestsService>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", ":)"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();



