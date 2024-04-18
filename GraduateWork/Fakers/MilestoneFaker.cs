using Bogus;
using GraduateWork.Models;

namespace GraduateWork.Fakers;

public class MilestoneFaker : Faker<Milestone>
{
    public MilestoneFaker()
    {
        RuleFor(c => c.Name, d => d.Random.AlphaNumeric(10));
        RuleFor(c => c.Description, d => d.Random.AlphaNumeric(5));
    }
}