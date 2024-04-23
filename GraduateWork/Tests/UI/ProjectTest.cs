using Allure.Net.Commons;
using GraduateWork.Models;
using NUnit.Allure.Attributes;

namespace GraduateWork.Tests.UI;

[AllureSuite("UI tests on Project")]
public class ProjectTest : BaseTest
{
    [Test]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_03")]
    [AllureDescription("Ñhecking project creation")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void SuccessfulAddProjectTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Project expectedProject = new Project()
        {
            Name = "WP Test 01",
            Announcement = "Test Details",
            ShowAnnouncement = false,
            SuiteMode = 1
        };

        Assert.That(_projectSteps.AddProject(expectedProject).SuccessMessage.Text.Trim(),
            Is.EqualTo("Successfully added the new project."));
    }
}