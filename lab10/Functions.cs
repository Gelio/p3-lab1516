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
            return x =>
            {
                dynamic y1 = f1(x);
                dynamic y2 = f2(x);
                return (T)(y1 + y2);
            };
        }

        public static Func<int> LosowanieBezZwracania(int lower, int upper, Random random)
        {
            int numbersGenerated = 0,
                numbersToGenerate = upper - lower + 1;
            bool[] wasGenerated = new bool[numbersToGenerate];
            for (int i = 0; i < numbersToGenerate; i++)
                wasGenerated[i] = false;
            
            return () =>
            {
                if (numbersGenerated == numbersToGenerate)
                    throw new InvalidOperationException();

                int randomValue;
                do
                {
                    randomValue = lower + random.Next() % (upper - lower + 1);
                } while (wasGenerated[randomValue - lower]);

                wasGenerated[randomValue - lower] = true;
                numbersGenerated++;
                return randomValue;
            };
        }
	}
}

