using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GalaGamesTestJackPlantin
{
    public class WebDriverSetup
    {
        public static OpenQA.Selenium.WebDriver Driver;
        public static WebDriverWait wait;

        public static void Initialize(string url)
        {
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    Driver.Navigate().GoToUrl(url);
                    wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
        }

        public static void TearDown()
        {
            Driver.Quit();
        }




    }
}
