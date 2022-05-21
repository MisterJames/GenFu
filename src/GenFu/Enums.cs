﻿namespace GenFu;

using System;

public enum PropertyType
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
    CanadianProvinceAbbreviations,
    UsaStates,
    UsaStateAbbreviations,
    MusicArtists,
    MusicGenre,
    MusicAlbums,
    Ingredients,
    CompanyNames,
    Industries,
    Drugs,
    MedicalProcedures,
    Injuries,
    Genders,
    Lorem
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
