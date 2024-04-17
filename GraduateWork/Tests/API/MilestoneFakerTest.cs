using System.Diagnostics;
using Bogus;
using GraduateWork.Models;
using NLog;
using GraduateWork.Fakers;
using Allure.Net.Commons;
using GraduateWork.Services;
using NUnit.Allure.Attributes;

namespace GraduateWork.Tests.API;
[TestFixture]

[AllureSuite("API Tests Milestone")]
public class MilestoneFakerTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project;
    private Milestone _milestone;
    private static Faker<Project> Project => new ProjectFaker();
    private static Faker<Milestone> Milestone => new MilestoneFaker();

    [SetUp]
    [AllureBefore]
    public void AddProjectAndMilestone()
    {
        _project = Project.Generate();
        _milestone = Milestone.Generate();

        AllureApi.Step("Calling the \"Post Add Project\" method");
        var actualProject = ProjectService!.AddProject(_project);
        _project = actualProject.Result;
        _logger.Info(_project.ToString);

        AllureApi.Step("Calling the \"Post Add Milestone\" method");
        var actualMilestone = MilestoneService!.AddMilestone(_project.Id.ToString(), _milestone);
        _milestone = actualMilestone.Result;

        _logger.Info(_milestone.ToString());
    }
    
    [Test]
    [Order(1)]
    [Category("NFE")]
    public void GetMilestoneTest()
    {
        AllureApi.SetTestName("Get Milestone");
        AllureApi.SetDescription("Request detailed information about milestone");
        AllureApi.AddFeature("NFE");
        AllureApi.AddStory("Story_3");
        AllureApi.SetOwner("Anisimova Tany");

        AllureApi.Step("Calling the \"Get Milestone\" method");
        var actualMilestone = MilestoneService!.GetMilestone(_milestone.Id.ToString());

        AllureApi.Step("Checking the correct name and description in the response");
        Assert.Multiple(() =>
        {
            Assert.That(actualMilestone.Result.Name, Is.EqualTo(_milestone.Name));
            Assert.That(actualMilestone.Result.Description, Is.EqualTo(_milestone.Description));
        });

        _logger.Info(_milestone.ToString());
    }
/*
    [Test]
    [Order(2)]
    [Category("NFE")]
    public void GetMilestonesTest()
    {
        AllureApi.SetTestName("Get Milestones");
        AllureApi.SetDescription("Request detailed information about the milestones");
        AllureApi.AddFeature("NFE");
        AllureApi.AddStory("Story_3");
        AllureApi.SetOwner("Anisimova Tany");

        AllureApi.Step("Calling the \"Get Milestones\" method");
        var milestoneList = MilestoneService!.GetMilestones(_project.Id.ToString());

        AllureApi.Step("Verifying that the response returned the correct number of milestones for a specific project");
        Assert.That(milestoneList.Result.MilestoneList.Count, Is.EqualTo(1));

        _logger.Info(milestoneList.ToString());
    }

    [Test]
    [Order(3)]
    [Category("AFE")]
    public void GetMilestonesUnknownTest()
    {
        AllureApi.SetTestName("Get Milestone Unknown");
        AllureApi.SetDescription("Request detailed information about non-existent milestone");
        AllureApi.AddFeature("AFE");
        AllureApi.AddStory("Story_3");
        AllureApi.SetOwner("Anisimova Tany");

        AllureApi.Step("Calling the Get Milestones method");
        var milestoneList = MilestoneService!.GetMilestones(_project.Id.ToString());

        AllureApi.Step("Calling the Get Milestone method and filling it with the value of the existing maximum id +1");
        var notActualIdMilestone = milestoneList.Result.MilestoneList.Max(x => x.Id) + 1;
        var notActualMilestone = MilestoneService!.GetMilestone(notActualIdMilestone.ToString());

        AllureApi.Step("Checking that an error with text is returned \"Field :milestone_id is not a valid milestone.\"");
        Assert.That(notActualMilestone.Result.Error, Is.EqualTo("Field :milestone_id is not a valid milestone."));

        _logger.Info(notActualMilestone);
    }
*/
    [TearDown]
    [AllureAfter]
    public void DeleteProject()
    {
        AllureApi.Step("Calling the Post Delete Milestone method");
        Debug.Assert(MilestoneService != null, nameof(MilestoneService) + " != null");
        _logger.Info(MilestoneService.DeleteMilestone(_milestone.Id.ToString()));

        AllureApi.Step("Calling the Post Delete Project method");
        Debug.Assert(ProjectService != null, nameof(ProjectService) + " != null");
        _logger.Info(ProjectService.DeleteProject(_project.Id.ToString()));
    }
}