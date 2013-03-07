namespace Angela.Core
{
    public class StringFiller : PropertyFiller<string>
    {
        public StringFiller() : base(new[] { "object" }, new[] { "*" }, true)
        {
        }

        public override object GetValue()
        {
            return Jen.Word();
        }
    }

    public class ArticleTitleFiller : PropertyFiller<string>
    {
        public ArticleTitleFiller() : base(new[] { "object" }, new[] { "title" })
        {
        }

        public override  object GetValue()
        {
            return Jen.Title();
        }
    }

    public class FirstNameFiller : PropertyFiller<string>
    {
        public FirstNameFiller()
            : base(new[] { "object" }, new[] { "firstname", "fname", "first_name" })
        {
        }

        public override object GetValue()
        {
            return Jen.FirstName();
        }
    }

    public class LastNameFiller : PropertyFiller<string>
    {
        public LastNameFiller()
            : base(new[] { "object" }, new[] { "lastname", "lname", "last_name" })
        {
        }
        
        public override object GetValue()
        {
            return Jen.LastName();
        }
    }

    public class EmailFiller : PropertyFiller<string>
    {
        public EmailFiller()
            : base(new[] { "object" }, new[] { "email", "emailaddress", "email_address" })
        {
        }

        public override object GetValue()
        {
            return Jen.Email();
        }
    }

    public class TwitterFiller : PropertyFiller<string>
    {
        public TwitterFiller()
            : base(new[] { "object" }, new[] { "twitter", "twitterhandle", "twitter_handle", "twittername"})
        {
        }

        public override object GetValue()
        {
            return Jen.Twitter();
        }
    }

    public class AddressFiller : PropertyFiller<string>
    {
        public AddressFiller()
            : base(new[] { "object" }, new[] { "address", "adress1", "adress_1", "billingaddress", "billing_address" })
        {
        }

        public override object GetValue()
        {
            return Jen.AddressLine();
        }
    }

    public class AddressLine2Filler : PropertyFiller<string>
    {
        public AddressLine2Filler()
            : base(new[] { "object" }, new[] { "address2", "adress_2" })
        {
        }

        public override object GetValue()
        {
            return Jen.AddressLine2();
        }
    }

    public class CityFiller : PropertyFiller<string>
    {
        public CityFiller()
            : base(new[] { "object" }, new[] { "city", "cityname", "city_name" })
        {
        }

        public override object GetValue()
        {
            return Jen.City();
        }
    }

    public class StateFiller : PropertyFiller<string>
    {
        public StateFiller()
            : base(new[] { "object" }, new[] { "state", "statename", "state_name" })
        {
        }
        
        public override object GetValue()
        {
            return Jen.UsaState();
        }
    }

    public class ProvinceFiller : PropertyFiller<string>
    {
        public ProvinceFiller()
            : base(new[] { "object" }, new[] { "provice", "provincename", "province_name" })
        {
        }

        public override object GetValue()
        {
            return Jen.CanadianProvince();
        }
    }

    public class PhoneNumberFiller : PropertyFiller<string>
    {
        public PhoneNumberFiller()
            : base(new[] { "object" }, new[] { "fax", "phone", "phonenumber", "phone_number", "homenumber", "worknumber" })
        {
        }

        public override object GetValue()
        {
            return Jen.PhoneNumber();
        }
    }

    public class MusicAlbumTitleFiller : PropertyFiller<string>
    {
        public MusicAlbumTitleFiller()
            : base(new[] { "album", "musicalbum", "music_album" }, new[] { "title", "albumname", "name" })
        {
        }

        public override object GetValue()
        {
            return Jen.Music.Album.Title();
        }
    }

    public class MusicArtistNameFiller : PropertyFiller<string>
    {
        public MusicArtistNameFiller()
            : base(new[] { "artist" }, new[] { "name", "artistname", "artist_name" })
        {
        }

        public override object GetValue()
        {
            return Jen.Music.Artist.Name();
        }
    }

    public class MusicGenreNameFiller : PropertyFiller<string>
    {
        public MusicGenreNameFiller()
            : base(new[] {"genre", "musicgenre", "music_genre" }, new[] { "title", "name", "genre_title", "genre_name" })
        {
        }

        public override object GetValue()
        {
            return Jen.Music.Genre.Name();
        }
    }

    public class MusicGenreDescriptionFiller : PropertyFiller<string>
    {
        public MusicGenreDescriptionFiller()
            : base(new[] {"genre", "musicgenre", "music_genre" }, new[] { "description", "desc", "genre_description", "genre_desc" })
        {
        }

        public override object GetValue()
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
