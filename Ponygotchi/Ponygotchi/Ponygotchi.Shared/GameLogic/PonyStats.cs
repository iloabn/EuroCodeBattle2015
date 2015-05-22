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


        public MoodEnum GetMood()
        {
            // Do stuff to calculate the mood of the pony

            // Default
            return MoodEnum.Happy;
        }

        public TimeSpan GetAge()
        {
            var now = DateTime.UtcNow;
            var creation = GetStats<DateTime>(PonyStatsEnum.Age);

            return now.Subtract(creation);
        }

        public void ResetPony()
        {

        }

        private T GetStats<T>(string chosenStat)
        {
            if (StatsContainer == null)
                StatsContainer = LocalSettings.GetContainer("PonyStats");

            if (StatsContainer.Values.ContainsKey(chosenStat))
                return (T)StatsContainer.Values[chosenStat];
            else
                throw new KeyNotFoundException(string.Format("Didn't find the stat {0}", chosenStat));
        }
    }
}
