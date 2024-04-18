using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public record Group
{
    public string Password { get; init; } = string.Empty;
}