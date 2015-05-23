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
        public const string TwilightSparkle = "TwilightSparkle";
        public const string RainbowDash = "RainbowDash";
    }

    public static class PonyMoodLevels
    {
        public const int Happy = 0;
        public const int Neutral = 40;
        public const int Sad = 70;
    }

    public static class MoodEnum
    {
        public const string Happy = "happy";
        public const string Neutral = "neutral";
        public const string Sad = "sad";
    }
}
