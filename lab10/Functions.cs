using System;
using System.Collections.Generic;

namespace lab10a
{
	public static class Functions
	{
        public static Func<int> NaturalNumbers()
        {
            int number = 1;
            return () => number++;
        }

        public static Func<double, double> Multiply(double m)
        {
            return number => number * m;
        }
	}
}

