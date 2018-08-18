using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class YieldCalculations {
        //round to interger
        public int RoundToInteger(decimal value) {
            int i = 0;
            var valueCharArray = value.ToString().ToCharArray();
            foreach (var ch in valueCharArray) {
                if (ch == '.') {
                    break;
                }
                i++;
            }
            var decimalToRound = (value.ToString()).Substring(i);
            if (System.Convert.ToDecimal(decimalToRound) >= (decimal).50) {
                return System.Convert.ToInt32((value.ToString()).Substring(0, i)) + 1;
            } else {
                return System.Convert.ToInt32((value.ToString()).Substring(0, i));
            }
        }
        //round to interger
        public int Round(decimal value) {
            int i = 0;
            var valueCharArray = value.ToString().ToCharArray();
            foreach (var ch in valueCharArray) {
                if (ch == '.') {
                    break;
                }
                i++;
            }
            var decimalToRound = (value.ToString()).Substring(i);
            if (System.Convert.ToDecimal(decimalToRound) >= (decimal).50) {
                return System.Convert.ToInt32((value.ToString()).Substring(0, i)) + 1;
            } else {
                return System.Convert.ToInt32((value.ToString()).Substring(0, i));
            }
        }
        //multiply yield by multiplier supplied
        public int MultilpyYieldBasedOnMultiplier(int yield, decimal multiplier) {
            return Round(yield * multiplier);
        }
        public string MultilpyYieldBasedOnMultiplierProperFraction(int yield, decimal multiplier) {
            var parseDecimalToFraction = new ParseDecimalToFraction();
            var result = parseDecimalToFraction.CreateProperFractionFromDecimal((yield * multiplier));
            return result;
        }
        //round to nth place, n provided
        public decimal RoundToNthPlace(decimal value, int decimalPlace) {
            if (decimalPlace == 0) {
                return Round(value);
            }
            var i = 0;
            foreach (var ch in value.ToString()) {
                if (ch == '.') {
                    break;
                }
                i++;
            }
            if ((i + decimalPlace) + 1 >= value.ToString().Length)
                return value;
            else {
                var valueToReturn = value.ToString().Substring(0, i + decimalPlace + 1);
                return System.Convert.ToDecimal(valueToReturn);
            }
        }
    }
}