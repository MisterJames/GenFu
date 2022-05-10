namespace GenFu;

using global::GenFu.ValueGenerators.Geospatial;
using global::GenFu.ValueGenerators.People;

public class StringFiller : PropertyFiller<string>
{
    public StringFiller()
         : base(typeof(object), "*", true)
    {
    }

    public override object GetValue(object instance)
    {
        return BaseValueGenerator.Word();
    }
}
public class ArticleTitleFiller : PropertyFiller<string>
{
    public ArticleTitleFiller()
        : base(new[] { "object" }, new[] { "title" })
    {
    }

    public override object GetValue(object instance)
    {
        return Names.Title();
    }
}

public class FirstNameFiller : PropertyFiller<string>
{
    public FirstNameFiller()
        : base(new[] { "object" }, new[] { "firstname", "fname", "first_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return Names.FirstName();
    }
}

public class PersonTitleFiller : PropertyFiller<string>
{
    public PersonTitleFiller()
        : base(new[] { "person", "employee", "user" }, new[] { "title" })
    {
    }

    public override object GetValue(object instance)
    {
        return Names.PersonTitle();
    }
}

public class LastNameFiller : PropertyFiller<string>
{
    public LastNameFiller()
        : base(new[] { "object" }, new[] { "lastname", "lname", "last_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return Names.LastName();
    }
}

public class EmailFiller : PropertyFiller<string>
{
    public EmailFiller()
        : base(new[] { "object" }, new[] { "email", "emailaddress", "email_address" })
    {
    }

    public override object GetValue(object instance)
    {
        return ContactInformation.Email();
    }
}

public class TwitterFiller : PropertyFiller<string>
{
    public TwitterFiller()
        : base(new[] { "object" }, new[] { "twitter", "twitterhandle", "twitter_handle", "twittername" })
    {
    }

    public override object GetValue(object instance)
    {
        return ContactInformation.Twitter();
    }
}

public class AddressFiller : PropertyFiller<string>
{
    public AddressFiller()
        : base(new[] { "object" }, new[] { "address", "address1", "address_1", "billingaddress", "billing_address" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.AddressLine();
    }
}

public class AddressLine2Filler : PropertyFiller<string>
{
    public AddressLine2Filler()
        : base(new[] { "object" }, new[] { "address2", "address_2" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.AddressLine2();
    }
}

public class CityFiller : PropertyFiller<string>
{
    public CityFiller()
        : base(new[] { "object" }, new[] { "city", "cityname", "city_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.City();
    }
}

public class StateFiller : PropertyFiller<string>
{
    public StateFiller()
        : base(new[] { "object" }, new[] { "state", "statename", "state_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.UsaState();
    }
}

public class StateAbbreviationFiller : PropertyFiller<string>
{
    public StateAbbreviationFiller()
        : base(new[] { "object" }, new[] { "stateAbbreviation" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.UsaStateAbbreviation();
    }
}


public class ProvinceFiller : PropertyFiller<string>
{
    public ProvinceFiller()
        : base(new[] { "object" }, new[] { "province", "provincename", "province_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.CanadianProvince();
    }
}

public class ZipCodeFiller : PropertyFiller<string>
{
    public ZipCodeFiller()
        : base(new[] { "object" }, new[] { "zip", "zipcode", "zip_code" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.ZipCode();
    }
}

public class PostalCodeFiller : PropertyFiller<string>
{
    public PostalCodeFiller()
        : base(new[] { "object" }, new[] { "postalcode", "postal_code" })
    {
    }

    public override object GetValue(object instance)
    {
        return Address.PostalCode();
    }
}

public class PhoneNumberFiller : PropertyFiller<string>
{
    public PhoneNumberFiller()
        : base(new[] { "object" }, new[] { "fax", "phone", "phonenumber", "phone_number", "homenumber", "worknumber" })
    {
    }

    public override object GetValue(object instance)
    {
        return ContactInformation.PhoneNumber();
    }
}

public class MusicAlbumTitleFiller : PropertyFiller<string>
{
    public MusicAlbumTitleFiller()
        : base(new[] { "album", "musicalbum", "music_album" }, new[] { "title", "albumname", "name" })
    {
    }

    public override object GetValue(object instance)
    {
        return ValueGenerators.Music.Album.Title();
    }
}

public class MusicArtistNameFiller : PropertyFiller<string>
{
    public MusicArtistNameFiller()
        : base(new[] { "artist" }, new[] { "name", "artistname", "artist_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return ValueGenerators.Music.Artist.Name();
    }
}

public class MusicGenreNameFiller : PropertyFiller<string>
{
    public MusicGenreNameFiller()
        : base(new[] { "genre", "musicgenre", "music_genre" }, new[] { "title", "name", "genre_title", "genre_name" })
    {
    }

    public override object GetValue(object instance)
    {
        return ValueGenerators.Music.Genre.Name();
    }
}

public class MusicGenreDescriptionFiller : PropertyFiller<string>
{
    public MusicGenreDescriptionFiller()
        : base(new[] { "genre", "musicgenre", "music_genre" }, new[] { "description", "desc", "genre_description", "genre_desc" })
    {
    }

    public override object GetValue(object instance)
    {
        return ValueGenerators.Music.Genre.Description();
    }
}
