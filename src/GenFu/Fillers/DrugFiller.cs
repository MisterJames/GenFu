namespace GenFu.Fillers;

public class DrugFiller : PropertyFiller<string>
{
    public DrugFiller()
        : base(new[] { "object" }, new[] { "drug", "drugs", "Rx", "perscription" }) { }

    public override object GetValue(object instance)
     => ValueGenerators.Medical.Drugs.Drug();
}
