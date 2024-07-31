namespace TodoList.Api.Dtos;

public record class UpdateTodoDto(
    string TodoName, 
    string Description,
    DateOnly TodoDate
);