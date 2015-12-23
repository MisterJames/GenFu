using System;

namespace GenFu
{
    //TODO: Consider merging this partial class.  Not much here anymore
    public partial class GenFu
    {
        /// <summary>
        /// Resets GenFu to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public static GenFuConfigurator Configure()
        {
            Reset();
            return new GenFuConfigurator(_genfu, _fillerManager);
        }

        /// <summary>
        /// Reset and configure how the specified type is populated by GenFu
        /// NOTE: Overwrites all previous configuration
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> Configure<T>() where T : new()
        {
            Reset<T>();
            return new GenFuConfigurator<T>(_genfu, _fillerManager);
        }

        public static GenFuConfigurator Set()
        {
            return new GenFuConfigurator(_genfu, _fillerManager);
        }

        /// <summary>
        /// Configure how the specified type is populated by GenFu.
        /// NOTE: Maintains previous configuration for the specified type.
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> Set<T>() where T : new()
        {
            return new GenFuConfigurator<T>(_genfu, _fillerManager);
        }

        /// <summary>
        /// Set global defaults for GenFu
        /// </summary>
        /// <returns>The GenFu Defaulturator</returns>
        public static GenFuDefaulturator Default()
        {
            return new GenFuDefaulturator(_genfu, _fillerManager);
        }

        public static void Reset()
        {
            _fillerManager.ResetFillers();
            var defaults = new GenericFillerDefaults(_fillerManager);

            defaults.SetMinInt(GenFu.Defaults.MIN_INT);
            defaults.SetMaxInt(GenFu.Defaults.MAX_INT);

            defaults.SetMinShort(GenFu.Defaults.MIN_SHORT);
            defaults.SetMaxShort(GenFu.Defaults.MAX_SHORT);

            defaults.SetMinDecimal(GenFu.Defaults.MIN_DECIMAL);
            defaults.SetMaxDecimal(GenFu.Defaults.MAX_DECIMAL);

            _listCount = GenFu.Defaults.LIST_COUNT;

            defaults.SetMinDateTime(GenFu.Defaults.MIN_DATETIME);
            defaults.SetMaxDateTime(GenFu.Defaults.MAX_DATETIME);

            defaults.SetMinSeed(GenFu.Defaults.MIN_SEED);
            defaults.SetMaxSeed(GenFu.Defaults.MAX_SEED);

            ResourceLoader.PropertyFillers.Clear();
        }

        public static void Reset<T>()
        {
            _fillerManager.ResetFillers<T>();

        }

        public void ListCount(int count)
        {
            _listCount = count;
        }
    }
}