using System;

namespace lab10a
{

	public static class MainClass
	{

        public static void PrintArray<T>(T[] array)
        {
            ArrayMagic.ForEach(array, x => System.Console.Out.Write(x + " "));
            System.Console.Out.WriteLine();
        }


        public static void Main (string[] args)
		{
			Random random = new Random(41234);

			int[] ar1 = {1,2,3,5,6,7};
			String[] ar2 = {"a","xyzzy","b","c"};
			double[] ar3 = {1.1,1.2,1.5,1.9,22};

            // etap1
            
			System.Console.Out.WriteLine("Etap1");
			PrintArray(ar1);
			PrintArray(ar2);

            
			// Drugim parametrem ma być delegacja która zwraca wartość swojego argumentu powiększoną o 2
			PrintArray(ArrayMagic.TransformArray(ar1, element => element+2));

			// Pierwszym argumentem ma być delegacja na metodę Next obiektu random
			PrintArray(ArrayMagic.GenerateArray(() => random.Next(), 5));

            //etap2
            
			System.Console.Out.WriteLine("Etap2");
			PrintArray(ArrayMagic.GenerateArray<int>(Functions.NaturalNumbers(), 5));
			PrintArray(ArrayMagic.GenerateArray(Functions.NaturalNumbers(), 5));
			var m3 = Functions.Multiply(3);
			var m5 = Functions.Multiply(5);
			PrintArray(ArrayMagic.TransformArray(ar3, m3));
			PrintArray(ArrayMagic.TransformArray(ar3, m5));
			

            //etap3
            
			System.Console.Out.WriteLine("Etap3");
			int sum=0;

			// Wyjaśnienie w treści zadania
			ArrayMagic.ForEach(ar1, number => sum += number);
			System.Console.Out.WriteLine("Suma: " + sum);
            // Suma liczb z ar1 to 24, a nie 12, jak podane w wyjscie.txt
			

            //etap4
            
			System.Console.Out.WriteLine("Etap4");
			PrintArray(ArrayMagic.TransformArray(ar3,Functions.Combine(m3,m5)));
			PrintArray(ArrayMagic.TransformArray(ar3,Functions.Add(m3,m5)));
			

            //etap5
            
			System.Console.Out.WriteLine("Etap5");
			var lb1 = Functions.LosowanieBezZwracania(0,15,random);
			var lb2 = Functions.LosowanieBezZwracania(0,15,random);

			int[] a8 = ArrayMagic.GenerateArray(lb1, 14);
			int[] a9 = ArrayMagic.GenerateArray(lb2, 14);
			PrintArray(a8);
			PrintArray(a9);

        }
    }
}
