using System.Net;
using GraduateWork.Clients;
using GraduateWork.Models;
using RestSharp;

namespace GraduateWork.Services;
public class MilestoneService : IMilestone, IDisposable
{
    private readonly RestClientExtended _client;

    public MilestoneService(RestClientExtended client)
    {
        _client = client;
    }
    
    public Task<Milestone> GetMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestone/{milestone_id}")
            .AddUrlSegment("milestone_id", milestoneId);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestones> GetMilestones(string projectId)
    {
        var request = new RestRequest("index.php?/api/v2/get_milestones/{project_id}")
            .AddUrlSegment("project_id", projectId);

        var milestones = _client.ExecuteAsync<Milestones>(request);
        return milestones;
    }

    public Task<Milestone> AddMilestone(string projectId, Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/add_milestone/{project_id}", Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public Task<Milestone> UpdateMilestone(Milestone milestone)
    {
        var request = new RestRequest("index.php?/api/v2/update_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestone.Id)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Milestone>(request);
    }

    public HttpStatusCode DeleteMilestone(string milestoneId)
    {
        var request = new RestRequest("index.php?/api/v2/delete_milestone/{milestone_id}", Method.Post)
            .AddUrlSegment("milestone_id", milestoneId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}