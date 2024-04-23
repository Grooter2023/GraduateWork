using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Interactions;

namespace GraduateWork.Tests.UI;

[AllureSuite("UI tests on Dashboard page")]
public class DashboardTest : BaseTest
{
    [Test]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_03")]
    [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.trivial)]
    [AllureDescription("Tooltip testing")]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void TooltipMessageTest()
    {
        var tooltip = _navigationSteps.SuccessfulLogin(StandardUser).Tooltip;

        new Actions(Driver)
            .MoveToElement(tooltip)
            .Perform();

        var tooltipText = tooltip.GetAttribute("tooltip-text");

        Assert.That(tooltipText, Is.EqualTo("Displays the active projects with many details."));
    }
}