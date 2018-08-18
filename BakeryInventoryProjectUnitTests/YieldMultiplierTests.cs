using System;
using BakeryInventoryProject.Models; 
using NUnit.Framework;

namespace BakeryInventoryProjectUnitTests {
    [TestFixture]
    public class YieldMultiplierTests{
        [Test]
        public void RoundHigherTest() {
            var yieldTest = new BakeryInventoryProject.Models.YieldCalculations();
            var actual = yieldTest.RoundToInteger(2.33m);
            var expected = 2;
            Assert.AreEqual(expected,actual); 
        }
        [Test]
        public void RoundLowerTest() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.RoundToInteger(5.56m);
            var expected = 6;
            Assert.AreEqual(expected,actual); 
        }
        [Test]
        public void MultiplyYieldHigher() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.MultilpyYieldBasedOnMultiplier(16, 3.33m);
            var expected = 53;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void MultilpyYieldLower() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.MultilpyYieldBasedOnMultiplier(32, .66m);
            var expected = 21;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void RoundToNthPlace() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.RoundToNthPlace(System.Convert.ToDecimal(85.23923269), 2);
            var expected = 85.23m;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void MultiplyToProperFractionLower() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.MultilpyYieldBasedOnMultiplierProperFraction(16, .8m); //16 * .8 = 12.8
            var value = 16 * .8m; 
            var expected = "12 3/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void MultilpyToProperFractionHigher() {
            var yieldTest = new YieldCalculations();
            var actual = yieldTest.MultilpyYieldBasedOnMultiplierProperFraction(32, 4.5m);
            var expected = "144";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void MultiplyToProperFraction() {
            var yieldTest = new YieldCalculations(); 
            var actual = yieldTest.MultilpyYieldBasedOnMultiplierProperFraction(10, .25m);
            var expected = "2 1/2";
            Assert.AreEqual(expected, actual); 
        }
    }
}