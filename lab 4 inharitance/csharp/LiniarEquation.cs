using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_op
{
    public class LiniarEquation : TEquation
    {
        public LiniarEquation(params int[] vs) : base(vs)
        {

        }

        protected override int CoefficientsCount => 2;

        public override IEnumerable<double> FindRoots()
        {
            yield return 
                Math.Round((double)-Coefficients[1] / (2 * Coefficients[0]) , 5);

        }

       
    }
}
