namespace GenFu.Fillers;

class CompanyNameFiller : PropertyFiller<string>, IPropertyFiller
{
    public CompanyNameFiller() : base(new[] { "company" }, new[] { "name" }) { }

    public override object GetValue(object instance)
     => ValueGenerators.Corporate.Company.Name();
}
