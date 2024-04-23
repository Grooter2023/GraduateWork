using OpenQA.Selenium;

namespace GraduateWork.Pages
{
    public class LoginPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "";

        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        private static readonly By ErrorLabelBy = By.CssSelector("[data-testid='loginErrorText']");

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return LoginInButton.Displayed && EmailInput.Displayed;
        }

        public string GetErrorLabelText() => ErrorLabel.Text.Trim();
        
        public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
        public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
        public IWebElement RememberMeCheckbox => WaitsHelper.WaitForExists(RememberMeCheckboxBy);
        public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);
        public IWebElement ErrorLabel => WaitsHelper.WaitForExists(ErrorLabelBy);

    }
}