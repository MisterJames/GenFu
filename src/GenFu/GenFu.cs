namespace GenFu;

using Angela.vNext.Reflection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class A : GenFu { }

public class Eh : GenFu { }

public partial class GenFu
{
    private static GenFu _genfu = new GenFu();
    private static FillerManager _fillerManager = new FillerManager();

    private static int _listCount = GenFu.Defaults.LIST_COUNT;

    static GenFu()
    {
        _fillerManager = new FillerManager();
        Random = new Random();
    }

    public static T New<T>() where T : new()
    {
        return (T)New(typeof(T));
    }

    public static object New(Type type)
    {
        object instance = Activator.CreateInstance(type);
        return New(instance);
    }

    public static T New<T>(T instance)
    {
        return (T)New((object)instance);

    }

    public static object New(object instance)
    {
        if (instance != null)
        {
            var type = instance.GetType();
            if (type.FullName == "System.Guid")
            {
                instance = Guid.NewGuid();
            }

            TypeInfo typeInfo = type.GetTypeInfo();
            foreach (var property in typeInfo.GetAllProperties())
            {
                if (!DefaultValueChecker.HasValue(instance, property) && property.CanWrite)
                {
                    SetPropertyValue(instance, property);
                }
            }
            foreach (var method in typeInfo.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => !x.IsSpecialName && x.GetBaseDefinition().DeclaringType != typeof(object)))
            {
                if (method.GetParameters().Count() == 1)
                {
                    CallSetterMethod(instance, method);
                }
            }
        }
        return instance;
    }


    public static List<T> ListOf<T>() where T : new()
    {
        return ListOf(typeof(T)).Cast<T>().ToList();
    }

    public static List<object> ListOf(Type type)
    {
        return BuildList(type, _listCount);
    }
    /// <summary>
    /// Creates a new list of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemCount">Number of items to add</param>
    /// <returns></returns>
    public static List<T> ListOf<T>(int itemCount) where T : new()
    {
        return ListOf(typeof(T), itemCount).Cast<T>().ToList();
    }

    public static List<object> ListOf(Type type, int itemCount)
    {
        return BuildList(type, itemCount);
    }

    private static List<object> BuildList(Type type, int itemCount)
    {
        var result = new List<object>();

        for (int i = 0; i < itemCount; i++)
        {
            result.Add(GenFu.New(type));
        }

        return result;
    }

    public static IEnumerable<T> LazyOf<T>() where T : new()
    {
        return LazyOf(typeof(T)).Cast<T>();
    }

    public static IEnumerable<object> LazyOf(Type type)
    {
        return BuildLazy(type, _listCount);
    }

    /// <summary>
    /// Creates a new lazy collection of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemCount">Number of items to add</param>
    /// <returns></returns>
    public static IEnumerable<T> LazyOf<T>(int itemCount) where T : new()
    {
        return LazyOf(typeof(T), itemCount).Cast<T>();
    }

    private static IEnumerable<object> LazyOf(Type type, int itemCount)
    {
        return BuildLazy(type, itemCount);
    }


    private static IEnumerable<object> BuildLazy(Type type, int itemCount)
    {
        for (int i = 0; i < itemCount; i++)
        {
            yield return GenFu.New(type);
        }
    }

    public static IEnumerable<T> ForeverOf<T>() where T : new()
    {
        return ForeverOf(typeof(T)).Cast<T>();
    }

    private static IEnumerable<object> ForeverOf(Type type)
    {
        return BuildForever(type);
    }

    private static IEnumerable<object> BuildForever(Type type)
    {
        while (true)
        {
            yield return GenFu.New(type);
        }
    }

    private static void SetPropertyValue(object instance, PropertyInfo property)
    {
        IPropertyFiller filler = _fillerManager.GetFiller(property);
        property.SetValue(instance, filler.GetValue(instance), null);
    }

    private static void CallSetterMethod(object instance, MethodInfo method)
    {
        IPropertyFiller filler = _fillerManager.GetMethodFiller(method);
        if (filler != null)
            method.Invoke(instance, new[] { filler.GetValue(instance) });
    }



    public static DateTime MinDateTime
    {
        get { return new GenericFillerDefaults(_fillerManager).GetMinDateTime(); }

        set
        {
            new GenericFillerDefaults(_fillerManager).SetMinDateTime(value);
        }
    }

    public static DateTime MaxDateTime
    {
        get { return new GenericFillerDefaults(_fillerManager).GetMaxDateTime(); }
        set
        {
            new GenericFillerDefaults(_fillerManager).SetMaxDateTime(value);
        }
    }

    public static Random Random { get; private set; }

    public class Defaults
    {
        public const int MIN_INT = 1;
        public const int MAX_INT = 100;

        public const uint MIN_UINT = 1;
        public const uint MAX_UINT = 100;

        public static double MIN_DOUBLE = 1;
        public static double MAX_DOUBLE = 10000;


        public static short MIN_SHORT = 1;
        public static short MAX_SHORT = Int16.MaxValue;

        public static ushort MIN_USHORT = 100;
        public static ushort MAX_USHORT = UInt16.MaxValue;


        public const decimal MIN_DECIMAL = 0;
        public const decimal MAX_DECIMAL = 100;

        public const int LIST_COUNT = 25;

        public static DateTime MIN_DATETIME = DateTime.Now.AddYears(-30);
        public static DateTime MAX_DATETIME = DateTime.Now.AddYears(30);

        public static double SEED_PERCENTAGE = 0.2;

        public const string FILE_DOMAIN_NAMES = "DomainNames";
        public const string FILE_FIRST_NAMES = "FirstNames";
        public const string FILE_LAST_NAMES = "LastNames";
        public const string FILE_PERSON_TITLES = "PersonTitles";
        public const string FILE_TITLES = "Titles";
        public const string FILE_WORDS = "Words";
        public const string FILE_STREET_NAMES = "StreetNames";
        public const string FILE_CITY_NAMES = "CityNames";
        public const string FILE_USA_STATE_NAMES = "USAStateNames";
        public const string FILE_USA_STATE_ABREVIATIONS = "USAStateAbbreviations";
        public const string FILE_CDN_PROVINCE_NAMES = "CanadianProvinceNames";
        public const string FILE_CDN_PROVINCE_ABREVIATIONS = "CanadianProvinceAbbreviations";
        public const string FILE_MUSIC_ARTIST = "MusicArtists";
        public const string FILE_MUSIC_ALBUM = "MusicAlbums";
        public const string FILE_INGREDIENTS = "Ingredients";
        public const string FILE_COMPANY_NAMES = "CompanyNames";
        public const string FILE_INDUSTRIES = "Industries";
        public const string FILE_INJURIES = "Injuries";
        public const string FILE_GENDERS = "Genders";
        public const string FILE_DRUGS = "Drugs";
        public const string FILE_LOREM = "Lorem";

        public const string STRING_LOADFAIL = "The resource list for {0} failed to load.";
    }


}



