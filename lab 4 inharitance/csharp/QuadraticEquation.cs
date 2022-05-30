using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_op;

public class QuadraticEquation : TEquation
{
    protected override int CoefficientsCount => 3;

    public QuadraticEquation(params int[] vs) : base(vs)
    {
    }

    private (int a, int b, int c) Deconstruct()
    {
        int a = Coefficients[0];
        int b = Coefficients[1];
        int c = Coefficients[2];
        return(a, b, c);
    }

    public override IEnumerable<double> FindRoots()
    {
        var (a, b, c) = Deconstruct();
        var D = Math.Pow(b, 2) - 4 * a * c;
        if (D < 0)
        {
            throw new Exception("The equation does not have any roots");
        }

        if (D == 0)
        {
            var root = -b / (2 * a);
            yield return root;
        }

        if (D > 0)
        {
            var sqrtD = Math.Round(Math.Sqrt(D), 5);
            var root1 = (-b + sqrtD) / (2 * a);
            var root2 = (-b - sqrtD) / (2 * a);
            yield return root1;
            yield return root2;
        }
    }

    public override bool HaveAnyRoots()
    {
        if (base.HaveAnyRoots() == false)
            return false;

        var (a, b, c) = Deconstruct();
        var D = Math.Pow(b, 2) - 4 * a * c;
        if (D < 0)
            return false;

        return true;


    }
}
