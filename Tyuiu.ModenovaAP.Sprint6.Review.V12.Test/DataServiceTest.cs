using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.ModenovaAP.Sprint6.Review.V12.Lib;

namespace Tyuiu.ModenovaAP.Sprint6.Review.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataService ds = new DataService();

            int[,] array = new int[5, 5] { { 9, -4, 17, -1, -20},
                                     { 19, 18, -4, 2, 14},
                                     { 12, 16, -2, 7, 18},
                                     { 16, 15, 4, -12, -13},
                                     { 15, 4, -16, 1, -14,}};

            int res = ds.GetMatrix(array, 0, 1, 3);
            Assert.AreEqual(1, res);
        }
    }
}
