using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAU_DA304E_INL3.Model
{
    /// <summary>
    /// A model to calculate BMI 
    /// </summary>
    public class BmiCalculationModel
    {
        internal UnitTypes Unit { get; set; }
        internal double Height { get; set; }
        internal double HeightInches { get; set; }
        internal double Weight { get; set; }
        internal double Bmi { get; set; }
        internal string WeightCategory { get; set; }
        internal string NormalWeight { get; set; }
        internal string Name { get; set; }

        internal Dictionary<double, string> LookupNutritionalValues = new Dictionary<double, string>
            {
                { 18.5, "Underweight" },
                { 24.9, "Normal Weight" },
                { 29.9, "Overweight (Pre-obesity)" },
                { 34.9, "Overweight (Obesity class I" },
                { 39.9, "Overweight (Obesity class II" },
                { 1000, "Overweight (Obesity class III" }
            };

    }
}
