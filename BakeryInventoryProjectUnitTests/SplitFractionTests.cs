using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BakeryInventoryProject.Models; 

namespace BakeryInventoryProjectUnitTests {
    public class SplitFractionTests {
        [Test]
        public void SplitMeasurementTest() {
            var split = new SplitFraction();
            var actual = split.SplitMeasurementValueAndName("1 cup");
            var expected = new string[] { "1", "cup" };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SplitMeasurementTest1() {
            var split = new SplitFraction();
            var actual = split.SplitMeasurementValueAndName("1 1/2 teaspoons");
            var expected = new string[] { "1 1/2", "teaspoons" };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SplitMeasurementTest2() {
            var split = new SplitFraction();
            var actual = split.SplitMeasurementValueAndName(".75 tablespoons");
            var expected = new string[] { ".75", "tablespoons" };
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SplitProperFraction() {
            var split = new SplitFraction();
            var actual = split.SplitProperFractionIntoWholeNumberAndFraction("1 1/2 cups");
            var execpted = new string[] { "1", "1/2" };
            Assert.AreEqual(execpted, actual); 
        }
        [Test]
        public void SplitProperFraction2() {
            var split = new SplitFraction();
            var actual = split.SplitProperFractionIntoWholeNumberAndFraction("3 1/3 cups");
            var expected = new string[] { "3", "1/3" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitProperFraction3() {
            var split = new SplitFraction();
            var actual = split.SplitProperFractionIntoWholeNumberAndFraction("3/4 teaspoons");
            var expected = new string[] { "3/4" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitMeasurementFraction() {
            var split = new SplitFraction();
            var actual = split.SplitFractionIntoNumeratorAndDenominator("1/2 cups");
            var expected = new string[] { "1", "2" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitMeasurementFraction1() {
            var split = new SplitFraction();
            var actual = split.SplitFractionIntoNumeratorAndDenominator("3 3/4 tablespoons");
            var exected = new string[] { "3", "4" };
            Assert.AreEqual(exected, actual); 
        }
        [Test]
        public void SplitMesaurementFractio4() {
            var split = new SplitFraction();
            var actual = split.SplitFractionIntoNumeratorAndDenominator("4 5/16 cups");
            var expected = new string[] { "5", "16" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitMeasurementFraction2() {
            var split = new SplitFraction();
            var actual = split.SplitFractionIntoNumeratorAndDenominator("3 cups");
            var expected = new string[] { "3" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitMesaurementFraction3() {
            var split = new SplitFraction();
            var actual = split.SplitFractionIntoNumeratorAndDenominator("56/789 cups");
            var expected = new string[] { "56", "789" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitRegularFraction() {
            var split = new SplitFraction();
            var actual = split.SplitRegularFration("3/4");
            var expected = new string[] { "3", "4" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitRegularFraction1() {
            var split = new SplitFraction();
            var actual = split.SplitRegularFration("7/8");
            var expected = new string[] { "7", "8" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void SplitRegularFraction2() {
            var split = new SplitFraction();
            var actual = split.SplitRegularFration("2");
            var expected = new string[] { "2" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void TestDoesSpringHaveLettersd() {
            var split = new SplitFraction();
            var actual = split.DoesMeasurementHaveLetters("12345");
            var expect = false;
            Assert.AreEqual(expect, actual); 
        }
        [Test]
        public void TestDoesSpringHaveLetters2() {
            var split = new SplitFraction();
            var actual = split.DoesMeasurementHaveLetters("");
            var expected = false;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void TestDoesStringHaveLetters3() {
            var split = new SplitFraction();
            var actual = split.DoesMeasurementHaveLetters("3/4 teapsoons");
            var expected = true;
            Assert.AreEqual(expected, actual); 
        }
    }
}
