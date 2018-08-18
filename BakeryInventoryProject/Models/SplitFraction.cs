using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class SplitFraction {

        public string[] SplitMeasurementValueAndName(string measurement) {
            if (!measurement.Contains(' ')) {
                var splitMeasurementUnchanged = new string[] { measurement };
                return splitMeasurementUnchanged;
            }
            var space = 0;
            for (int i = 0; i < measurement.Length; i++) {
                if (i > 0 && ((System.Char.IsDigit(measurement[i - 1])) && (measurement[i] == ' ') && !(System.Char.IsDigit(measurement[i + 1])))) {
                    space = i;
                    break;
                }
            }
            var splitMeasurement = new string[] { measurement.Substring(0, space), measurement.Substring(space + 1) };
            return splitMeasurement;
        }
        public string[] SplitRegularFration(string fraction) {
            var fractionsplit = new string[] { fraction };
            if (!fraction.Contains('/')) {
                fractionsplit[0] = fraction;
                return fractionsplit;
            }
            var i = 0;
            foreach (var ch in fraction) {
                if (ch == '/') {
                    break;
                }
                i++;
            }
            fractionsplit = new string[] { fraction.Substring(0, i), fraction.Substring(i + 1) };
            return fractionsplit;

        }
        public bool DoesMeasurementHaveLetters(string measurement) {
            foreach (var ch in measurement) {
                if (char.IsLetter(ch)) {
                    return true;
                }
            }
            return false;
        }
        public string[] SplitProperFractionInto2Parts(string measurement) {
            //need to go to starbucks or something onSaturday and rewrite this. 







            //MY CODE IS FAILING HERE BECAUSE THE MEASUREMENT IS USING HTE SPLITMEASUREMENTVALUEANDNAME METHOD TO SPLIT 1 1/2... so there's nothing in the first element of the array
            //need anothe rmethod to split the regular fraction
            var splitMeasurementFraction = new string[] { };
            if (DoesMeasurementHaveLetters(measurement)) {
                splitMeasurementFraction = SplitMeasurementValueAndName(measurement);
                return splitMeasurementFraction;
            }
            var wholeNumber = "";
            var fraction = "";
            var fractionArray = new string[] { };
            var space = 0;
            //if the measurement doesn't contain a space, then return the measurement as is (since we're returning the proper fraction... we want the simpelf raction if that's what we have)
            if (!measurement.Contains(' ')) {
                var unchangedArray = new string[] { measurement };
                return unchangedArray;
            }
            //if the measurement does have a space, then split the whole number from the fraction
            //else if (measurement.Contains(' ')) {
            //get the space
            for (int i = 0; i < measurement.Length; i++) {
                if (measurement[i] == ' ') {
                    space = i;
                    break;
                }
            }
            //splitMeasurementFraction = measurement);
            wholeNumber = measurement.Substring(0, space);
            fraction = measurement.Substring(space + 1);
            fractionArray = new string[] { wholeNumber, fraction };
            return fractionArray;
            //}
            //if (!splitMeasurementFraction[0].Contains(' ')) {
            //    var unchangedArray = new string[] { splitMeasurementFraction[0] };
            //    return unchangedArray;
            //}
            //for (int i = 0; i < splitMeasurementFraction[0].Length; i++) {
            //    if (splitMeasurementFraction[0][i] == ' ') {
            //        space = i;
            //        break;
            //    }
            //}
            //wholeNumber = splitMeasurementFraction[0].Substring(0, space);
            //fraction = splitMeasurementFraction[0].Substring(space + 1);
            //fractionArray = new string[] { wholeNumber, fraction };
            //return fractionArray;

            //}
        }
        public string[] SplitFractionIntoNumeratorAndDenominator(string measurement) {
            var fraction = SplitProperFractionInto2Parts(measurement);
            //this above is where we're getting caught, the string element is "". 
            if (fraction.Count() == 1 && !(fraction[0].Contains('/'))) {
                var fractionArray = new string[] { fraction[0] };
                return fractionArray;
            }
            var slash = 0;
            for (int i = 0; i < fraction[0].Length; i++) {
                if ((i > 0) && (fraction[0][i] == '/')) {
                    slash = i;
                }
            }
            if (fraction.Count() == 1) {
                var numerator = fraction[0].Substring(0, slash);
                var denominator = fraction[0].Substring(slash + 1);
                var splitFraction = new string[] { fraction[0].Substring(0, slash), fraction[0].Substring(slash + 1) };
                return splitFraction;
            } else {
                var splitFraction = new string[] { fraction[1].Substring(0, slash + 1), fraction[1].Substring(slash + 2) };
                var first = splitFraction[0];
                var second = splitFraction[1];
                return splitFraction;
            }
        }
    }
}