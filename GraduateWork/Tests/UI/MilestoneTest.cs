using Allure.Net.Commons;
using GraduateWork.Models;
using NUnit.Allure.Attributes;

namespace GraduateWork.Tests.UI;

[AllureSuite("UI tests on Milestone")]
public class MilestoneTest : BaseTest
{
    [Test]
    [Order(1)]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_02")]
    [AllureDescription("Creation of Milestone")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void SuccessfulMilestoneTest()
    {
        _navigationSteps.SuccessfulLogin(StandardUser);

        Milestone expectedMilestone = new Milestone()
        {
            Name = "Milestone",
        };
            Assert.That(_milestoneSteps.AddMilestone(expectedMilestone).SuccessMessageADDMilestone.Text,
            Is.EqualTo("Successfully added the new milestone."));
    }

    [Test]
    [Order(2)]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_02")]
    [AllureDescription("Uploading a file to a milestone")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void FileUploadTest()
    {
        _navigationSteps.SuccessfulLogin(StandardUser);
        Assert.That(_milestoneSteps.FileUpload("picture.jpg"));
    }

    [Test]
    [Order(3)]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_02")]
    [AllureDescription("Checking the input field for boundary values")]
    [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.minor)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void LimitValuesTest()
    {
        _navigationSteps.SuccessfulLogin(StandardUser);

        Milestone addMilestone = new Milestone()
        {
            Name = "1",
        };

        var lastMilestoneName = _milestoneSteps.AddMilestone(addMilestone).SearchAllElements.Last().Text;

        Assert.That(lastMilestoneName,
            Is.EqualTo("1"));
    }

    [Test]
    [Order(4)]
    [AllureFeature("Negative UI Tests")]
    [AllureStory("Story_02")]
    [AllureDescription("Checking for data input exceeding acceptable values")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    public void EnteringDataThatExceedsAcceptablLimitsTest()
    {
        _navigationSteps.SuccessfulLogin(StandardUser);

        Milestone newMilestone = new Milestone()
        {
            Name = "01TestForEnteringDataExceedingThePermissibleLimits02TestForEnteringDataExceedingThePermissibleLimits03TestForEnteringDataExceedingThePermissibleLimits04TestForEnteringDataExceedingThePermissibleLimits05TestForEnteringDataExceedingThePermissibleLimits00",
        };

        var lastMilestoneName = _milestoneSteps.AddMilestone(newMilestone).SearchAllElements.Last().Text;
      
        Assert.That(lastMilestoneName,
            Is.EqualTo(newMilestone.Name.Substring(0, 250)));
    }

    [Test]
    [Order(5)]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_02")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [AllureDescription("Displaying a dialog box when trying to uninstall milestone")]
    public void DisplayDialogTest()
    {
        _navigationSteps.SuccessfulLogin(StandardUser);

        var milstonePage = _milestoneSteps.ConfirmationDeleteMilestone();


        Assert.Multiple(() =>
        {
            Assert.That(milstonePage.DeleteDialog.Text,
                Is.EqualTo("Confirmation"));

            Assert.That(milstonePage.DeleteElementBlocker != null);
        });
    }

    [Test]
    [Order(6)]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_02")]
    [AllureDescription("Removing all Milestones")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    public void RemovalAllMilestonesTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Assert.That(_milestoneSteps.DeleteMilestone().EmptyTitle.Text,
            Is.EqualTo("This project doesn't have any milestones, yet."));
    }
}