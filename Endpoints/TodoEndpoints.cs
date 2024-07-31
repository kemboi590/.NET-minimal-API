using TodoList.Api.Dtos;

namespace TodoList.Api.Endpoints;

public static class TodoEndpoints
{
    const string GetTodoName = "GetTodo";

    private static readonly List<TodoDto> todos = [
        new TodoDto(1, "learn C#", "learn the fundamentals", new DateOnly(2024, 7, 1)),
    new TodoDto(2, "Submit assignment", "Submit the assignment on time", new DateOnly(2024, 7, 2)),
    new TodoDto(3, "Write a Report", "Write a report on the project", new DateOnly(2024, 7, 3)),
    new TodoDto(4, "Prepare for the exam", "Prepare for the exam", new DateOnly(2024, 7, 4)),
];

    public static RouteGroupBuilder MapTodosEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("todos").WithParameterValidation();

        // GET /todos
        group.MapGet("/", () => todos);

        // GET /todos/1
        group.MapGet("/{id}", (int id) =>
        {
            TodoDto? todo = todos.Find(todo => todo.Id == id);
            return todo is null ? Results.NotFound() : Results.Ok(todo);
        })
        .WithName(GetTodoName);

        // POST /todos
        group.MapPost("/", (CreateTodoDto newTodo) =>
        {
            TodoDto todo = new TodoDto(
                todos.Count + 1,
                newTodo.TodoName,
                newTodo.Description,
                newTodo.TodoDate
            );
            todos.Add(todo);
            return Results.CreatedAtRoute(GetTodoName, new { id = todo.Id }, todo);
        });


        // PUT /todos/1
        group.MapPut("/{id}", (int id, UpdateTodoDto updatedTodo) =>
        {
            var index = todos.FindIndex(todo => todo.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            todos[index] = new TodoDto(
               id,
               updatedTodo.TodoName,
               updatedTodo.Description,
               updatedTodo.TodoDate
            );
            return Results.NoContent();
        });


        // DELETE /todos/1
        group.MapDelete("/{id}", (int id) =>
        {
            todos.RemoveAll(todo => todo.Id == id);
            return Results.NoContent();
        });
        return group;
    }
}
