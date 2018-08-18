using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class ParseDecimalToFraction {
        public string[] ParseDecimalIntoStringArray(decimal value) {
            var i = 0;
            foreach (var ch in value.ToString()) {
                if (ch == '.') {
                    break;
                }
                i++;
            }
            var decimalStringArray = new string[] { (value.ToString().Substring(0, i)), value.ToString().Substring(i) };
            return decimalStringArray;
        }
        public int RemoveDecimalFromDecimalLessThanOne(decimal value) {
            return System.Convert.ToInt32(ParseDecimalIntoStringArray(value)[1].Substring(1));
        }

        public bool IsEven(decimal value) {
            if (RemoveDecimalFromDecimalLessThanOne(value) % 2 == 0)
                return true;
            else return false;
        }
        public decimal DivideDecimalInHalfAndRoundToHundred(decimal value) {
            var yield = new YieldCalculations();
            return yield.RoundToNthPlace((value / 2), 2);
        }
        //1/4, 1/3, 1/2, 2/3, 3/4 
        public string ParseToFractionAfterDecimal(decimal value) {
            var valueToParse = RemoveDecimalFromDecimalLessThanOne(value);
            if (valueToParse.ToString().Length == 1) {
                valueToParse = valueToParse * 10; 
            }
            if (valueToParse == 0)
                return "";
            if (valueToParse <= 25)
                return "1/4";
            if (valueToParse >= 26 && valueToParse <= 33)
                return "1/3";
            if (valueToParse >= 34 && valueToParse <= 50)
                return "1/2";
            if (valueToParse >= 51 && valueToParse <= 67)
                return "2/3";
            if (valueToParse >= 68 && valueToParse <= 87)
                return "3/4";
            if (valueToParse >= 88)
                return "1";
            else return "";
        }
        public string CreateProperFractionFromDecimal(decimal value) {
            if (value == 0m)
                return "";
            var decimalStringArray = ParseDecimalIntoStringArray(value);
            if (decimalStringArray.Count() == 1 || decimalStringArray[1] == "") {
                return decimalStringArray[0]; 
            }
            var parsedFractionDecimalValue = ParseToFractionAfterDecimal(System.Convert.ToDecimal(decimalStringArray[1]));
            if (decimalStringArray[0] == "0" || decimalStringArray[0] == "")
                return parsedFractionDecimalValue;
            if (decimalStringArray[1] == "" || decimalStringArray[1] == "0" || decimalStringArray[1] == ".0") 
                return decimalStringArray[0];
            else
                return decimalStringArray[0] + " " + parsedFractionDecimalValue; 

        }
        //will not work well with 1 3/2 (where the numerator is larger than the denominator... not concerned about that right now
        //public string CreateFractionFromDecimal(decimal value) {
        //    var mult = new YieldCalculations();
        //    var decimalArray = ParseDecimalIntoStringArray(value);
        //    var denominatorDecimal = mult.RoundToNthPlace(System.Convert.ToDecimal(decimalArray[1]), 2);
        //    var parsedFractionDecimalValue = 0m;
        //    var parsedFraction = new string[] { };
        //    if (IsEven(denominatorDecimal)) {
        //        parsedFractionDecimalValue = denominatorDecimal;
        //        if (IsEven(parsedFractionDecimalValue / 2)) {

        //        }
        //    }

    }
}