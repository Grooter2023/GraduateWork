using GraduateWork.Services;
using NLog;
using NUnit.Allure.Core;
using GraduateWork.Clients;
using Bogus;
using GraduateWork.Fakers;
using GraduateWork.Models;

namespace GraduateWork.Tests.API;

[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected ProjectService? ProjectService;
    protected MilestoneService? MilestoneService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        ProjectService = new ProjectService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectService?.Dispose();
        MilestoneService?.Dispose();
    }
}