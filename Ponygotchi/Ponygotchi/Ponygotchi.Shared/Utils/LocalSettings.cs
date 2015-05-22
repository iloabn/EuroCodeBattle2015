using System.Collections.Generic;
using Windows.Storage;

namespace Ponygotchi.Utils
{
    public static class LocalSettings
    {
        static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Gets the container with the name specified
        /// </summary>
        /// <param name="containerName">The name of the container to get</param>
        /// <returns>The container or KeyNotFoundException if no such container was found</returns>
        public static ApplicationDataContainer GetContainer(string containerName)
        {
            var hasContainer = localSettings.Containers.ContainsKey(containerName);

            if (hasContainer)
            {
                return localSettings.Containers[containerName];
            }
            else
                throw new KeyNotFoundException(string.Format("No container with name \"{0}\" found", containerName));
        }

        /// <summary>
        /// Updates the specified container with the new value on the key specified
        /// Will overwrite old data
        /// </summary>
        /// <param name="containerName">The name of the container</param>
        /// <param name="key">The name of the thing that should be replaces/created</param>
        /// <param name="value">The actual value/thing that should be saved</param>
        /// <returns></returns>
        public static bool UpdateContainer(string containerName, string key, object value)
        {
            try
            {
                var container = GetContainer(containerName);

                container.Values[key] = value;
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public static void CreateContainer(string containerName)
        {
            localSettings.CreateContainer(containerName, ApplicationDataCreateDisposition.Always);
        }

        /// <summary>
        /// Get the setting stored with the specified name
        /// </summary>
        /// <typeparam name="T">The type that the setting is stored as</typeparam>
        /// <param name="settingName">The setting to get</param>
        /// <returns>The saved setting or a KeyNotFoundException if it wasn't there</returns>
        public static T GetSetting<T>(string settingName)
        {
            if (localSettings.Values.ContainsKey(settingName))
                return (T)localSettings.Values[settingName];
            else
                throw new KeyNotFoundException(string.Format("No setting with key \"{0}\" found!", settingName));
        }
    }
}
