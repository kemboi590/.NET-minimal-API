using TodoList.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapTodosEndpoints();


app.Run();
