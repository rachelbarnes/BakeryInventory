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
        public string[] SplitProperFractionIntoWholeNumberAndFraction(string measurement) {
            var measurementValue = "";
            if (DoesMeasurementHaveLetters(measurement))
                measurementValue = SplitMeasurementValueAndName(measurement)[0];
            else measurementValue = measurement;
            var space = 0;
            for (int i = 0; i < measurementValue.Length; i++) {
                if (measurementValue[i] == ' ') {
                    space = i;
                }
            }
            var measurementValueSingleElement = new string[] { };
            if (space == 0) {
                measurementValueSingleElement = new string[] { measurementValue };
                return measurementValueSingleElement;
            } else {
                var wholeNumber = measurementValue.Substring(0, space);
                var fraction = measurementValue.Substring(space + 1);
                measurementValueSingleElement = new string[] { wholeNumber, fraction };
                return measurementValueSingleElement;
            }

        }
        public string[] SplitFractionIntoNumeratorAndDenominator(string measurement) {
            var fraction = SplitProperFractionIntoWholeNumberAndFraction(measurement);
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
            var numerator = fraction[0].Substring(0, slash);
            var denominator = fraction[0].Substring(slash + 1);
            var splitFraction = new string[] { fraction[0].Substring(0, slash), fraction[0].Substring(slash + 1) };
            return splitFraction;
        }
    }
}