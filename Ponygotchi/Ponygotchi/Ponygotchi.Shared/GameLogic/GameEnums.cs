using System;
using System.Collections.Generic;
using System.Text;

namespace Ponygotchi.GameLogic
{
    public static class PonyStatsEnum
    {
        public const string Age = "CreationDateTime";
        public const string Hunger = "Hunger";
        public const string Boredom = "Boredom";

    }

    public enum MoodEnum
    {
        Happy,
        Neutral,
        Sad
    }
}
