using System;
using System.ComponentModel.Composition;

namespace Angela.Core
{
    public class StringFiller : IPropertyFiller
    {
        public string[] PropertyNames { get { return new[] { "*" }; } }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return true; } }

        public object GetValue()
        {
            return Jen.Word();
        }
    }

    public class ArticleTitleFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "title"}; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Title();
        }
    }

    public class FirstNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "firstname", "fname", "first_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.FirstName();
        }
    }

    public class LastNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "lastname", "lname", "last_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.LastName();
        }
    }

    public class EmailFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "email", "emailaddress", "email_address" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Email();
        }
    }

    public class TwitterFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "twitter", "twitterhandle", "twitter_handle", "twittername" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Twitter();
        }
    }

    public class AddressFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "address", "adress1", "adress_1", "billingaddress", "billing_address" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] {"object"}; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.AddressLine();
        }
    }

    public class AddressLine2Filler : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "address2", "adress_2" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.AddressLine2();
        }
    }

    public class CityFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "city", "cityname", "city_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.City();
        }
    }

    public class StateFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "state", "statename", "state_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.UsaState();
        }
    }

    public class ProvinceFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "provice", "provincename", "province_name"}; }
        }
        
        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.CanadianProvince();
        }
    }

    public class PhoneNumberFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "fax", "phone", "phonenumber", "phone_number", "homenumber", "worknumber" }; }
        }
        
        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.PhoneNumber();
        }
    }

    public class MusicAlbumTitleFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "title", "albumname", "name"}; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "album", "musicalbum", "music_album" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Music.Album.Title();
        }
    }

    public class MusicArtistNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "name", "artistname", "artist_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "artist" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Music.Artist.Name();
        }
    }

    public class MusicGenreNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "title", "name", "genre_title", "genre_name" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "genre", "musicgenre", "music_genre" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Music.Genre.Name();
        }
    }

    public class MusicGenreDescriptionFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "description", "desc", "genre_description", "genre_desc" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "genre", "musicgenre", "music_genre" }; }
        }

        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Music.Genre.Description();
        }
    }

   

    public static class StringFillerExtensions
    {
        /// <summary>
        /// Populate the specified property with a valid email address
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsEmailAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Email());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a valid email address for a particular domain
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <param name="domain">The domain name for the email address</param>
        /// <returns>A configurator for the specified object type</returns>
   
        public static AngieConfigurator<T> AsEmailAddressForDomain<T>(this AngieStringConfigurator<T> configurator, string domain) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Email(domain));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a valid Twitter handle
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsTwitterHandle<T>(this AngieStringConfigurator<T> configurator) where T: new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Twitter());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with an article title (eg. Blog Post Title)
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsArticleTitle<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Title());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a valid phone number
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsPhoneNumber<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.PhoneNumber());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a first name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsFirstName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.FirstName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a last name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsLastName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.LastName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a street address
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.AddressLine());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with the second line of a street address
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsAddressLine2<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.AddressLine2());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a city name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsCity<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.City());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a Canadian province name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsCanadianProvince<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.CanadianProvince());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with an American state name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsUsaState<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.UsaState());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a music artist name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsMusicArtistName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Music.Artist.Name());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a music genre name
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsMusicGenreName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Music.Genre.Name());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a music genre description
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsMusicGenreDescription<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Music.Genre.Description());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }

}
