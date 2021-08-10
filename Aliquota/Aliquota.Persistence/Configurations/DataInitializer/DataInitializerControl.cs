using System.Collections.Generic;

namespace Aliquota.Persistence.Configurations.DataInitializer
{
    public class DataInitializerControl
    {
        public static bool SkipSeedingData { get; set; }
    }

    public abstract class DataInitializer<T> : DataInitializerControl where T : class
    {
        public IEnumerable<T> Data => SkipSeedingData ? new List<T>() : GetData();

        protected abstract IEnumerable<T> GetData();
    }
}