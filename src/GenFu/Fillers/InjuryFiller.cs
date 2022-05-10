namespace GenFu.Fillers;

public class InjuryFiller : PropertyFiller<string>
{
    public InjuryFiller()
        : base(new[] { "object" }, new[] { "injury" }) { }

    public override object GetValue(object instance)
     => ValueGenerators.Medical.Injuries.Injury();
}
