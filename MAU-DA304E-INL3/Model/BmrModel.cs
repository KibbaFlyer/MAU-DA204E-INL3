using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAU_DA304E_INL3.Model
{
    /// <summary>
    /// A model to calculate and show BMR values
    /// </summary>
    class BmrModel
    {
        internal double ActivityLevelFactor { get; set; }
        internal GenderTypes Gender {  get; set; }
        internal int Age {  get; set; }
        internal string Results {  get; set; }

        internal Dictionary<string, double> LookUpActivityFactors = new Dictionary<string, double>
            {
                {"Sedentary",1.2 },
                {"Lightly active" , 1.375 },
                {"Moderately active" , 1.550 },
                {"Very active" , 1.725 },
                {"Extra active" , 1.9 },
            };
    }
}
