using System;

namespace Starfield
{
    public static class ExtansionsClass
    {
        public static double Map(this double value, double from1, double to1, double from2, double to2)
        {
            //value = 35
            //range = 40 - 20
            //offset = value - from1 = -5
            //range = 40 - 20 = 20
            //x% = 100 * offset / range = 25%

            var offset = Math.Abs(value - from1);
            var range1 = Math.Abs(to1 - from1);
            var percent1 = offset / range1;

            if (value < 0)
            {
                percent1 *= -1;
            }

            var range2 = Math.Abs(to2 - from2);

            //40 - 20
            //range = 20
            //

            var resultValue = range2 * percent1;

            if (to2 - from2 < 0)
            {
                resultValue = from2 - resultValue;
            }
            return resultValue;
        }
    }
}
