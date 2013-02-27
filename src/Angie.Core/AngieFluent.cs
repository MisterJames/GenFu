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

        /// <summary>
        /// Reset and configure how the specified type is populated by Angie
        /// NOTE: Overwrites all previous configuration
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> Configure<T>() where T : new()
        {
            Reset();
            return new AngieConfigurator<T>(_angie, _maggie);
        }

        public static AngieConfigurator Set()
        {
            return new AngieConfigurator(_angie, _maggie);
        }

        /// <summary>
        /// Configure how the specified type is populated by Angie.
        /// NOTE: Maintains previous configuration for the specified type.
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> Set<T>() where T : new()
        {
            return new AngieConfigurator<T>(_angie, _maggie);
        }

        /// <summary>
        /// Set global defaults for Angie
        /// </summary>
        /// <returns>The Angie Defaulturator</returns>
        public static AngieDefaulturator Default()
        {
            return new AngieDefaulturator(_angie, _maggie);
        }

        public static void Reset()
        {
            _maggie.ResetFillers();
            
            _maggie.SetMinInt(Angie.Defaults.MIN_INT);
            _maggie.SetMaxInt(Angie.Defaults.MAX_INT);
            
            _maggie.SetMinDecimal(Angie.Defaults.MIN_DECIMAL);
            _maggie.SetMaxDecimal(Angie.Defaults.MAX_DECIMAL);

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