using OpenQA.Selenium;

namespace GalaGamesTestJackPlantin
{
    public class StorePage : WebDriverSetup
    {

        public static By SEARCH_INPUT_FIELD = By.XPath("//input[@data-testid = 'search-bar-input']");
        public static By ALL_ITEM_RESULTS = By.XPath("//div[@data-testid = 'store-item']");
        public static By FILTER_LABELS = By.XPath("//div[@class = 'd-flex align-center option-filter py-2']/p");
        public static By FILTER_CHECKBOXES = By.XPath("//div[@data-testid = 'item-filter-checkbox']");


        //Sends text of choice to the search bar and waits until results show up
        public static void SearchForItem(string itemName)
        {
            var inputField = wait.Until(d => d.FindElement(SEARCH_INPUT_FIELD));
            inputField.SendKeys(itemName);
            Thread.Sleep(5000); //in real framework i would use selenium wait helper
        }

        //Asserts that the one of the items in the group match what you are searching for
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

        //Clicks on the side menu game options
        public static void FilterByGame(string gameName)
        {
            var sideMenuAppFilter = wait.Until(d => d.FindElement(By.XPath("//img[@alt = '" + gameName + "']")));
            sideMenuAppFilter.Click();
        }

        //Clicks on the side filter menu options that contain a checkbox
        public static void SelectFilterCheckboxOptionByText(string checkBoxText)
        {
            
            for (int i = 1; i <= Driver.FindElements(FILTER_LABELS).Count; i++)
            {
                var currentFilterLabelText = Driver.FindElement(By.XPath("(//div[@class = 'd-flex align-center option-filter py-2']/p)[" + i + "]")).Text;

                if (currentFilterLabelText.Contains(checkBoxText))
                {
                    Driver.FindElement(By.XPath("(//div[@data-testid = 'item-filter-checkbox'])[" + i + "]")).Click();
                    break;
                }

            }

        }

        //Checks the first filter is applied correctly (can add logic to loop through each filter)
        public static bool? AreFiltersApplied(string filterType)
        {
           return wait.Until(d => d.FindElement(By.CssSelector("p.mb-0.accent--text.medium-font.font-weight-medium"))).Text.Equals(filterType);
        }



    }
}
