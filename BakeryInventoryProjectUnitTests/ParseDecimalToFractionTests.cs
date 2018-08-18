using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BakeryInventoryProject.Models; 

namespace BakeryInventoryProjectUnitTests {
    [TestFixture]
    public class ParseDecimalToFractionTests {
        [Test]
        public void TestSplitDecimal() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseDecimalIntoStringArray(1.5m);
            var expected = new string[] { "1", ".5" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void TestSplitDecimal2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseDecimalIntoStringArray(26.589m);
            var expected = new string[] { "26", ".589" };
            Assert.AreEqual(expected, actual); 
        }
        [Test]
            public void TestSplitDecimal3() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseDecimalIntoStringArray(.53m);
            var expected = new string[] { "0", ".53" };
            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void RemoveDecimalPoint() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.RemoveDecimalFromDecimalLessThanOne(.45m);
            var expected = 45;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveDecimalPoint2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.RemoveDecimalFromDecimalLessThanOne(.5984m);
            var expected = 5984;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void IsEvenTestTrue() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.IsEven(4.66m);
            var expected = true;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void IsEvenTestTrue2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.IsEven(.82m);
            var expected = true;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void IsEvenTestFalse() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.IsEven(8.23m);
            var expected = false;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void IsEvenTestFalse2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.IsEven(.99m);
            var expected = false;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void DivideDecimalInHalfAndRound() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.DivideDecimalInHalfAndRoundToHundred(1.5m);
            var expected = .75m;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
            public void DivideDecimalInHalfAndRound2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.DivideDecimalInHalfAndRoundToHundred(2.33m);
            var expected = 1.16m;
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(1.10m);
            var expected = "1/4";
            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void ParseValueAfterDecimal1() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(1.10m);
            var expected = "1/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal2() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.14m);
            var expected = "1/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal3() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(4.30m);
            var expected = "1/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal4() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.32m);
            var expected = "1/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal5() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(40.38m);
            var expected = "1/2";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal6() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.50m);
            var expected = "1/2";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal7() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(1.56m);
            var expected = "2/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal8() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.60m);
            var expected = "2/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal9() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(1.70m);
            var expected = "3/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal10() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.84m);
            var expected = "3/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal11() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(1.90m);
            var expected = "1";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseValueAfterDecimal12() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.ParseToFractionAfterDecimal(.99m);
            var expected = "1";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseProperFractionTest1() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(1.26m);
            var expected = "1 1/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseProperFractionTest2() {
            var parse =new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(.66m);
            var expected = "2/3";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseProperFractionTest3() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(5.82m);
            var expected = "5 3/4";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseProperFractionTest4() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(0m);
            var expected = "";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void ParseProperFractionTest5() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(13m);
            var expected = "13";
            Assert.AreEqual(expected, actual); 
        }
        [Test]
        public void PraseProperFractionTest6() {
            var parse = new ParseDecimalToFraction();
            var actual = parse.CreateProperFractionFromDecimal(9m);
            var expected = "9";
            Assert.AreEqual(expected, actual); 
        }
    }
}
