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
        public const string Name = "Pony";
    }

    public static class PonyNameEnum
    {
        public const string Fluttershy = "Fluttershy";
        public const string TwilightSparkle = "Twilight Sparkle";
        public const string RainbowDash = "Rainbow Dash";
    }

    public static class PonyMoodLevels
    {
        public const int Happy = 0;
        public const int Neutral = 40;
        public const int Sad = 70;
    }

    public enum MoodEnum
    {
        Happy,
        Neutral,
        Sad
    }
}
