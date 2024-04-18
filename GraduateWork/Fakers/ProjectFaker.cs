using Bogus;
using GraduateWork.Models;

namespace GraduateWork.Fakers;

public class ProjectFaker : Faker<Project>
{
    public ProjectFaker()
    {
        RuleFor(a => a.Name, b => b.Random.AlphaNumeric(27));
        RuleFor(a => a.Announcement, b => b.Random.Words(55));
        RuleFor(a => a.SuiteMode, b => b.Random.Number(1, 3));
        RuleFor(a => a.ShowAnnouncement, b => b.Random.Bool());
    }
}