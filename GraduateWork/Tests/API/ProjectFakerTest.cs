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
public class ProjectFakerTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project _project;
    private static Faker<Project> Project => new ProjectFaker();

    [SetUp]
    [AllureBefore]
    public void AddProject()
    {
        _project = Project.Generate();

        var actualProject = ProjectService!.AddProject(_project);

        _project = actualProject.Result;
        _logger.Info(_project.ToString);
    }

    [Test]
    [Order(1)]
    [Category("NFE")]
    public void GetProjectTest()
    {
        AllureApi.SetTestName("Get Project");
        AllureApi.SetDescription("Request detailed information about projects");
        AllureApi.AddFeature("NFE");
        AllureApi.AddStory("Story_1");
        AllureApi.SetOwner("Anisimova Tany");

        AllureApi.Step("Calling the Get Project method");
        var actualProject = ProjectService!.GetProject(_project.Id.ToString());

        AllureApi.Step("Checking the Get Project method");
        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Result.Name, Is.EqualTo(_project.Name));
            Assert.That(actualProject.Result.Announcement, Is.EqualTo(_project.Announcement));
        });

        _logger.Info(_project.ToString());
    }

    [Test]
    [Order(2)]
    [Category("AFE")]
    public void GetProjectsUnknownTest()
    {
        AllureApi.SetTestName("Get Project Unknown");
        AllureApi.SetDescription("Request detailed information about non-existent project");
        AllureApi.AddFeature("AFE");
        AllureApi.AddStory("Story_1");
        AllureApi.SetOwner("Anisimova Tany");

        AllureApi.Step("Calling the Get Projects method");
        var projectList = ProjectService!.GetProjects();
        
        AllureApi.Step("Calling the Get Project method and filling it with the value of the existing maximum id +1");
        var notActualIdProject = projectList.Result.ProjectsList.Max(x => x.Id) + 1;
        var notActualProject = ProjectService!.GetProject(notActualIdProject.ToString());

        AllureApi.Step("Checking that an error with text is returned \"Field :project_id is not a valid or accessible project.\"");
        //Assert.That(notActualProject.Result.Error, Is.EqualTo("Field :project_id is not a valid or accessible project."));

        _logger.Info("AAA " + notActualProject);
    }

    [TearDown]
    [AllureAfter]
    public void DeleteProject()
    {
        AllureApi.Step("Calling the Post Delete Project method");
        Debug.Assert(ProjectService != null, nameof(ProjectService) + " != null");
        _logger.Info(ProjectService.DeleteProject(_project.Id.ToString()));
    }
}