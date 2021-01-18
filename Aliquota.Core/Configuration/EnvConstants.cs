using System;
using System.Reflection;

namespace MVPlayer.Core.Domain.Constants
{
    public static class EnvConstants
    {

        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
        public static string GetEnvironmentVariable(string name, string defaultValue, bool errorIfEmpty = false)
        {
            string value = GetEnvironmentVariable(name);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (errorIfEmpty)
                {
                    throw new Exception($"Environment variable {name} must contain value.");
                }
                return defaultValue;
            }

            return value;
        }

        public static string GetRequiredEnvironmentVariable(string name)
        {
            return GetEnvironmentVariable(name, null, true);
        }

        public static readonly string PROJECT_NAME = Assembly.GetEntryAssembly().GetName().Name;
        public static readonly string ENVIRONMENT_NAME = GetRequiredEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public static readonly string DATABASE_CONNECTION_STRING = GetRequiredEnvironmentVariable("DATABASE_CONNECTION_STRING");
    }
}
