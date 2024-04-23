using Allure.Net.Commons;
using System.Text;
using GraduateWork.Helpers.Configuration;
using GraduateWork.Models;
using GraduateWork.Steps;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using GraduateWork.Core;

namespace GraduateWork.Tests.UI;

[Parallelizable(scope: ParallelScope.Fixtures)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }

    protected NavigationSteps _navigationSteps;
    protected ProjectSteps _projectSteps;
    protected MilestoneSteps _milestoneSteps;
    protected DashboardSteps _dashboardSteps;

    protected User? Admin { get; private set; }
    protected User? StandardUser { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
        _projectSteps = new ProjectSteps(Driver);
        _milestoneSteps = new MilestoneSteps(Driver);
        _dashboardSteps = new DashboardSteps(Driver);

        Admin = Configurator.Admin;
        StandardUser = Configurator.StandardUser;

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
                AllureApi.AddAttachment("error.txt", "text/plain", Encoding.UTF8.GetBytes(TestContext.CurrentContext.Result.Message));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Driver.Quit();
    }
}