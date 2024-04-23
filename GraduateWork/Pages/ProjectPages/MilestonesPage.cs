using AngleSharp.Dom;
using GraduateWork.Elements;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace GraduateWork.Pages.ProjectPages;

public class MilestonesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "index.php?/milestones/overview/154";

    private static readonly By TitleBy = By.XPath("//*[contains(@class, 'page_title') and contains(text(), 'Milestones')]");
    private static readonly By SuccessMessageADDMilestoneBy = By.ClassName("message-success");
    private static readonly By DeleteMilestoneButtonBy = By.ClassName("icon-small-delete");
    private static readonly By DeleteOkButtonBy = By.CssSelector("[data-testid='caseFieldsTabDeleteDialogButtonOk']");
    private static readonly By SuccessMessageDeletedMilestoneBy = By.ClassName("message-success");
    private static readonly By DeleteSelectAllCheckboxBy = By.Name("select_all");
    private static readonly By DeleteSelectedButtonBy = By.CssSelector("[data-testid='buttonDelete']");
    private static readonly By DeleteAllButtonBy = By.CssSelector("[data-testid='deleteCaseDialogActionDefault']");
    private static readonly By DeleteAllCheckboxBy = By.Id("confirm-check");
    private static readonly By DeleteCanceAllButtonBy = By.CssSelector("[data-testid='deleteCaseDialogActionClose']");
    private static readonly By EmptyTitleBy = By.ClassName("empty-title");
    private static readonly By SearchAllElementsBy = By.XPath("//*[@class='summary-title text-ppp']//a");
    private static readonly By DeleteDialogBy = By.Id("ui-dialog-title-deleteDialog");
    private static readonly By DeleteElementBlockerBy = By.ClassName("ui-widget-overlay");

    protected override bool EvaluateLoadedStatus()
    {
        return Title.Displayed;
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
    public IWebElement EmptyTitle => WaitsHelper.WaitForExists(EmptyTitleBy);
    public IWebElement SuccessMessageADDMilestone => WaitsHelper.WaitForExists(SuccessMessageADDMilestoneBy);
    public Button DeleteMilestoneButton => new Button(Driver, DeleteMilestoneButtonBy);
    public Button DeleteOkButton => new Button(Driver, DeleteOkButtonBy);
    public IWebElement SuccessMessageDeletedMilestone => WaitsHelper.WaitForExists(SuccessMessageDeletedMilestoneBy);
    public Checkbox DeleteSelectAllCheckbox => new Checkbox(Driver, DeleteSelectAllCheckboxBy);
    public Button DeleteSelectedButton => new Button(Driver, DeleteSelectedButtonBy);
    public Button DeleteAllButton => new Button(Driver, DeleteAllButtonBy);
    public Checkbox DeleteAllCheckbox => new Checkbox(Driver, DeleteAllCheckboxBy);
    public Button DeleteCanceAllButton => new Button(Driver, DeleteCanceAllButtonBy);
    public IWebElement DeleteDialog => WaitsHelper.WaitForExists(DeleteDialogBy);
    public IWebElement DeleteElementBlocker => WaitsHelper.WaitForExists(DeleteElementBlockerBy);
    public ReadOnlyCollection<IWebElement> SearchAllElements => WaitsHelper.WaitForAllVisibleElementsLocatedBy(SearchAllElementsBy);
}