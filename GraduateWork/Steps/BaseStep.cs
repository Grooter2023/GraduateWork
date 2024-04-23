using GraduateWork.Pages;
using GraduateWork.Pages.ProjectPages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;

    protected LoginPage? LoginPage { get; set; }
    protected DashboardPage? DashboardPage { get; set; }
    protected AddProjectPage? AddProjectPage { get; set; }
    protected AddMilestonesPage? AddMilestonesPage { get; set; }
    protected MilestonesPage? MilestonesPage { get; set; }
}