using MAU_DA304E_INL3.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MAU_DA304E_INL3.ViewModels
{
    public class BmiCalculationViewModel : ViewModelBase
    {        
        #region Private properties
        private bool _metric;
        private UnitTypes _unitTypes;
        private Visibility _visibleMetric;
        private Visibility _visibleImperial;
        private string _name;
        private double _height;
        private double _weight;
        private double _heightInches;
        private double _bmi;
        private string _weightCategory;
        private string _normalWeight;

        private Dictionary<double, string> _lookupNutritionalValues = new Dictionary<double, string>
            {
                { 18.5, "Underweight" },
                { 24.9, "Normal Weight" },
                { 29.9, "Overweight (Pre-obesity)" },
                { 34.9, "Overweight (Obesity class I" },
                { 39.9, "Overweight (Obesity class II" },
                { 1000, "Overweight (Obesity class III" }
            };

        #endregion
        #region Internal properties
        public bool Metric
        {
            get => _metric;
            set => SetProperty(ref _metric, value);
        }
        public Visibility VisibleMetric
        {
            get => _visibleMetric;
            set => SetProperty(ref _visibleMetric, value);
        }
        public Visibility VisibleImperial
        {
            get => _visibleImperial;
            set => SetProperty(ref _visibleImperial, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public double Height
        {
            get => _height;
            set
            {
                if(double.TryParse(value, out double parsedValue))
                {
                    SetProperty(ref _height, value);
                }
                else
                {
                    System.Exception.
                }
                
            }
        }
        public double Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }
        public double HeightInches
        {
            get => _heightInches;
            set => SetProperty(ref _heightInches, value);
        }
        public double Bmi
        {
            get => _bmi;
            set => SetProperty(ref _bmi, value);
        }
        public string WeightCategory
        {
            get => _weightCategory;
            set => SetProperty(ref _weightCategory, value);
        }
        public string NormalWeight
        {
            get => _normalWeight;
            set => SetProperty(ref _normalWeight, value);
        }
        public BaseICommand ToggleUnit { get; }
        public BaseICommand CalculateBmi { get; }
        #endregion

        public BmiCalculationViewModel()
        {
            ToggleUnit = new BaseICommand(ToggleUnitAction, CanToggleUnit);
            CalculateBmi = new BaseICommand(CalculateBmiAction, CanCalculateBmi);
            Metric = true;
            VisibleMetric = Visibility.Visible;
            VisibleImperial = Visibility.Collapsed;
        }

        private bool CanToggleUnit()
        {
            return true;
        }

        private bool CanCalculateBmi()
        {
            return _height != 0 && _weight != 0;
        }

        private void ToggleUnitAction()
        {
            Metric = !Metric;
            VisibleMetric = Metric ? Visibility.Visible : Visibility.Collapsed;
            VisibleImperial = Metric ? Visibility.Collapsed : Visibility.Visible;
            Height = 0;
            Weight = 0;
        }

        private void CalculateBmiAction()
        {
            double minWeight;
            double maxWeight;

            if(Metric)
            {
                if(_height > 10)
                {
                    double heightCalc = _height * _height / 10000;
                    Bmi = Math.Round(_weight / heightCalc, 1);
                    minWeight = Math.Round(18.5 * heightCalc, 1);
                    maxWeight = Math.Round(24.9 * heightCalc, 1);
                }
                else
                {
                    double heightCalc = _height * _height;
                    Bmi = Math.Round(_weight / heightCalc, 1);
                    minWeight = Math.Round(18.5 * heightCalc, 1);
                    maxWeight = Math.Round(24.9 * heightCalc, 1);
                }

                NormalWeight = $"Normal weight should be between {minWeight} and {maxWeight} kg";
            }
            else
            {
                double heightCalc = (_height * 12 + _heightInches) * (_height * 12 + _heightInches);
                minWeight = Math.Round(18.5 * heightCalc, 1);
                maxWeight = Math.Round(24.9 * heightCalc, 1);
                Bmi = Math.Round(703.0 * _weight / heightCalc, 1);
                NormalWeight = $"Normal weight should be between {minWeight} and {maxWeight} lbs";
            }

            WeightCategory = _lookupNutritionalValues.Where(keyValue => keyValue.Key > Bmi).OrderBy(keyValue => keyValue.Key).First().Value;
        }

    }

}
