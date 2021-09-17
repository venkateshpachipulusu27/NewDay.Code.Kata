using System.ComponentModel;

namespace NewDay.Code.Kata.Core.Enums
{
    public enum TennisGamePoint
    {
        [Description("Love")]
        Love = 0,
        [Description("15")]
        Fifteen = 1,
        [Description("30")]
        Thirty = 2,
        [Description("40")]
        Forty = 3,
        [Description("Advance")]
        Advance = 4,
    }
}
