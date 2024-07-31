namespace TodoList.Api.Dtos;

public record class TodoDto(
    int Id, 
    string TodoName, 
    string Description,
    DateOnly TodoDate
    );
