// model classes for BMI calculator
// GC

using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BMICalculator
{
    public enum BMICategory { Underweight, Normal, Overweight, Obese };
    public enum InfectionRiskLevel { Low, High };
    public class BMI
    {
        const double UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;               // Obese from 30 +

        // conversion factors from imperial to metric
        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;

        const int AgePriorityLimit = 70;                            // Age for Vaccine Priority Min
        [Display(Name = "Weight - Stones")]
        [Range(5, 50, ErrorMessage = "Stones must be between 5 and 50")]                              // max 50 stone
        public int WeightStones { get; set; }

        [Display(Name = "Pounds")]
        [Range(0, 13, ErrorMessage = "Pounds must be between 0 and 13")]                              // 14 lbs in a stone
        public int WeightPounds { get; set; }

        [Display(Name = "Height - Feet")]
        [Range(4, 7, ErrorMessage = "Feet must be between 4 and 7")]                               // max 7 feet
        public int HeightFeet { get; set; }

        [Display(Name = "Inches")]
        [Range(0, 11, ErrorMessage = "Inches must be between 0 and 11")]                              // 12 inches in a foot
        public int HeightInches { get; set; }

        [Display(Name = "Age - Years")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]                              // Min 1 year Max 120
        public int AgeYears { get; set; }

        // calculate BMI, display to 2 decimal places
        [Display(Name = "Your BMI is")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BMIValue
        {
            get
            {
                // bmi = weight in Kgs / height in metres squared

                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

                return bmi;
            }
        }

        //Assess risk level of person based on BMI and Age
        [Display(Name = "Your risk level for infection is")]
        public InfectionRiskLevel infectionRiskLevel
        {
            get
            {
                int age = this.AgeYears;
                double bmi = this.BMIValue;

                // Vaccine yes or no
                if (bmi <= UnderWeightUpperLimit && age < AgePriorityLimit)
                {
                    return InfectionRiskLevel.Low;
                }
                else if (bmi <= NormalWeightUpperLimit && age < AgePriorityLimit)
                {
                    return InfectionRiskLevel.Low;
                }
                else if (bmi <= UnderWeightUpperLimit && age >= AgePriorityLimit)
                {
                    return InfectionRiskLevel.High;
                }
                else if (bmi <= NormalWeightUpperLimit && age >= AgePriorityLimit)
                {
                    return InfectionRiskLevel.High;
                }
                else if (bmi <= OverWeightUpperLimit && age >= AgePriorityLimit)
                {
                    return InfectionRiskLevel.High;
                }
                else
                {
                    return InfectionRiskLevel.High;
                }
            }
        }
        // calculate BMI category 
        [Display(Name = "Your BMI Category is")]
        public BMICategory BMICategory
        {
            get
            {
                double bmi = this.BMIValue;

                // calculate BMI category based on upper limits
                if (bmi <= UnderWeightUpperLimit)
                {
                    return BMICategory.Underweight;
                }
                else if (bmi <= NormalWeightUpperLimit)
                {
                    return BMICategory.Normal;
                }
                else if (bmi <= OverWeightUpperLimit)
                {
                    return BMICategory.Overweight;
                }
                else
                {
                    return BMICategory.Obese;
                }
            }
        }
    }
}


