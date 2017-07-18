using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utils
{

    public class Timer
    {
        public int minutes;
        public float seconds;

        public Timer(float seconds)
        {
            this.minutes = NumberUtility.getMinutes(seconds);
            this.seconds = seconds - (60 * minutes);
        }

        public override string ToString()
        {
            return "" + minutes + ":" + seconds.ToString("00.00");
        }
    }

    public static class NumberUtility
    {
        public static int getMinutes(int seconds)
        {
            return seconds / 60;
        }

        public static int getMinutes(float seconds)
        {
            return (int) seconds / 60;
        }

        public static Timer GetTimerFromSeconds(float seconds)
        {
            return new Timer(seconds);
        }
    }
}
