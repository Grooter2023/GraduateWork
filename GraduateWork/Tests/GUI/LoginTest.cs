using GraduateWork.Models;

namespace GraduateWork.Tests.GUI;

public class LoginTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
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
    [Category("Regression")]
    public void InvalidUsernameLoginTest()
    {
        // Проверка
        Assert.That(
            _navigationSteps
                .IncorrectLogin(new User
                {
                    Username = "wrongUsername",
                    Password = Admin.Password
                })
                .GetErrorLabelText(),
            Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }

}