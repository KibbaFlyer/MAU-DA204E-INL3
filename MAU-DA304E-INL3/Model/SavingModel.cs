using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MAU_DA304E_INL3.Model
{
    /// <summary>
    /// Model used to calculate savings
    /// </summary>
    public class SavingModel
    {
        internal double InitialDeposit {  get; set; }
        internal double MonthlyDeposit { get; set; }
        internal int PeriodYears { get; set; }
        internal double Interest {  get; set; }
        internal double Fees { get; set; }
        internal double AmountPaid { get; set; }
        internal double AmountEarned { get; set; }
        internal double FinalBalance { get; set; }
        internal double TotalFees { get; set; }
    }
}
