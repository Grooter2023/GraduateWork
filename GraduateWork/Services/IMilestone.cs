using GraduateWork.Models;
using System.Net;

namespace GraduateWork.Services;

public interface IMilestone
{
    Task<Milestone> GetMilestone(string milestoneId);
    Task<Milestones> GetMilestones(string projectId);
    Task<Milestone> AddMilestone(string projectId, Milestone milestone);
    Task<Milestone> UpdateMilestone(Milestone milestone);
    HttpStatusCode DeleteMilestone(string milestoneId);
}