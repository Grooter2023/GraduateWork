using GraduateWork.Models;

namespace GraduateWork.Tests.GUI;

public class ProjectTest : BaseTest
{
    [Test]
    [Category("Regression")]
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