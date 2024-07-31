using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Dtos;

public record class UpdateTodoDto(
    [Required][StringLength(45)] string TodoName,
    [Required][StringLength(90)] string Description,
    DateOnly TodoDate
);