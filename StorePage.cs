using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaGamesTestJackPlantin
{
    public class StorePage : WebDriverSetup
    {

        public static By SEARCH_INPUT_FIELD = By.XPath("//input[@data-testid = 'search-bar-input']");
        public static By ALL_ITEM_RESULTS = By.XPath("//div[@data-testid = 'store-item']");
        public static By RARITY_CHECKBOXES = By.XPath("//div[@class = 'd-flex align-center option-filter py-2']/p");
        


        public static void SearchForItem(string itemName)
        {
            var inputField = wait.Until(d => d.FindElement(SEARCH_INPUT_FIELD));
            inputField.SendKeys(itemName);
            Thread.Sleep(5000); //in real framework i would use selenium wait helper
        }

        public static bool? DoesItemMatchWhatImSearching(string itemName)
        {
            bool? itemFound = false;
            IList<IWebElement> allItemsFound = wait.Until(d => d.FindElements(ALL_ITEM_RESULTS));

            

            foreach (var item in allItemsFound)
            {
                if (item.Text.Contains(itemName))
                {
                    itemFound = true;
                }
            }

            return itemFound;

        }

        public static void FilterByGame(string gameName)
        {
            var sideMenuAppFilter = wait.Until(d => Driver.FindElement(By.XPath("//img[@alt = '" + gameName + "']")));
            sideMenuAppFilter.Click();
        }

        public static void FilterByRarity(string appName, string rarityType)
        {
            


        }



    }
}
