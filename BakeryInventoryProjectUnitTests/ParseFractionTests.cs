using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BakeryInventoryProject.Models;
namespace BakeryInventoryProjectUnitTests {
    [TestFixture]
    public class ParseFractionTests {
        [Test]
        public void ParseSimpleFraction() {
            var parse = new ParseFractionToDecimal();
            var actual = parse.SplitFraction("1/2");
            var expected = new string[2];
            expected[0] = "1";
            expected[1] = "2";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ParseComplexFraction() {
            var parse = new ParseFractionToDecimal();
            var actual = parse.SplitFraction("26/643");
            var expected = new string[2];
            expected[0] = "26";
            expected[1] = "643";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ParseSimpleFractionToDecimal() {
            var parse = new ParseFractionToDecimal();
            var actual = parse.CalculateFractionToDecimal("1/2");
            var expected = .5m;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ParseComplexFractionToDecimal() {
            var parse = new ParseFractionToDecimal();
            var actual = parse.CalculateFractionToDecimal("45/89");
            var expected = .50m;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ParseComplexPractionToDecimal2() {
            var parse = new ParseFractionToDecimal();
            var actual = parse.CalculateFractionToDecimal("126/14");
            var expected = 9m;
            Assert.AreEqual(expected, actual);
        }

    }
}
