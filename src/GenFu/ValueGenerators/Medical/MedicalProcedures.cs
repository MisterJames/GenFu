namespace GenFu.ValueGenerators.Medical;

public class MedicalProcedures : BaseValueGenerator
{
    public static string MedicalProcedure()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.MedicalProcedures));
    }
}
