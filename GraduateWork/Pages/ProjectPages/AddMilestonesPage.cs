using GraduateWork.Elements;
using OpenQA.Selenium;

namespace GraduateWork.Pages.ProjectPages;

public class AddMilestonesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "index.php?/milestones/add/154";

    private static readonly By TitleLabelBy = By.ClassName("page_title");
    private static readonly By InputMilestoneNameBy = By.Id("name");
    private static readonly By AddMilestoneButtonBy = By.CssSelector("#accept");
    private static readonly By AddAttachmentMilestoneBy = By.ClassName("dz-hidden-input");
    private static readonly By AttachmentMilestoneBy = By.XPath(".//div[contains(@data-testid,'attachmentListItem')]");

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    protected override bool EvaluateLoadedStatus()
    {
        return TitleLabel.Displayed && AddMilestoneButton.Displayed;
    }

    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement InputMilestoneName => WaitsHelper.WaitForExists(InputMilestoneNameBy);
    public Button AddMilestoneButton => new Button(Driver, AddMilestoneButtonBy);
    public IWebElement AddAttachmentMilestone => WaitsHelper.WaitForExists(AddAttachmentMilestoneBy);
    public IWebElement AttachmentMilestone => WaitsHelper.WaitForExists(AttachmentMilestoneBy);
}