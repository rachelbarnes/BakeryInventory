using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryInventoryProject.Models;
using NUnit.Framework;
namespace BakeryInventoryProjectUnitTests {
    [TestFixture]
    public class YieldCalculationsIngredientMeasurementTests {
        [Test]
        public void UpdateMeasurementBasedOnYieldMultiplierTest() {
            var update = new YieldCalculationsIngredientMeasurement();
            var actual = update.UpdateMeasurementBasedOnMultiplier(1.0m, 1.5m);
            var expected = 1.50m;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void UpdateMeasurementBasedOnYieldMultiplierTest2() {
            var update = new YieldCalculationsIngredientMeasurement();
            var actual = update.UpdateMeasurementBasedOnMultiplier(1.33m, .66m);
            var expected = .87m;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AdjustMeasurement() {
            var update = new YieldCalculationsIngredientMeasurement();
            var actual = update.MultiplyOriginalMeasurementArray("1 1/2 cups", .5m);
            var expected = new string[] { "1", "1/2" };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AdjustMeasurement2() {
            var update = new YieldCalculationsIngredientMeasurement();
            var actual = update.MultiplyOriginalMeasurementArray("2/3 cups", .5m);
            var expected = new string[] { "2/3" }; 
        }

        //[Test]
        //public void AdjustMeasurement() {
        //    var adjust = new YieldCalculationsIngredientMeasurement();
        //    var actual = adjust.MultiplyOriginalMeasurementArray("1 1/2 cups", .75m);
        //    var expected = "3/4 cups";
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void AdjustMeasurement1() {
        //    var adjust = new YieldCalculationsIngredientMeasurement();
        //    var actual = adjust.MultiplyOriginalMeasurementArray("1 1/2 teaspoons", 2m);
        //    var expected = "3 teapsoons";
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
