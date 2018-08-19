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


        public decimal MultiplyOriginalMeasurementToDecimal(string measurement, decimal multiplier) {
            var yield = new YieldCalculations();
            var split = new SplitFraction();
            var parseFractoDec = new ParseFractionToDecimal();
            var parseDectoFrac = new ParseDecimalToFraction();
            var splitMeasurement = split.SplitMeasurementValueAndName(measurement);
            string measurementValue = splitMeasurement[0];
            var decimalValueOfFraction = parseFractoDec.CalculateFractionToDecimal(measurementValue);
            var updatedDecimalValue = (decimalValueOfFraction * multiplier);
            var updatedMeasurementBasedOnMultiplier = yield.RoundToNthPlace(updatedDecimalValue, 2); 
            return updatedMeasurementBasedOnMultiplier; 
        }
        public string MultiplyOriginalMeasurementToMeasurementValueString(string measurement, decimal multiplier) {
            var decToFrac = new ParseDecimalToFraction(); 
            var decimalValueOfMultipliedMeasurement = MultiplyOriginalMeasurementToDecimal(measurement, multiplier);
            var decimalToFraction = decToFrac.CreateProperFractionFromDecimal(decimalValueOfMultipliedMeasurement);
            return decimalToFraction; 
        }
    }
}