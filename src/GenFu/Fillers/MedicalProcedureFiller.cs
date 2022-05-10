namespace GenFu.Fillers;

public class MedicalProcedureFiller : PropertyFiller<string>
{
    public MedicalProcedureFiller()
        : base(new[] { "object" }, new[] { "procedure", "MedicalProcedure" }) { }

    public override object GetValue(object instance)
    {
        return ValueGenerators.Medical.MedicalProcedures.MedicalProcedure();
    }
}
