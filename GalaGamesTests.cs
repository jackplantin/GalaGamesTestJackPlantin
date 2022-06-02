﻿using NUnit.Framework;

namespace GalaGamesTestJackPlantin
{
    [TestFixture]
    public class GalaGamesTests : WebDriverSetup
    {

        [SetUp]
        public void TestInitialize()
        {
            Initialize("https://app.gala.games/games"); 
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
            
            Thread.Sleep(5000);

        }

        //From the Store page Search for an item of your choice
        [Test]
        public void Test2()
        {

        }

        //From the Store page I should be able to filter Town Star items by Epic Rarity
        [Test]
        public void Test3()
        {

        }

        //From the Store page I should be able to filter Spider Tank items by Rare Rarity
        [Test]
        public void Test4()
        {

        }




    }
}