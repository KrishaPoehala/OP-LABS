var n1 = new Numeral_8(04343);
var n2 = new Numeral_8("0544343");
var n3 = new Numeral_8(0x3232);
n1++;
n2 += 10;
n3 = n1 + n2;
Console.WriteLine(n3.ToTenthBase());

