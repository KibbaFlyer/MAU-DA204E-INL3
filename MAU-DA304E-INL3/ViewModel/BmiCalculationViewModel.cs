using MAU_DA304E_INL3.Commands;
using MAU_DA304E_INL3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MAU_DA304E_INL3.ViewModel
{
    /// <summary>
    /// An extension of the ViewModelBase
    /// Contains logic and fields to give back BMI, BMR, Savings based on user inputs
    /// </summary>
    public class BmiCalculationViewModel : ViewModelBase
    {
        /// <summary>
        /// Private fields used in calculations in the "backend" 
        /// </summary>
        #region Private fields
        private BmiCalculationModel _model;
        private BmrModel _bmrModel;
        private SavingModel _savingModel;
        private string _windowName = "Super Calculator";
        private UnitTypes _unit;
        private Visibility _visibleMetric;
        private Visibility _visibleImperial;
        #endregion
        /// <summary>
        /// Public properties used to communicate with the "frontend" (view)
        /// </summary>
        #region Public properties
        public Visibility VisibleMetric
        {
            get => _visibleMetric;
            set
            {
                if (_visibleMetric != value)
                {
                    _visibleMetric = value;
                    OnPropertyChanged(nameof(VisibleMetric));
                }
            }
        }
        public Visibility VisibleImperial
        {
            get => _visibleImperial;
            set
            {
                if (_visibleImperial != value)
                {
                    _visibleImperial = value;
                    OnPropertyChanged(nameof(VisibleImperial));
                }
            }
        }
        public string WindowName
        {
            get => _windowName;
            set
            {
                if (WindowName != value)
                {
                    _windowName = value;
                    OnPropertyChanged(nameof(WindowName));
                }
            }
        }
        public string Name
        {
            get => _model.Name;
            set
            {
                if (_model.Name != value)
                {
                    _model.Name = value;
                    WindowName = $"Super Calculator by {value}";
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Height
        {
            get => _model.Height.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue) && parsedValue > 0 && parsedValue != _model.Height)
                {
                    _model.Height = parsedValue;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }
        public string Weight
        {
            get => _model.Weight.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue) && parsedValue > 0 && parsedValue != _model.Weight)
                {
                    _model.Weight = parsedValue;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
        public string HeightInches
        {
            get => _model.HeightInches.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue) && parsedValue > 0 && parsedValue != _model.HeightInches)
                {
                    _model.HeightInches = parsedValue;
                    OnPropertyChanged(nameof(HeightInches));
                }
            }
        }
        public double Bmi
        {
            get => _model.Bmi;
            set
            {
                if (_model.Bmi != value)
                {
                    _model.Bmi = value;
                    OnPropertyChanged(nameof(Bmi));
                }
            }
        }
        public string WeightCategory
        {
            get => _model.WeightCategory;
            set
            {
                if (_model.WeightCategory != value)
                {
                    _model.WeightCategory = value;
                    OnPropertyChanged(nameof(WeightCategory));
                }
            }
        }

        public string NormalWeight
        {
            get => _model.NormalWeight;
            set
            {
                if (_model.NormalWeight != value)
                {
                    _model.NormalWeight = value;
                    OnPropertyChanged(nameof(NormalWeight));
                }
            }
        }
        #region Saving Plan
        public string InitialDeposit
        {
            get => _savingModel.InitialDeposit.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    _savingModel.InitialDeposit = parsedValue;
                    OnPropertyChanged(nameof(InitialDeposit));
                }
            }
        }
        public string MonthlyDeposit
        {
            get => _savingModel.MonthlyDeposit.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    _savingModel.MonthlyDeposit = parsedValue;
                    OnPropertyChanged(nameof(MonthlyDeposit));
                }
            }
        }
        public string PeriodYears
        {
            get => _savingModel.PeriodYears.ToString();
            set
            {
                if (int.TryParse(value, out int parsedValue))
                {
                    _savingModel.PeriodYears = parsedValue;
                    OnPropertyChanged(nameof(PeriodYears));
                }
            }
        }
        public string Interest
        {
            get => _savingModel.Interest.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    _savingModel.Interest = parsedValue;
                    OnPropertyChanged(nameof(Interest));
                }
            }
        }
        public string Fees
        {
            get => _savingModel.Fees.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    _savingModel.Fees = parsedValue;
                    OnPropertyChanged(nameof(Fees));
                }
            }
        }
        public double AmountPaid
        {
            get => _savingModel.AmountPaid;
            set
            {
                _savingModel.AmountPaid = value;
                OnPropertyChanged(nameof(AmountPaid));
            }
        }
        public double AmountEarned
        {
            get => _savingModel.AmountEarned;
            set
            {
                _savingModel.AmountEarned = value;
                OnPropertyChanged(nameof(AmountEarned));
            }
        }
        public double FinalBalance
        {
            get => _savingModel.FinalBalance;
            set
            {
                _savingModel.FinalBalance = value;
                OnPropertyChanged(nameof(FinalBalance));
            }
        }
        public double TotalFees
        {
            get => _savingModel.TotalFees;
            set
            {
                _savingModel.TotalFees = value;
                OnPropertyChanged(nameof(TotalFees));
            }
        }
        #endregion
        #region BMR
        public double ActivityLevelFactor
        {
            get => _bmrModel.ActivityLevelFactor;
            set
            {
                _bmrModel.ActivityLevelFactor = value;
                OnPropertyChanged(nameof(ActivityLevelFactor));
            }
        }
        public string Age
        {
            get => _bmrModel.Age.ToString();
            set
            {
                if (int.TryParse(value, out int parsedValue))
                {
                    _bmrModel.Age = parsedValue;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }
        public string BmrResults
        {
            get => _bmrModel.Results;
            set
            {
                _bmrModel.Results = value;
                OnPropertyChanged(nameof(BmrResults));
            }
        }
        #endregion
        public BaseICommand ToggleMetricUnit { get; }
        public BaseICommand ToggleImperialUnit { get; }
        public BaseICommand ToggleGenderButton { get; }
        public BaseICommand ToggleWeeklyActivity { get; }
        public BaseICommand CalculateBmi { get; }
        public BaseICommand CalculateSaving { get; }
        public BaseICommand CalculateBmr { get; }
        #endregion

        public BmiCalculationViewModel()
        {
            /// Setting the Models for the ViewModel. I have chosen to split the models into three, since the funcionality is not very interconnected.
            /// The bmrModel could of course the included within the _model. But nevertheless, I feel the split makes sense in how the functionality is split.
            _model = new BmiCalculationModel();
            _bmrModel = new BmrModel();
            _savingModel = new SavingModel();
            /// Here I set the toggle-methods (connected to the radio buttons). I started doing the Unit methods, that is why they are made a bit differently than the Activity one.
            /// The Activity-toggle has an argument, in order to allow for one method to be called with several radio buttons (just with a commandparameter to give different results)
            ToggleMetricUnit = new BaseICommand(ToggleMetricUnitAction, CanToggleUnit);
            ToggleImperialUnit = new BaseICommand(ToggleImperialUnitAction, CanToggleUnit);
            ToggleGenderButton = new BaseICommand(ToggleGenderButtonAction, CanToggleGender);
            ToggleWeeklyActivity = new BaseICommand(new Action<object>(ToggleWeeklyActivityAction), CanToggleActivity);
            /// The commands that does calculations
            CalculateBmi = new BaseICommand(CalculateBmiAction, CanCalculateBmi);
            CalculateSaving = new BaseICommand(CalculateSavingAction, CanCalculateSaving);
            CalculateBmr = new BaseICommand(CalculateBmrAction, CanCalculateBmr);
            // I set visibility of Metric/Imperial upon initialization
            VisibleMetric = Visibility.Visible;
            VisibleImperial = Visibility.Collapsed;
        }
        /// <summary>
        /// Here follows the methods used to create "business logic" in the application
        /// </summary>
        #region Methods
        /// <summary>
        /// If the Unit can be toggled
        /// </summary>
        /// <returns>A bool (default true)</returns>
        private bool CanToggleUnit()
        {
            return true;
        }
        /// <summary>
        /// If the gender can be toggled
        /// </summary>
        /// <returns>A bool (default true)</returns>
        private bool CanToggleGender()
        {
            return true;
        }
        /// <summary>
        /// If the activity can be toggled
        /// </summary>
        /// <param name="parameter">Argument from the radio button</param>
        /// <returns>A bool (default true)</returns>
        private bool CanToggleActivity(object parameter)
        {
            return true;
        }
        /// <summary>
        /// If the BMI can be calculated
        /// </summary>
        /// <returns>A bool based on if required values are filled out</returns>
        private bool CanCalculateBmi()
        {
            return _model.Height != 0 && _model.Weight != 0;
        }
        /// <summary>
        /// If the Savings can be calculated
        /// </summary>
        /// <returns>A bool based on if required values are filled out</returns>
        private bool CanCalculateSaving()
        {
           return (_savingModel.InitialDeposit != 0 && _savingModel.PeriodYears != 0);
        }
        /// <summary>
        /// If the Bmr can be calculated
        /// </summary>
        /// <returns>A bool based on if required values are filled out</returns>
        private bool CanCalculateBmr()
        {
            return (_bmrModel.Age != 0 && _bmrModel.ActivityLevelFactor != 0 && CanCalculateBmi());
        }
        /// <summary>
        /// Toggles metric/imperial back and forth, also clears the height and weight values
        /// </summary>
        private void ToggleMetricUnitAction()
        {
            VisibleMetric = Visibility.Visible;
            VisibleImperial = Visibility.Collapsed;
            _unit = UnitTypes.Metric;
            Height = "";
            Weight = "";
        }
        /// <summary>
        /// Toggles metric/imperial back and forth, also clears the height and weight values
        /// </summary>
        private void ToggleImperialUnitAction()
        {
            VisibleMetric = Visibility.Collapsed;
            VisibleImperial = Visibility.Visible;
            _unit = UnitTypes.Imperial;
            Height = "";
            Weight = "";
        }
        /// <summary>
        /// Toggles the Gender back and forth
        /// </summary>
        private void ToggleGenderButtonAction()
        {
            _bmrModel.Gender = (_bmrModel.Gender == GenderTypes.Female) ? GenderTypes.Male : GenderTypes.Female;
        }
        /// <summary>
        /// Toggles the weekly activity values
        /// </summary>
        /// <param name="parameter">The argument sent from the radio button</param>
        private void ToggleWeeklyActivityAction(object parameter)
        {
            ActivityLevelFactor = _bmrModel.LookUpActivityFactors.Where(keyValue => keyValue.Key == parameter.ToString()).OrderBy(keyValue => keyValue.Key).First().Value;
        }
        /// <summary>
        /// Calculates BMI
        /// </summary>
        private void CalculateBmiAction()
        {
            double minWeight;
            double maxWeight;

            if(_unit == UnitTypes.Metric)
            {
                if(_model.Height > 10)
                {
                    double heightCalc = _model.Height * _model.Height / 10000;
                    Bmi = Math.Round(_model.Weight / heightCalc, 1);
                    minWeight = Math.Round(18.5 * heightCalc, 1);
                    maxWeight = Math.Round(24.9 * heightCalc, 1);
                }
                else
                {
                    double heightCalc = _model.Height * _model.Height;
                    Bmi = Math.Round(_model.Weight / heightCalc, 1);
                    minWeight = Math.Round(18.5 * heightCalc, 1);
                    maxWeight = Math.Round(24.9 * heightCalc, 1);
                }

                NormalWeight = $"Normal weight should be between {minWeight} and {maxWeight} kg";
            }
            else
            {
                double heightCalc = (_model.Height * 12 + _model.HeightInches) * (_model.Height * 12 + _model.HeightInches);
                minWeight = Math.Round(18.5 * heightCalc / 703.0, 1);
                maxWeight = Math.Round(24.9 * heightCalc / 703.0, 1);
                Bmi = Math.Round(703.0 * _model.Weight / heightCalc, 1);
                NormalWeight = $"Normal weight should be between {minWeight} and {maxWeight} lbs";
            }

            WeightCategory = _model.LookupNutritionalValues.Where(keyValue => keyValue.Key > Bmi).OrderBy(keyValue => keyValue.Key).First().Value;
        }
        /// <summary>
        /// Calculates Savings
        /// </summary>
        private void CalculateSavingAction()
        {
            AmountPaid = 0;
            AmountEarned = 0;
            FinalBalance = 0;
            TotalFees = 0;

            double balance = _savingModel.InitialDeposit + _savingModel.MonthlyDeposit;
            int months = _savingModel.PeriodYears * 12;
            double monthlyInterest = _savingModel.Interest / 100.0 / 12.0;
            double monthlyFees = _savingModel.Fees / 100.0 / 12.0;
            double totalInterest = 0.0;
            double totalInvestment = balance;
            for(int i = 1;  i < months; i++)
            {
                double interest = monthlyInterest * balance;
                double fees = monthlyFees * balance;
                balance += interest - fees + _savingModel.MonthlyDeposit;
                totalInvestment += _savingModel.MonthlyDeposit;
                totalInterest += interest;
                TotalFees += Math.Round(fees,1);
            }

            AmountPaid = Math.Round(totalInvestment,1);
            AmountEarned = Math.Round(balance - totalInvestment,1);
            FinalBalance = Math.Round(balance,1);
        }
        /// <summary>
        /// Calculates BMR
        /// </summary>
        private void CalculateBmrAction()
        {
            double bmr = 0;
            if (_unit == UnitTypes.Metric)
            {
                if (_model.Height > 10)
                {
                    bmr = 10.0 * _model.Weight + 6.25 * _model.Height - 5.0 * _bmrModel.Age;

                }
                else
                {
                    bmr = 10.0 * _model.Weight + 6.25 * _model.Height / 100 - 5.0 * _bmrModel.Age;
                }
            }
            else
            {
                double heightInCm = (_model.Height * 12 + _model.HeightInches) * 2.54;
                double weightInKg = _model.Weight * 0.45359237;
                bmr = 10.0 * weightInKg + 6.25 * heightInCm - 5.0 * _bmrModel.Age;
            }

            if(_bmrModel.Gender == GenderTypes.Female)
            {
                bmr = bmr - 161;
            }
            else if (_bmrModel.Gender == GenderTypes.Male)
            {
                bmr = bmr + 5;
            }
            double bmrTotal = bmr * _bmrModel.ActivityLevelFactor;
            BmrResults =
                $"BMR RESULTS FOR {_model.Name.ToUpper()}\n" +
                $"Your BMR (calories/day)\t{bmr}\n" +
                $"Calories to maintain your weight\t{bmrTotal}\n" +
                $"Calories to lose 0,5 kg per week\t{bmrTotal-500}\n" +
                $"Calories to lose 1 kg per week\t{bmrTotal-1000}\n" +
                $"Calories to gain 0,5 kg per week\t{bmrTotal+500}\n" +
                $"Calories to gain 1 kg per week\t{bmrTotal+1000}\n\n" +
                $"Losing more than 1000 calories per day is to be avoided";
        }

        #endregion
    }
}
