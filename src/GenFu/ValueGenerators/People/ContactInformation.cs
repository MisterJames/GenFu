namespace GenFu.ValueGenerators.People;

using System.Linq;

public class ContactInformation : BaseValueGenerator
{
    /// <summary>
    /// Only uses the specified domain for email generation
    /// </summary>
    /// <param name="domain">The domain that you want to have for all email addresses</param>
    /// <returns>A complete email address for the specified domain.</returns>
    public static string Email(string domain)
    {
        return string.Format("{0}.{1}@{2}", GetRandomValue(ResourceLoader.Data(PropertyType.FirstNames)), GetRandomValue(ResourceLoader.Data(PropertyType.LastNames)), domain);
    }

    /// <summary>
    /// Generates a random emails address
    /// </summary>
    /// <returns>A complete email address with a random account and domain.</returns>
    public static string Email()
    {
        int firstNameIndex = _random.Next(0, ResourceLoader.Data(PropertyType.FirstNames).Count());
        int lastNameIndex = _random.Next(0, ResourceLoader.Data(PropertyType.LastNames).Count());
        int domainNameIndex = _random.Next(0, ResourceLoader.Data(PropertyType.Domains).Count());

        // failing test on names with spaces
        string firstname = ResourceLoader.Data(PropertyType.FirstNames)[firstNameIndex].Replace(" ", "");
        string lastname = ResourceLoader.Data(PropertyType.LastNames)[lastNameIndex].Replace(" ", "");

        return string.Format("{0}.{1}@{2}", firstname, lastname, ResourceLoader.Data(PropertyType.Domains)[domainNameIndex]);
    }

    /// <summary>
    /// Generates a random twitter handle
    /// </summary>
    /// <returns></returns>
    public static string Twitter()
    {
        return string.Format("@{0}{1}",
                   ResourceLoader.Data(PropertyType.FirstNames).GetRandomElement().ToCharArray().First(),
                   ResourceLoader.Data(PropertyType.LastNames).GetRandomElement());
    }

    /// <summary>
    /// Returns a north american style phone number
    /// </summary>
    /// <returns>Phone number in the format (123) 456-7890</returns>
    public static string PhoneNumber()
    {
        string result = string.Empty;

        int areacode = _random.Next(200, 799);
        int prefix = _random.Next(200, 799);
        int digits = _random.Next(0, 9999);

        result = string.Format("({0}) {1}-{2:0000}", areacode, prefix, digits);

        return result;
    }
}
