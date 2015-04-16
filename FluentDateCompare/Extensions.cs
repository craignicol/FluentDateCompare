using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentDateCompare
{
    public static class Extensions
    {
        public static FluentDateCompare Is(this DateTime inputDate)
        {
            return new FluentDateCompare(inputDate);
        }
    }
}
