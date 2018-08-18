using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryInventoryProject.Models {
    public class YieldCalculationsIngredientMeasurement {
        public decimal UpdateMeasurementBasedOnMultiplier(decimal measurementValue, decimal multiplier) {
            var yield = new YieldCalculations();
            return yield.RoundToNthPlace((measurementValue * multiplier), 2);
        }

        //calculate hte improper fraction

        //create a to do list here.

        //steps: 
        /*          - split measurement value from type
         *  - split measurement, if proper fraction then create as improper fraction
         *  - calculate adjusted measurement from improper fraction
         *  - adjust improper fraction back to proper fraction
         *  - concatenate measurement back
         * */


        public string[] MultiplyOriginalMeasurementArray(string measurement, decimal multiplier) {
            var yield = new YieldCalculations();
            var split = new SplitFraction();
            var parseFractoDec = new ParseFractionToDecimal();
            var parseDectoFrac = new ParseDecimalToFraction();
            //split measurement
            var splitMeasurement = split.SplitMeasurementValueAndName(measurement);
            string measurementValue = splitMeasurement[0]; 
            //split fraction in first part of splitMeasurementValue if needed
            var splitMeasurementValueFraction = new string[] { }; 
            if (measurementValue.Contains(' ')) {
                splitMeasurementValueFraction = split.SplitProperFractionInto2Parts(measurementValue); 
            }
            if(!measurementValue.Contains(' ')) {
                splitMeasurementValueFraction[0] = measurementValue; 
            }
            return splitMeasurementValueFraction; 

            ////convert fraction to decimal
            //var decimalMeasurementValue = parseFractoDec.CalculateFractionToDecimal(splitMeasurementValue[0]);
            ////adjusted decimal value according to the multiplier
            //var adjustedMeasurementValueDecimal = UpdateMeasurementBasedOnMultiplier(decimalMeasurementValue, multiplier);
            ////convert decimal to fraction
            //var adjustedMeasurementValueFraction = parseDectoFrac.CreateProperFractionFromDecimal(adjustedMeasurementValueDecimal);
            ////return full fraction string measurement
            //return adjustedMeasurementValueFraction + " " + splitMeasurementValue[1];
        }
    }
}