using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class DashboardPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "index.php?/dashboard";

        private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
        private static readonly By TooltipBy = By.XPath(".//a[contains(@tooltip-header,'Detail View')]");

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                return SidebarProjectsAddButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement SidebarProjectsAddButton => WaitsHelper.WaitForExists(SidebarProjectsAddButtonBy);
        public IWebElement Tooltip => WaitsHelper.WaitForExists(TooltipBy);
    }
}