using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Pages.ProjectPages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class NavigationSteps : BaseStep
{
    public NavigationSteps(IWebDriver driver) : base(driver) { }

    [AllureStep("Login Page navigation")]
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }

    [AllureStep("Dashboard Page navigation")]
    public DashboardPage NavigateToDashboardPage()
    {
        return new DashboardPage(Driver);
    }

    [AllureStep("Add Project Page navigation")]
    public AddProjectPage NavigateToAddProjectPage()
    {
        return new AddProjectPage(Driver);
    }

    [AllureStep("Milestones Page navigation")]
    public MilestonesPage NavigateToMilestonesPage()
    {
        return new MilestonesPage(Driver,true);
    }

    [AllureStep("Milestones Page navigation")]
    public DashboardPage SuccessfulLogin(User user)
    {
        return Login<DashboardPage>(user);
    }

    [AllureStep("Input login and password")]
    public LoginPage IncorrectLogin(User user)
    {
        return Login<LoginPage>(user);

    }
    [AllureStep("Input incorrect password")]
    public LoginPage IncorrectPassword(User user)
    {
        return Login<LoginPage>(user);
    }

    public T Login<T>(User user) where T : BasePage
    {
        LoginPage = new LoginPage(Driver);

        LoginPage.EmailInput.SendKeys(user.Username);
        LoginPage.PswInput.SendKeys(user.Password);
        LoginPage.LoginInButton.Click();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}