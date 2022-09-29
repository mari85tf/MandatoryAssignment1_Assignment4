using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment4.Manager.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        private FootballPlayersManager manager = new FootballPlayersManager();
        [TestMethod()]
        public void GetAllTest()
        {
            List<FootballPlayer> players = manager.GetAll();
            var result = 4;
            Assert.AreEqual(result, players.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            FootballPlayer players = manager.GetById(1);
            var result = 1;
            Assert.AreEqual(result, players.Id);
        }

        [TestMethod()]
        public void AddTest()
        {
            FootballPlayer player = new FootballPlayer() { Name = "Sara Hilton", Age = 24, ShirtNumber = 25 };
            var result = manager.Add(player);
            var expected = 5;
            Assert.AreEqual(expected,result.Id);
            manager.Delete(player.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            manager.Delete(3);
            var result = manager.GetAll();
            var expected = 3;
            Assert.AreEqual(expected,result.Count);
            FootballPlayer player = new FootballPlayer() { Name = "Sara Hilton", Age = 24, ShirtNumber = 25 };
            manager.Add(player);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            FootballPlayer player1 = new FootballPlayer() { Name = "Sara Hilton", Age = 24, ShirtNumber = 25 };
            FootballPlayer player = manager.Update(1, player1);
            player.Name = "Sarah Hilton";
            player.Age = 25;
            Assert.AreEqual(player.Name,"Sarah Hilton");
            Assert.AreEqual(player.Age,25);
        }
    }
}