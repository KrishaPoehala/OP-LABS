struct Numeral_8
{
    private readonly int _value;

    public Numeral_8(string eightBasedNumber)
    {
        _value = Convert.ToInt32(eightBasedNumber, 8);
    }

    public Numeral_8(int value)
    {
        _value = value;
    }

    public int ToBase(int numberBase) => int.Parse(Convert.ToString(_value, numberBase));
    public int ToTenthBase() => ToBase(10);

    public override string ToString() => Convert.ToString(_value, 8);

    public static Numeral_8 operator ++(Numeral_8 numeral)
        => new(numeral._value + 1);

    public static Numeral_8 operator +(Numeral_8 left, Numeral_8 right)
        => new(left._value + right._value);

    public static Numeral_8 operator +(Numeral_8 numeral, int value)
        => new(numeral._value + value);
    public static Numeral_8 operator +(int value, Numeral_8 numeral)
     => new(numeral._value + value);
}
