﻿namespace DataStore.Models.PureFunctions.Extensions
{
    using System;

    public static class Dates
    {
        public static DateTime ConvertFromMillisecondsEpochTime(this double src)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(src);
        }

        public static DateTime ConvertFromSecondsEpochTime(this double src)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(src);
        }

        public static double ConvertToMillisecondsEpochTime(this DateTime src)
        {
            return (src - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static double ConvertToSecondsEpochTime(this DateTime src)
        {
            return (src - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}