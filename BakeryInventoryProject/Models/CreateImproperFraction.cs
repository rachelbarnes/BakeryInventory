using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class CreateImproperFraction {
        public string[] GetImproperFractionParts(string measurement) {
            var split = new SplitFraction();
            var properFraction = split.SplitProperFractionIntoWholeNumberAndFraction(measurement);
            var smallFraction = new string[] { };
            var wholeNumber = "";
            var numerator = "";
            var denominator = "";
            var improperNumerator = "";
            if (properFraction.Count() == 1) {
                smallFraction = split.SplitFractionIntoNumeratorAndDenominator(properFraction[0]);
                numerator = smallFraction[0];
                denominator = smallFraction[1];
                var improperFractionArray = new string[] { numerator, denominator };
                return improperFractionArray;

            } else {
                smallFraction = split.SplitFractionIntoNumeratorAndDenominator(properFraction[1]);
                wholeNumber = properFraction[0];
                numerator = smallFraction[0];
                denominator = smallFraction[1];
                improperNumerator = ((System.Convert.ToInt32(wholeNumber) * System.Convert.ToInt32(denominator)) + System.Convert.ToInt32(numerator)).ToString();
                var improperFractionArray = new string[] { improperNumerator, denominator };
                return improperFractionArray;
            }
        }
    }
}