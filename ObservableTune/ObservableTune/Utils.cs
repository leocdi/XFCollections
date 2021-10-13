using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ObservableTune
{
    public static class Utils
    {
        public static Chronometre CreateCronometer()
        {
            return new Chronometre();
        }
    }

    public class Chronometre
    {
        public Chronometre()
        {
            _sw = new Stopwatch();
            _sw.Start();
        }
        private Stopwatch _sw;

        public string TimeToString()
        {
            return _sw.ElapsedMilliseconds.ToString();
        }
    }
}
