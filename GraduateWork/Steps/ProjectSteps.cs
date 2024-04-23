using GraduateWork.Models;
using GraduateWork.Pages.ProjectPages;
using OpenQA.Selenium;

namespace GraduateWork.Steps;

public class ProjectSteps(IWebDriver driver) : BaseStep(driver)
{
    public ProjectsPage AddProject(Project project)
    {
        AddProjectPage = new AddProjectPage(Driver, true);

        AddProjectPage.NameInput.SendKeys(project.Name);
        AddProjectPage.AnnouncementTextArea.SendKeys(project.Announcement);
        AddProjectPage.TypeRadioButton.SelectByIndex(project.SuiteMode);
        if (project.ShowAnnouncement != null) AddProjectPage.ShowAnnouncementCheckBox.Click();

        AddProjectPage.AddButton.Click();

        return new ProjectsPage(Driver);
    }
}