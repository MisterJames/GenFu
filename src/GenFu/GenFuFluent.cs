using System;

namespace GenFu
{
    //TODO: Consider merging this partial class.  Not much here anymore
    public partial class GenFuInstance
    {
        /// <summary>
        /// Resets GenFu to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public GenFuConfigurator Configure()
        {
            Reset();
            return new GenFuConfigurator(this, _fillerManager);
        }

        /// <summary>
        /// Reset and configure how the specified type is populated by GenFu
        /// NOTE: Overwrites all previous configuration
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public GenFuConfigurator<T> Configure<T>() where T : new()
        {
            //see reference test: When_running_in_parallel.registrations_are_configurable
            //Reset<T>(); remove the reset to make this operation atomic, GenFuConfigurator will replace the current registration, we don't need to remove it explicitly
            return new GenFuConfigurator<T>(this, _fillerManager);
        }

        public GenFuConfigurator Set()
        {
            return new GenFuConfigurator(this, _fillerManager);
        }

        /// <summary>
        /// Configure how the specified type is populated by GenFu.
        /// NOTE: Maintains previous configuration for the specified type.
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public GenFuConfigurator<T> Set<T>() where T : new()
        {
            return new GenFuConfigurator<T>(this, _fillerManager);
        }

        /// <summary>
        /// Set global defaults for GenFu
        /// </summary>
        /// <returns>The GenFu Defaulturator</returns>
        public GenFuDefaulturator Default()
        {
            return new GenFuDefaulturator(this, _fillerManager);
        }

        public void Reset()
        {
            _fillerManager.ResetFillers();
            var defaults = new GenericFillerDefaults(_fillerManager);

            defaults.SetMinInt(GenFu.Defaults.MIN_INT);
            defaults.SetMaxInt(GenFu.Defaults.MAX_INT);

            defaults.SetMinShort(this.Defaults.MIN_SHORT);
            defaults.SetMaxShort(this.Defaults.MAX_SHORT);

            defaults.SetMinDecimal(GenFu.Defaults.MIN_DECIMAL);
            defaults.SetMaxDecimal(GenFu.Defaults.MAX_DECIMAL);

            _listCount = GenFu.Defaults.LIST_COUNT;

            defaults.SetMinDateTime(this.Defaults.MIN_DATETIME);
            defaults.SetMaxDateTime(this.Defaults.MAX_DATETIME);

            defaults.SetSeedPercentage(this.Defaults.SEED_PERCENTAGE);

            ResourceLoader.PropertyFillers.Clear();
        }

        public void Reset<T>()
        {
            _fillerManager.ResetFillers<T>();

        }

        public void ListCount(int count)
        {
            _listCount = count;
        }
    }
}