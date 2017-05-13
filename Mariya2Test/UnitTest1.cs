using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mariya2;
using System.Linq;

namespace Mariya2Test
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void AddCityTest()
        {
            //arrange 

            string cityName = "Воронеж";
            CityModel expected = new CityModel(cityName);

            //act

            MainViewModel c = new MainViewModel();
            c.CityList.Clear();
            c.AddCity(cityName);
            CityModel actual = c.CityList.First();

            //assert

            Assert.AreEqual(actual.CityName, expected.CityName);
        }
        [TestMethod]
        public void AddClientTest()
        {
            //arrange 
            MainViewModel c = new MainViewModel();
            int actual = 2;
            c.CityList[0].DateOfZamer[0, 0, 0].CountOfZamer = actual;

            c.DateDay = 1;
            c.DateMounth = 1;
            c.DateYear = 2000;
            c.ClientPhone = "895522152212";
            c.ClientName = "Иванов И.И.";
            c.CityName = c.CityList[0];


            //act

            c.AddClient();
            c.AddClient();

            int expected = c.CityList[0].DateOfZamer[0, 0, 0].ClientList.Count;

            //assert

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void AddOverClientTest()
        {
            //arrange 
            MainViewModel c = new MainViewModel();
            int actual = 2;
            c.CityList[0].DateOfZamer[0, 0, 0].CountOfZamer = actual;

            c.DateDay = 1;
            c.DateMounth = 1;
            c.DateYear = 2000;
            c.ClientPhone = "895522152212";
            c.ClientName = "Иванов И.И.";
            c.CityName = c.CityList[0];
            string actual2 = "На этот день нет замеров";

            //act

            c.AddClient();
            c.AddClient();
            c.AddClient();
            string expected2 = c.OshibkaNetZamershikov;
            int expected = c.CityList[0].DateOfZamer[0, 0, 0].ClientList.Count;

            //assert

            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected2);
        }
    }
}
