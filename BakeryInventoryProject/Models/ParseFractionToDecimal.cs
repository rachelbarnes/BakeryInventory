using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BakeryInventoryProject.Models {
    public class ParseFractionToDecimal {
        public string[] SplitFraction(string fraction) {
            var i = 0;
            foreach (var ch in fraction) {
                if (ch == '/') {
                    break;
                }
                i++;
            }
            var numerator = fraction.Substring(0, i);
            var denominator = fraction.Substring(i + 1);
            var fractionArray = new string[2];
            fractionArray[0] = numerator;
            fractionArray[1] = denominator;
            return fractionArray;
        }
        //automatically rounds to the hundreth decimal place
        public decimal CalculateFractionToDecimal(string fraction) {
            var round = new YieldCalculations();
            var split = new SplitFraction();
            var fractionSplit = new string[] { };
            var properFraction = new string[] { };
            var wholeNumber = 0m;
            var numerator = 0m;
            var denominator = 0m;
            if (!fraction.Contains('/')) {
                return System.Convert.ToDecimal(fraction); 
            }
            if (!fraction.Contains(' ')) {
                fractionSplit = SplitFraction(fraction);
                numerator = System.Convert.ToDecimal(fractionSplit[0]);
                denominator = System.Convert.ToDecimal(fractionSplit[1]);
            } else if (fraction.Contains(' ')) {
                properFraction = split.SplitProperFractionIntoWholeNumberAndFraction(fraction);
                fractionSplit = SplitFraction(properFraction[1]);
                wholeNumber = System.Convert.ToDecimal(properFraction[0]);
                numerator = System.Convert.ToDecimal(fractionSplit[0]);
                denominator = System.Convert.ToDecimal(fractionSplit[1]);
                var decimalValue = (numerator / denominator) + wholeNumber; 
                return round.RoundToNthPlace(decimalValue, 2);
            }
            return round.RoundToNthPlace((numerator / denominator), 2);
        }
    }
}