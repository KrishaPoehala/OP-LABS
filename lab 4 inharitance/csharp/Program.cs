using lab4_op;
var rnd = new Random();
int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
var liniarEquations = new List<LiniarEquation>(n);
var quadraticEquations = new List<QuadraticEquation>(m);
for (int i = 0; i < n; i++)
{
    var a = rnd.Next(-100, 100);
    var b = rnd.Next(-100, 100);
    var liniar = new LiniarEquation(a, b);
    liniarEquations.Add(liniar);
}

for (int i = 0; i < m; i++)
{
    var coefficients = Enumerable.Range(0, 3).Select(_ => rnd.Next(-100, 100));
    var quadratic = new QuadraticEquation(coefficients.ToArray());
    quadraticEquations.Add(quadratic);
}


var liniarRoots = new List<double>(n);
foreach (var item in liniarEquations.Where(x => x.HaveAnyRoots()))//ax + b = 0
{
    liniarRoots.AddRange(item.FindRoots());
}

var quadraticRoots = new List<double>(n);
foreach (var item in quadraticEquations.Where(x => x.HaveAnyRoots()))//ax2 + bx + c = 0
{
    var roots = item.FindRoots();
    quadraticRoots.AddRange(roots);
}

Console.WriteLine($"Liniar sum : {liniarRoots.Sum()}");
Console.WriteLine($"Quadratic sum : {quadraticRoots.Sum()}");


Console.WriteLine("Enter a number to check: ");
int numberToCheck = int.Parse(Console.ReadLine());
Console.WriteLine("Enter an equation tp check: ");
int equationToCheck = int.Parse(Console.ReadLine());
equationToCheck = equationToCheck > liniarEquations.Count ? 0 : equationToCheck;
if (liniarEquations[equationToCheck].IsRoot(numberToCheck))
{
    Console.WriteLine("Yeah, you're right!");
}
else
{
    Console.WriteLine("Naah, try next time(");
}





