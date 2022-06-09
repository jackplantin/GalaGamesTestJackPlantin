using NUnit.Framework;

namespace GalaGamesTestJackPlantin
{
    [TestFixture]
    public class GalaGamesTests : WebDriverSetup
    {

        [SetUp]
        public void TestInitialize()
        {
            Initialize("https://app.gala.games/games");
            GamesPage.AcceptAllCookies();
        }

        [TearDown]
        public void TestEnd()
        {
            TearDown();
        }

        //From the Games page I should not be able to launch Town Star without being logged in
        [Test]
        public void TownStarShouldNotLaunchIfImNotLoggedIn()
        {
            GamesPage.ClickTownStarPlayButton();
            Assert.IsTrue(GamesPage.IsCreateAccountModalVisible());
        }

        //From the Store page Search for an item of your choice
        [Test]
        public void SearchForItemInStore()
        {
            Driver.Navigate().GoToUrl("https://app.gala.games/store");
            StorePage.SearchForItem("Gala Film Pass");
            Assert.IsTrue(StorePage.DoesItemMatchWhatImSearching("Gala Film Pass"));
        }

        //From the Store page I should be able to filter Town Star items by Epic Rarity
        [Test]
        public void FilterTownStarByEpicRarity()
        {
            Driver.Navigate().GoToUrl("https://app.gala.games/store");
            StorePage.FilterByGame("Town Star");
            StorePage.SelectFilterCheckboxOptionByText("Epic");
            Assert.IsTrue(StorePage.AreFiltersApplied("Town Star"));
        }

        //From the Store page I should be able to filter Spider Tank items by Rare Rarity
        [Test]
        public void FilterSpiderTankByRareRarity()
        {
            Driver.Navigate().GoToUrl("https://app.gala.games/store");
            StorePage.FilterByGame("Spider Tanks");
            StorePage.SelectFilterCheckboxOptionByText("Rare");
            Assert.IsTrue(StorePage.AreFiltersApplied("Spider Tanks"));
        }




    }
}