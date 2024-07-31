namespace TodoList.Api.Dtos;

public record class CreateTodoDto(
    string TodoName, 
    string Description,
    DateOnly TodoDate
);
