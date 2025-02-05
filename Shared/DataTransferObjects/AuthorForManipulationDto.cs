namespace Shared.DataTransferObjects;

public class AuthorForManipulationDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? BirthDate { get; set; }

    //Photo
    public IFormFile? Photo { get; set; }
}