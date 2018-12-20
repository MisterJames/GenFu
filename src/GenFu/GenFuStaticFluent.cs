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
            return GenFuInstance.Configure();
        }

        /// <summary>
        /// Reset and configure how the specified type is populated by GenFu
        /// NOTE: Overwrites all previous configuration
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> Configure<T>() where T : new()
        {
            return GenFuInstance.Configure<T>();
        }

        public static GenFuConfigurator Set()
        {
            return GenFuInstance.Set();
        }

        /// <summary>
        /// Configure how the specified type is populated by GenFu.
        /// NOTE: Maintains previous configuration for the specified type.
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> Set<T>() where T : new()
        {
            return GenFuInstance.Set<T>();
        }

        /// <summary>
        /// Set global defaults for GenFu
        /// </summary>
        /// <returns>The GenFu Defaulturator</returns>
        public static GenFuDefaulturator Default()
        {
            //TODO: MARCO RESTAURAR ESTO  ???
            return GenFuInstance.Default();
            //return new GenFuDefaulturator(_genfu, _fillerManager);
        }

        public static void Reset()
        {
            GenFuInstance.Reset();
        }

        public static void Reset<T>()
        {
            GenFuInstance.Reset<T>();
        }

        public void ListCount(int count)
        {
            GenFuInstance.ListCount(count);
        }
    }
}