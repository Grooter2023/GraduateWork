using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages.ProjectPages;

public class AddProjectPage(IWebDriver? driver, bool openByURL = false) : ProjectBasePage(driver, openByURL)
{
    private const string END_POINT = "index.php?/admin/projects/add";

    private static readonly By AddButtonBy = By.Id("accept");

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    protected override bool EvaluateLoadedStatus()
    {
        return WaitsHelper.WaitForVisibilityLocatedBy(AddButtonBy).Displayed;
    }

    public Button AddButton => new Button(Driver, AddButtonBy);
}