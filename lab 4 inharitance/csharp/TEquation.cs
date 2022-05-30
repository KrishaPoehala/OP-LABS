
namespace lab4_op;
public abstract class TEquation
{
    protected int[] Coefficients { get; set; }
    public TEquation(params int[] vs)
    {
        if (vs.Length == CoefficientsCount)
        {
            Coefficients = vs;
            return;
        }

        throw new ArgumentException("There are too many coeficients", nameof(vs));
    }

    protected abstract int CoefficientsCount { get; }
    public abstract IEnumerable<double> FindRoots();
    public virtual bool HaveAnyRoots() => CoefficientsCount != 0;
    public bool IsRoot(int check)
    {
        int sum = 0;
        for (int i = Coefficients.Length - 1; i >= 0; i--)
        {
            sum += Coefficients[i] * (int)Math.Pow(check, i);
        }

        return sum == 0;
    }
}
