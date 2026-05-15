using NUnit.Framework;
using OTS2026_GrupaE.Exceptions;
using OTS2026_GrupaE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace OTS2026_GrupaE.Test
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game(new Position(1, 2, 0));
        }
        //   Klase ekvivalencije validne
        // x: [0-9],  [20,29]
        // y: [0,9], 
        // z: [0,9], 
        // Klase ekvivalencije nevalidne
        //x:  [10,19] 
        // y: [10,29]
        // z: [10,29]

        [TestCase(5,5,5)] // validne vrednosti
        [TestCase(15,5,5)] // validne vrednosti
        [TestCase(25,5,5)] // validne vrednosti
        [TestCase(-1,-1,-1)]// nevalidna
        [TestCase(10,10,10)]//nevalidna

        public void Game_PlayerOutsideFarm_ThrowsException(int x,int y, int z)
        {
            Exception ex= Assert.Throws<InvalidPlayerPositionException>((TestDelegate)(() => new Game(new Position(x,y,z))));
            Assert.That(ex.Message, Is.EqualTo("Player must be in the Farm zone!"));
        }
        // Validne klase 
        // x: [0-9],  [20,29]
        // z: [0,9], 
        // Klase ekvivalencije nevalidne
        //x:  [10,19]
        // z: [10,29]
        [TestCase(5,5)]
        [TestCase(20,29)]
        [TestCase(11,11)] // nevalidna

        public void Game_MoveUp_PlayerOnTopBoundery(int x, int z)
        {
            game.Player.Position = new Position(x, 0, z);
            game.Player.MoveUp();
            Assert.That(0,Is.EqualTo(game.Player.Position.Y));
        }
        // x:[10, 19]
        // z:[10, 19]
        [TestCase(9,9)]
        [TestCase(10,10)]
        [TestCase(11, 11)]
        [TestCase(18,18)]
        [TestCase(19, 19)]
        [TestCase(20, 20)]
        public void Game_PlayerMoveUp_InvalidField(int x, int z)
        {
            game.Player.Position=new Position(x, 10, z);
            game.Player.MoveUp();
            Assert.That(10,Is.EqualTo(game.Player.Position.Y));
        }

        [TestCaseSource(typeof(TestDataCase), "MoveUp_SuccessfulMove_PlayerPositionChanged_TestData")]
        public void MoveUp_SuccesfulMove_PositionChanged(int x, int y ,int z, int expectedY)
        {
            game.Player.Position=new Position(x,y, z);
            game.Player.MoveUp();
            Assert.That(y, Is.EqualTo(expectedY));
        }

        [TestCaseSource(typeof(TestDataFromFile), "Get_ValidatePosition_OKInput_SuccesfulValidation_Test", new object[] { "validateposition_results.txt" })]
        public void Get_ValidatePosition_OKInput_SuccesfulValidation_Test(int x, int y, int z, bool expectedResult)
        {
            Position position = new Position(x, y, z);

            
            bool actualResult = game.ValidatePosition(position);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        [TestCaseSource(typeof(TestDataFromFile), "Get_ValidatePosition_OKInput_SuccesfulValidation_Test", new object[] { " calculateIncome_results.txt"})]
        public void Get_ValidatePosition_OKInput_SuccesfulValidation_Test(int plantCrop, int seed,bool item, Income? expectedResult)
        {
            plantCrop = game.Player.AmountOfPlants;
            seed = game.Player.AmountOfSeed;
            item = game.Player.VisitedCrop;
            Income? actualincome = game.CalculateIncome;
            Assert.That(actualincome, Is.EqualTo(expectedResult));


        }
    }
}
