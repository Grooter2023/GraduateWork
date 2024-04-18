using GraduateWork.Models;
using GraduateWork.Pages;
using GraduateWork.Pages.ProjectPages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class NavigationSteps : BaseStep
{
    public NavigationSteps(IWebDriver driver) : base(driver) { }

    [AllureStep]
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }

    [AllureStep]
    public DashboardPage NavigateToDashboardPage()
    {
        return new DashboardPage(Driver);
    }

    [AllureStep]
    public AddProjectPage NavigateToAddProjectPage()
    {
        return new AddProjectPage(Driver);
    }

    [AllureStep]
    public DashboardPage SuccessfulLogin(User user)
    {
        return Login<DashboardPage>(user);
    }

    [AllureStep]
    public LoginPage IncorrectLogin(User user)
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