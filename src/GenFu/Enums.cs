using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu
{

    public enum Properties
    {
        FirstNames,
        LastNames,
        PersonTitles,
        Words,
        Titles,
        Domains,
        StreetNames,
        CityNames,
        CanadianProvinces,
        CanadianProvinceAbreviations,
        UsaStates,
        UsaStateAbreviations,
        Countries,
        MusicArtists,
        MusicGenre,
        MusicAlbums,
        Ingredients,
        CompanyNames,
        Industries,
        JobTitles,
        Universities,
        Drugs,
        MedicalProcedures,
        Injuries,
        Genders,
        Lorem,
        CurrencyNames,
        CurrencyCodes
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
