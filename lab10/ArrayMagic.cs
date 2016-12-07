using System;

namespace lab10a
{
	public static class ArrayMagic
	{
	    /* Tu powstaną metody: ForEach, TransformArray, GenerateArray */
        public static void ForEach<T>(T[] array, Action<T> func) {
            foreach (var element in array)
                func(element);
        }

        public static T[] GenerateArray<T>(Func<T> generateFunc, int k)
        {
            T[] array = new T[k];
            for (int i = 0; i < k; i++)
                array[i] = generateFunc();
            return array;
        }

        public static T[] TransformArray<T>(T[] array, Func<T, T> transformFunc)
        {
            T[] transformedArray = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                transformedArray[i] = transformFunc(array[i]);
            return transformedArray;
        }
	}
}

