using System.Text.Json.Serialization;

namespace GraduateWork.Models;

public record Milestone
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
    [JsonPropertyName("completed_on")] public long? CompletedOn { get; set; }
    [JsonPropertyName("due_on")] public long DueOn { get; set; }
    [JsonPropertyName("project_id")] public int ProjectID { get; set; }
    [JsonPropertyName("refs")] public string? Refs { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("error")] public string? Error { get; set; }
}