using System;
using System.Collections.Generic;
using System.Text;
using Ponygotchi.Utils;
using Windows.Storage;

namespace Ponygotchi.GameLogic
{
    /// <summary>
    /// A class used to get different statistics about the pony
    /// For example how old they are and how hungry and so forth
    /// </summary>
    public class PonyStats
    {
        static ApplicationDataContainer StatsContainer;


        public string GetMood()
        {
            int maximumMood = Math.Max(Math.Max(GetBoredom(), GetHunger()), GetTiredness());

            if (maximumMood > PonyMoodLevels.Neutral)
                if (maximumMood > PonyMoodLevels.Sad)
                    return MoodEnum.Sad;
                else
                    return MoodEnum.Neutral;
            else
                return MoodEnum.Happy;
        }

        /// <summary>
        /// Gets the age of the pony
        /// </summary>
        /// <returns>A TimeSpan representing the age of the pony</returns>
        public TimeSpan GetAge()
        {
            var now = DateTime.UtcNow;
            var creation = GetStats(PonyStatsEnum.Age);

            return now.Subtract(creation);
        }

        internal void Eat()
        {
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Hunger, DateTime.UtcNow.ToString());
        }

        internal void Play()
        {
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Boredom, DateTime.UtcNow.ToString());
        }

        internal void Sleep()
        {
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Sleep, DateTime.UtcNow.ToString());
        }




        /// <summary>
        /// Gets the hunger level for the pony
        /// </summary>
        /// <returns>An int from 0 to 100 (0 is not hungry, 100 is dead hungry)</returns>
        public int GetHunger()
        {
            var lastFeed = GetStats(PonyStatsEnum.Hunger);

            var hunger = CalculateThing(lastFeed);
            if (hunger > 100)
                throw new DeadPonyException();
            else
                return (int)hunger;
        }

        /// <summary>
        /// Gets the boredom level
        /// </summary>
        /// <returns>Between 0 and 100 (0 is not bored, 100 is bored to death)</returns>
        public int GetBoredom()
        {
            var lastPlayed = GetStats(PonyStatsEnum.Boredom);

            var boredom = CalculateThing(lastPlayed);

            if (boredom > 100)
                throw new DeadPonyException();
            else
                return (int)boredom;
        }

        public int GetTiredness()
        {
            var lastSlept = GetStats(PonyStatsEnum.Sleep);
            var sleepiness = CalculateThing(lastSlept);
            if (sleepiness > 100)
                throw new DeadPonyException();
            else
                return (int)sleepiness;
        }

        private int CalculateThing(DateTime thing)
        {
            var now = DateTime.UtcNow;
            var timeSincePlayed = now.Subtract(thing);
            return (int)(timeSincePlayed.TotalMinutes / 1 * 100);
        }

        /// <summary>
        /// Get if the pony has pooped since you last looked
        /// </summary>
        /// <returns>If the pony has pooped or not</returns>
        public bool HasPooped()
        {
            var now = DateTime.UtcNow;
            var lastFeed = GetStats(PonyStatsEnum.Boredom);

            var timeSinceFeed = now.Subtract(lastFeed);

            return timeSinceFeed.TotalMinutes > 45;
        }

        public static bool HasPony()
        {
            return LocalSettings.HasContainer(Constants.StatsSettingsName);
        }

        public void ResetPony(string newPonyName)
        {
            LocalSettings.CreateContainer(Constants.StatsSettingsName);
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Name, newPonyName);
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Age, DateTime.UtcNow.ToString());
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Hunger, DateTime.UtcNow.ToString());
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Boredom, DateTime.UtcNow.ToString());
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, PonyStatsEnum.Sleep, DateTime.UtcNow.ToString());
            LocalSettings.UpdateContainer(Constants.StatsSettingsName, "Id", Guid.NewGuid().ToString());
        }

        private DateTime GetStats(string chosenStat)
        {
            if (StatsContainer == null)
                StatsContainer = LocalSettings.GetContainer(Constants.StatsSettingsName);

            if (StatsContainer.Values.ContainsKey(chosenStat))
                return DateTime.Parse((string)StatsContainer.Values[chosenStat]);
            else
                throw new KeyNotFoundException(string.Format("Didn't find the stat {0}", chosenStat));
        }

        public string GetPonyName()
        {
            if (StatsContainer == null)
                StatsContainer = LocalSettings.GetContainer(Constants.StatsSettingsName);

            if (StatsContainer.Values.ContainsKey(PonyStatsEnum.Name))
                return (string)StatsContainer.Values[PonyStatsEnum.Name];
            else
                throw new KeyNotFoundException(string.Format("Didn't find the stat {0}", PonyStatsEnum.Name));
        }

        public string GetPonyId()
        {
            if (StatsContainer == null)
                StatsContainer = LocalSettings.GetContainer(Constants.StatsSettingsName);

            if (StatsContainer.Values.ContainsKey("Id"))
                return (string)StatsContainer.Values["Id"];
            else
                throw new KeyNotFoundException("Didn't find id of the pony");
        }
    }
}
