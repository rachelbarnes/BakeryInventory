using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BakeryInventoryProject.Models; 
namespace BakeryInventoryProjectUnitTests {
    [TestFixture]
    class CreateImproperFractionTests {

        //THESE TESTS ARE FAILING BECAUSE I need to add a new split measurement method to split a simple fraction... 
        //the SplitProperFractionInto2Parts is not cutting it... need to go through and make sure i didn't confuse stuff. 
        [Test]
       public void CreateImproperFractionFromMeasurement1() {
            var create = new CreateImproperFraction();
            var actual = create.GetImproperFractionParts("1 1/2 cups");
            var expected = new string[] { "3", "2" };
            Assert.AreEqual(expected, actual); 
        } 
        [Test]
        public void CreateImproperFractionFromMeasurement2() {
            var create = new CreateImproperFraction();
            var actual = create.GetImproperFractionParts("3/4 teaspoons");
            var expected = new string[] { "3", "4" };
            Assert.AreEqual(expected, actual); 
            }
        [Test]
        public void CreateImproperFractionFromMeasurement3() {
            var create = new CreateImproperFraction();
            var actual = create.GetImproperFractionParts("6 3/4 cups");
            var expected = new string[] { "27", "4" };
            Assert.AreEqual(expected, actual); 
        }
    }
}
