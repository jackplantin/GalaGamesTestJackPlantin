

using OpenQA.Selenium.Chrome;

namespace GalaGamesTestJackPlantin
{
    public class WebDriverSetup
    {
        public static OpenQA.Selenium.WebDriver Driver;

        public static void Initialize(string url)
        {

                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    Driver.Navigate().GoToUrl(url);

        }

        public static void TearDown()
        {
            Driver.Quit();
        }




    }
}
