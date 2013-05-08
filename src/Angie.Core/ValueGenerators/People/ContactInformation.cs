using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.ValueGenerators.People
{
    public class ContactInformation:BaseValueGenerator
    {
        /// <summary>
        /// Only uses the specified domain for email generation
        /// </summary>
        /// <param name="domain">The domain that you want to have for all email addresses</param>
        /// <returns>A complete email address for the specified domain.</returns>
        public static string Email(string domain)
        {
            return string.Format("{0}.{1}@{2}", GetRandomValue(Susan.Data(Properties.FirstNames)), GetRandomValue(Susan.Data(Properties.LastNames)), domain);
        }

        /// <summary>
        /// Generates a random emails address
        /// </summary>
        /// <returns>A complete email address with a random account and domain.</returns>
        public static string Email()
        {
            int firstNameIndex = _random.Next(0, Susan.Data(Properties.FirstNames).Count());
            int lastNameIndex = _random.Next(0, Susan.Data(Properties.LastNames).Count());
            int domainNameIndex = _random.Next(0, Susan.Data(Properties.Domains).Count());

            // failing test on names with spaces
            string firstname = Susan.Data(Properties.FirstNames)[firstNameIndex].Replace(" ", "");
            string lastname = Susan.Data(Properties.LastNames)[lastNameIndex].Replace(" ", "");

            return string.Format("{0}.{1}@{2}", firstname, lastname, Susan.Data(Properties.Domains)[domainNameIndex]);
        }

        /// <summary>
        /// Generates a random twitter handle
        /// </summary>
        /// <returns></returns>
        public static string Twitter()
        {
            return string.Format("@{0}{1}",
                       Susan.Data(Properties.FirstNames).GetRandomElement().ToCharArray().First(),
                       Susan.Data(Properties.LastNames).GetRandomElement());
        }

    }
}
