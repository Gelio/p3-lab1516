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

        public static Func<T, T> Combine<T>(Func<T, T> f1, Func<T, T> f2)
        {
            return x => f1(f2(x));
        }

        public static Func<T, T> Add<T>(Func<T, T> f1, Func<T, T> f2)
        {
            return x => {
                dynamic y1 = f1(x);
                dynamic y2 = f2(x);
                return (T)(y1 + y2);
            };
        }
	}
}

