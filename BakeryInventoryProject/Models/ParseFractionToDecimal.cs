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
            if (fraction.Contains(' ')) {
                var properFraction = split.SplitProperFractionInto2Parts(fraction);
                fractionSplit = SplitFraction(properFraction[1]);
            } else {
                fractionSplit = SplitFraction(fraction);
            }
            var numerator = System.Convert.ToDecimal(fractionSplit[0]);
            var denominator = System.Convert.ToDecimal(fractionSplit[1]);
            //var resultbefore =
            //var result =
            return round.RoundToNthPlace((numerator / denominator), 2); 
        }
    }
}