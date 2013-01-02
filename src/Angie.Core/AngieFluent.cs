using System;

namespace Angela.Core
{
    //TODO: Consider merging this partial class.  Not much here anymore
    public partial class Angie
    {
        /// <summary>
        /// Resets Angie to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public static AngieConfigurator Configure()
        {
            Reset();
            return new AngieConfigurator(_angie, _maggie);
        }

        public static AngieConfigurator<T> Configure<T>() where T : new()
        {
            Reset();
            return new AngieConfigurator<T>(_angie, _maggie);
        }

        public static AngieConfigurator Set()
        {
            return new AngieConfigurator(_angie, _maggie);
        }

        public static AngieConfigurator<T> Set<T>() where T : new()
        {
            return new AngieConfigurator<T>(_angie, _maggie);
        }

        public static void Reset()
        {
            _maggie.ResetFillers();
            _maggie.SetMinInt(Angie.Defaults.MIN_INT);
            _maggie.SetMaxInt(Angie.Defaults.MAX_INT);
            _listCount = Angie.Defaults.LIST_COUNT;

            _maggie.SetMinDateTime(DateTime.MinValue);
            _maggie.SetMaxDateTime(DateTime.MaxValue);

            Susan.PropertyFillers.Clear();
        }

        public void ListCount(int count)
        {
            _listCount = count;
        }
    }
}