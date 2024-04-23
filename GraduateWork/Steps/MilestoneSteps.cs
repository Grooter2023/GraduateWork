using GraduateWork.Models;
using GraduateWork.Pages.ProjectPages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System.Reflection;

namespace GraduateWork.Steps;

public class MilestoneSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep("Input a name and click on the button")]
    public MilestonesPage AddMilestone(Milestone milestone)
    {
        AddMilestonesPage = new AddMilestonesPage(Driver, true);

        Thread.Sleep(1000);
        AddMilestonesPage.InputMilestoneName.SendKeys(milestone.Name);
        AddMilestonesPage.AddMilestoneButton.Click();

        return new MilestonesPage(Driver);
    }

    [AllureStep("Upload file")]
    public bool FileUpload(string fileName)
    {
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(assemblyPath, "Resources", fileName);

        AddMilestonesPage = new AddMilestonesPage(Driver, true);

        AddMilestonesPage.AddAttachmentMilestone.SendKeys(filePath);

        return AddMilestonesPage.AttachmentMilestone.Displayed;
    }

    [AllureStep("Deletion Milestone")]
    public MilestonesPage DeleteMilestone()
    {
        MilestonesPage = new MilestonesPage(Driver, true);
        
        MilestonesPage.DeleteSelectAllCheckbox.SetState(true);
        MilestonesPage.DeleteSelectedButton.Click();
        MilestonesPage.DeleteAllCheckbox.SetState(true);
        MilestonesPage.DeleteAllButton.Click();

        return new MilestonesPage(Driver);
    }

    [AllureStep("Сlick on the delete button")]
    public MilestonesPage ConfirmationDeleteMilestone()
    {
        MilestonesPage = new MilestonesPage(Driver, true);

        MilestonesPage.DeleteMilestoneButton.Click();

        return new MilestonesPage(Driver);
    }
}