using Microsoft.AspNetCore.Http;

namespace Shared.DataTransferObjects;

public abstract class AuthorForManipulationDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}