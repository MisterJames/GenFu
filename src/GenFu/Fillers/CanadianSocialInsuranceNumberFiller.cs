namespace GenFu.Fillers;

using System;
using System.Text;

class CanadianSocialInsuranceNumberFiller : PropertyFiller<String>
{
    public CanadianSocialInsuranceNumberFiller()
        : base(new[] { "object" }, new[] { "SIN", "SocialInsuranceNumber" }) { }

    public override object GetValue(object instance)
    {
        var number = new StringBuilder();
        number.Append(RandomDigit());
        number.Append(RandomDigit());
        number.Append(RandomDigit());
        number.Append("-");
        number.Append(RandomDigit());
        number.Append(RandomDigit());
        number.Append(RandomDigit());
        number.Append("-");
        number.Append(RandomDigit());
        number.Append(RandomDigit());
        number.Append(GetFinalDigit(number.ToString()));
        return number.ToString();
    }

    private static Random _random = new Random();

    protected internal string RandomDigit() => (_random.Next() % 10).ToString();

    protected internal string GetFinalDigit(string numberSoFar)
    {
        int runningTotal = 0;
        foreach (var character in numberSoFar.ToCharArray())
        {
            if (Char.IsDigit(character))
                runningTotal += Int32.Parse(character.ToString());
        }

        if (runningTotal % 10 == 0)
            return "0";

        return (10 - (runningTotal % 10)).ToString();
    }
}
