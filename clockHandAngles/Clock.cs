using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockHandApp
{
    class Clock
    {
        public void getAllAnglesApart(ref decimal hourMinutesAngle, ref decimal minutesSecondsAngle, ref decimal hourSecondsAngle, string time)
        {
            int[] hoursMinutesSeconds = parseTimeString(time);
            hourMinutesAngle = getDegreesApartHourMinuteHands(hoursMinutesSeconds);
            minutesSecondsAngle = getDegreesApartMinutesSecondsHands(hoursMinutesSeconds);
            hourSecondsAngle = getDegreesApartHourSecondsHands(hoursMinutesSeconds);
        }

        public void getAllHandAngles(ref decimal hourHandAngle, ref decimal minutesHandAngle, ref decimal secondsHandAngle, string time) 
        {
            int[] hoursMinutesSeconds = parseTimeString(time);
            hourHandAngle = getHourHandDegrees(hoursMinutesSeconds);
            minutesHandAngle = getMinuteHandDegrees(hoursMinutesSeconds);
            secondsHandAngle = getSecondsHandDegrees(hoursMinutesSeconds);
        }

        private decimal getDegreesApartHourMinuteHands(int[] hoursMinutesSeconds)
        {
            decimal degreesApartHourMinuteHands = getSmallestPositiveAngle(getMinuteHandDegrees(hoursMinutesSeconds)
                - getHourHandDegrees(hoursMinutesSeconds));
            return degreesApartHourMinuteHands;
        }

        private decimal getDegreesApartMinutesSecondsHands(int[] hoursMinutesSeconds) 
        {
            decimal degreesApartMinuteSecondsHands = getSmallestPositiveAngle(getMinuteHandDegrees(hoursMinutesSeconds) 
                - getSecondsHandDegrees(hoursMinutesSeconds));
            return degreesApartMinuteSecondsHands;
        }

        private decimal getDegreesApartHourSecondsHands(int[] hoursMinutesSeconds) 
        {
            decimal degreesApartHourSecondsHands = getSmallestPositiveAngle(getSecondsHandDegrees(hoursMinutesSeconds)
                - getHourHandDegrees(hoursMinutesSeconds));
            return degreesApartHourSecondsHands;
        }

        private int[] parseTimeString(string time)
        {
            string[] timeVals = time.Split(':');
            int hours = int.Parse(timeVals[0]);
            int minutes = int.Parse(timeVals[1]);
            int seconds = int.Parse(timeVals[2]);
            int[] hoursMinutesSeconds = { hours, minutes, seconds };
            return hoursMinutesSeconds;
        }

        private decimal getHourHandDegrees(int[] hoursMinutesSeconds)
        {
            decimal hourHandDegreesPerHour = (360m / 12m);
            decimal hourHandDegreesPerMinute = (30m / 60m);
            decimal hourHandDegreesPerSecond = (360m / 43200m);
            decimal hourHandDegrees = ((decimal)hoursMinutesSeconds[0] * hourHandDegreesPerHour) 
                + ((decimal)hoursMinutesSeconds[1] * hourHandDegreesPerMinute)
                + ((decimal)hoursMinutesSeconds[2] * hourHandDegreesPerSecond);
            return getSmallestPositiveAngle(hourHandDegrees);
        }

        private decimal getMinuteHandDegrees(int[] hoursMinutesSeconds) 
        {
            decimal minuteHandDegreesPerMinute = (360m / 60m);
            decimal minuteHandDegressPerSecond = (360m / 3600m);
            decimal minuteHandDegrees = ((decimal)hoursMinutesSeconds[1] * minuteHandDegreesPerMinute) 
                + ((decimal)hoursMinutesSeconds[2] * minuteHandDegressPerSecond);
            return getSmallestPositiveAngle(minuteHandDegrees);
        }

        private decimal getSecondsHandDegrees(int[] hoursMinutesSeconds) 
        {             
            decimal secondsHandDegreesPerSecond = (360m / 60m);
            decimal secondsHandDegrees = ((decimal)hoursMinutesSeconds[2] * secondsHandDegreesPerSecond);
            return getSmallestPositiveAngle(secondsHandDegrees);
        }

        private decimal getSmallestPositiveAngle(decimal number)
        {
            if (isNegative(number))
            {
                number = (number * -1);
            }
            if (isGreaterThan360(number))
            {
                number = (number - 360);
            }
            if (isGreaterThan180(number))
            {
                number = (360 - number);
            }
            return number;
        }
        private bool isNegative(decimal number)
        {
            if ((number * 2) < number) { return true; }
            return false;
        }
        private bool isGreaterThan360(decimal number)
        {
            if (number > 360) { return true; }
            return false;
        }
        private bool isGreaterThan180(decimal number)
        {
            if (number > 180) { return true; }
            return false;
        }
    }
}
