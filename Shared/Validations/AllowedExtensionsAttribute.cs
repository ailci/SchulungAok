using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shared.Validations;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private IEnumerable<string> AllowedExtensions { get; init; }

    public AllowedExtensionsAttribute(string valideTypen)
    {
        AllowedExtensions = valideTypen.Split(',').Select(c => c.Trim().ToLowerInvariant());
        ErrorMessage = $"Nur folgende Datei-Typen sind erlaubt: {string.Join(",", AllowedExtensions)}";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IFormFile formFile && !AllowedExtensions.Any(c => formFile.FileName.EndsWith(c)))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}