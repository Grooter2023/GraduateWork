using Allure.Net.Commons;
using GraduateWork.Models;
using NUnit.Allure.Attributes;

namespace GraduateWork.Tests.UI;

[AllureSuite("UI tests on Project page")]
public class LoginTest : BaseTest
{
    [Test]
    [AllureFeature("Positive UI Tests")]
    [AllureStory("Story_01")]
    [AllureDescription("Checking successful login as administrator")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void SuccessfulLoginTest()
    {
        Assert.That(
            _navigationSteps
                .SuccessfulLogin(Admin)
                .SidebarProjectsAddButton
                .Displayed
        );
    }

    [Test]
    [AllureFeature("Negative UI Tests")]
    [AllureStory("Story_01")]
    [AllureDescription("Checking if you entered the wrong password to log in as an administrator")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void InvalidPasswordLoginTest()
    {
        Assert.That(
            _navigationSteps
                .IncorrectPassword(new User
                {
                    Username = Admin.Username,
                    Password = "wrongPassword",
                })
                .GetErrorLabelText(),
            Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }

    [Test]
    [AllureFeature("Negative UI Tests")]
    [AllureStory("Story_01")]
    [AllureDescription("Checking for entering an incorrect username to log in as a normal user")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Anisimova Tany")]
    [AllureLink("Website", "https://grooter00.testrail.io/index.php?/auth/login")]
    [AllureTms("TMS-001")]
    [Parallelizable(scope: ParallelScope.Self)]
    public void InvalidUsernameLoginTest()
    {
        Assert.That(
            _navigationSteps
                .IncorrectLogin(new User
                {
                    Username = "wro",
                    Password = StandardUser.Password,
                })
                .GetErrorLabelText(),
        Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }

}