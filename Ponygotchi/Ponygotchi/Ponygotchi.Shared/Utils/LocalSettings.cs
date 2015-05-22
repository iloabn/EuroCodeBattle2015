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
