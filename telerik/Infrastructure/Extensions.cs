using System;

namespace telerik.Infrastructure
{
    public static class Extensions
    {
        public static DateTime NextDateTime(this Random r, string begin, string end)
        {
            var range = new[] { DateTime.Parse(begin), DateTime.Parse(end) };
            var ticks = r.NextLong(range[0].Ticks, range[1].Ticks);
            var date = new DateTime(ticks);
            return date;
        }

        public static T PickNext<T>(this Random r, params T[] choices)
        {
            return choices[r.Next(choices.Length)];
        }

        public static string NextPhone(this Random r)
        {
            return string.Format("({0}) {1}-{2}",
                                 r.Next(200, 1000),
                                 r.Next(100, 1000),
                                 r.Next(1000, 10000));
        }

        static long NextNonNegativeLong(this Random rg)
        {
            byte[] bytes = new byte[sizeof(long)];
            rg.NextBytes(bytes);
            // strip out the sign bit
            bytes[7] = (byte)(bytes[7] & 0x7f);
            return BitConverter.ToInt64(bytes, 0);
        }

        public static long NextLong(this Random rg, long maxValue)
        {
            return (long)((rg.NextNonNegativeLong() / (double)Int64.MaxValue) * maxValue);
        }

        public static long NextLong(this Random rg, long minValue, long maxValue)
        {
            if (minValue >= maxValue)
            {
                throw new InvalidOperationException();
            }
            long range = maxValue - minValue;
            return rg.NextLong(range) + minValue;
        }

        
    }
}