using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shared.Validations;

namespace Shared.DataTransferObjects;

public abstract class AuthorForManipulationDto
{
    [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
    [MaxLength(100, ErrorMessage = "Der Name darf nicht 100 Zeichen überschreiten")]
    [DeniedValues(["administrator","admin","root","god"], ErrorMessage = "Der Name ist nicht erlaubt")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein")]
    public string? Description { get; set; }

    [NoFutureDate(ErrorMessage = "Geburtsdatum ist ungültig")]
    public DateOnly? BirthDate { get; set; }

    //TODO: Datei-Endungen jpg,jpeg,png,bmp,gif zulässig
    public IFormFile? Photo { get; set; }
}