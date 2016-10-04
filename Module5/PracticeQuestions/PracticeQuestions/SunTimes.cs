using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class SunTimes
    {
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }

        public SunTimes(DateTime sunrise, DateTime sunset)
        {
            SunriseTime = sunrise;
            SunsetTime = sunset;
        }

        public double DaylightMinutes()
        {
            return SunsetTime.Subtract(SunriseTime).TotalMinutes;
        }
    }
}
