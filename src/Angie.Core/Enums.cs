using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{

    public enum Properties
    {
        FirstNames,
        LastNames,
        Words,
        Titles,
        Domains,
        StreetNames,
        CityNames,
        CanadianProvinces,
        UsaStates,
        MusicArtists,
        MusicGenre,
        MusicAlbums
    }

    [Flags]
    public enum DateRules
    {
        FutureDates = 0,
        Within1Year = 1,
        Within10Years = 2,
        Within25years = 4,
        Within50Years = 8,
        Within100Years = 16,
        PastDate = 32
    }
}
