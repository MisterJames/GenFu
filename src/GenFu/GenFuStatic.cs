using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Angela.vNext.Reflection;

namespace GenFu
{
    public abstract class A : GenFu { }


    public abstract class Eh : GenFu { }

    public abstract partial class GenFu
    {
        private static GenFuInstance GenFuLocal;
        private static object locker = new object();
        public static GenFuInstance GenFuInstance
        {
            get
            {
                if (GenFuLocal == null)
                    lock (locker)
                    {
                        if (GenFuLocal == null)
                            GenFuLocal = new GenFuInstance();
                    }

                return GenFuLocal;
            }
        }

        public static GenFuInstance GetFiller()
        {
            return new GenFuInstance();
        }

        public static T New<T>() where T : new()
        {
            return GenFuInstance.New<T>();
        }

        public static object New(Type type)
        {
            return GenFuInstance.New(type);
        }

        public static T New<T>(T instance)
        {
            return GenFuInstance.New<T>(instance);
        }

        public static object New(object instance)
        {
            return GenFuInstance.New(instance);
        }


        public static List<T> ListOf<T>() where T : new()
        {
            return GenFuInstance.ListOf<T>();
        }

        public static List<object> ListOf(Type type)
        {
            return GenFuInstance.ListOf(type);
        }
        /// <summary>
        /// Creates a new list of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemCount">Number of items to add</param>
        /// <returns></returns>
        public static List<T> ListOf<T>(int itemCount) where T : new()
        {
            return GenFuInstance.ListOf<T>(itemCount);
        }

        public static List<object> ListOf(Type type, int itemCount)
        {
            return GenFuInstance.ListOf(type, itemCount);
        }


        public static DateTime MinDateTime
        {
            get { return GenFuInstance.MinDateTime; }

            set
            {
                GenFuInstance.MinDateTime = value;
            }
        }

        public static DateTime MaxDateTime
        {
            get { return GenFuInstance.MaxDateTime; }
            set
            {
                GenFuInstance.MinDateTime = value;
            }
        }

        public static DefaultValues Defaults { get => _defaults; }

        private static DefaultValues _defaults = new DefaultValues();

        public class DefaultValues
        {
            public int MIN_INT = 1;
            public int MAX_INT = 100;

            public uint MIN_UINT = 1;
            public uint MAX_UINT = 100;

            public double MIN_DOUBLE = 1;
            public double MAX_DOUBLE = 10000;


            public short MIN_SHORT = 1;
            public short MAX_SHORT = Int16.MaxValue;

            public ushort MIN_USHORT = 100;
            public ushort MAX_USHORT = UInt16.MaxValue;


            public decimal MIN_DECIMAL = 0;
            public decimal MAX_DECIMAL = 100;

            public int LIST_COUNT = 25;

            public DateTime MIN_DATETIME = DateTime.Now.AddYears(-30);
            public DateTime MAX_DATETIME = DateTime.Now.AddYears(30);

            public double SEED_PERCENTAGE = 0.2;

            public string FILE_DOMAIN_NAMES = "DomainNames";
            public string FILE_FIRST_NAMES = "FirstNames";
            public string FILE_LAST_NAMES = "LastNames";
            public string FILE_PERSON_TITLES = "PersonTitles";
            public string FILE_TITLES = "Titles";
            public string FILE_WORDS = "Words";
            public string FILE_STREET_NAMES = "StreetNames";
            public string FILE_CITY_NAMES = "CityNames";
            public string FILE_USA_STATE_NAMES = "USAStateNames";
            public string FILE_USA_STATE_ABREVIATIONS = "USAStateAbreviations";
            public string FILE_CDN_PROVINCE_NAMES = "CanadianProvinceNames";
            public string FILE_CDN_PROVINCE_ABREVIATIONS = "CanadianProvinceAbreviations";
            public string FILE_MUSIC_ARTIST = "MusicArtists";
            public string FILE_MUSIC_ALBUM = "MusicAlbums";
            public string FILE_INGREDIENTS = "Ingredients";
            public string FILE_COMPANY_NAMES = "CompanyNames";
            public string FILE_INDUSTRIES = "Industries";
            public string FILE_INJURIES = "Injuries";
            public string FILE_GENDERS = "Genders";
            public string FILE_DRUGS = "Drugs";
            public string FILE_LOREM = "Lorem";

            public string STRING_LOADFAIL = "The resource list for {0} failed to load.";
        }
    }
}
