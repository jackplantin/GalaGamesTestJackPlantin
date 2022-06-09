using OpenQA.Selenium;

namespace GalaGamesTestJackPlantin
{
    public class GamesPage : WebDriverSetup
    {

        public static By CREATE_ACCOUNT_MODAL = By.ClassName("v-form");
        public static By LIST_OF_APPS = By.CssSelector("div.secondary.mb-6.v-card.v-sheet.theme--dark");

        //Statically clicks the town star button, can make it dynamic by town star is 1/2 games that has play button
        public static void ClickTownStarPlayButton()
        {

            foreach (var app in Driver.FindElements(LIST_OF_APPS))
            {
                if (app.Text.Contains("Town Star"))
                {
                    app.FindElement(By.XPath("//button[contains(text(), 'Play')]")).Click();
                    break;
                }
            }
           
        }

        //Check if create account modal opens, which indicates that you aren't logged in
        public static bool? IsCreateAccountModalVisible()
        {
            return wait.Until(d => d.FindElement(CREATE_ACCOUNT_MODAL).Displayed);
        }

        //Method to click the accept all cookies button before each test run. Hidden in shadow root so have to workaround
        public static void AcceptAllCookies()
        {

            Thread.Sleep(5000); //could also wait until cookie element is visible, this is a quick workaround

            IWebElement rootNode = Driver.FindElement(By.CssSelector("div#usercentrics-root"));

            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;

            ISearchContext shadowDom1 = (ISearchContext) js.ExecuteScript("return arguments[0].shadowRoot", rootNode);

            var cookiesButton = shadowDom1.FindElement(By.CssSelector("button.sc-gsDKAQ.iOBOBZ"));

            cookiesButton.Click();
        }

    }
}
