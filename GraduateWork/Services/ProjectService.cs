using System.Net;
using GraduateWork.Clients;
using GraduateWork.Models;
using RestSharp;

namespace GraduateWork.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> GetProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> GetProjectal(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_projectghjh/{project_id}")
            .AddUrlSegment("project_id", projectId);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Projects> GetProjects()
    {
        var request = new RestRequest("index.php?/api/v2/get_projects");

        var projects = _client.ExecuteAsync<Projects>(request);
        return projects;
    }

    public Task<Project> AddProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Project> UpdateProject(Project project)
    {
        var request = new RestRequest("index.php?/api/v2/update_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", project.Id)
            .AddJsonBody(project);

        return _client.ExecuteAsync<Project>(request);
    }

    public HttpStatusCode DeleteProject(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_project/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}