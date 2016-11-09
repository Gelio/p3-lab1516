using System;

namespace MatrixLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new ArrayMatrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix m2 = new ArrayMatrix(2, 3, new double[,] { { 5, 6, 10 }, { 7, 8, 100 } });

            Matrix m3 = new SparseMatrix(3, 2, new double[,] { { 0, -10 }, { 0, -12 }, { 0, 0 } });
            Matrix m4 = new SparseMatrix(2, 2, new double[,] { { 13, 14 }, { 15, 16 } });
            Matrix m5 = new SparseMatrix(2, 2, new double[,] { { 0, 0 }, { 0, 0 } });

            Console.WriteLine("===== ETAP 1 =====");

            TransposeTest(m1, "M1");
            TransposeTest(m2, "M2");
            TransposeTest(m3, "M3");
            TransposeTest(m4, "M4");
            TransposeTest(m5, "M5");

            Console.WriteLine("===== ETAP 2 =====");

            MaxTest(m1, "M1", 4, 1, 1);
            MaxTest(m2, "M2", 100, 1, 2);
            MaxTest(m3, "M3", 0, 0, 0);
            MaxTest(m4, "M4", 16, 1, 1);
            MaxTest(m5, "M5", 0, 0, 0);

            // W testach pojawiają się błędne wyniki, ale jak spojrzymy na definicję macierzy,
            // okazuje się, że testy nie mają sensu (np. M2 nie ma elementu -100, a w teście
            // taki występuje)
            MinTest(m1, "M1", 1, 0, 0);
            MinTest(m2, "M2", -100, 1, 2);
            MinTest(m3, "M3", 0, 0, 0);
            MinTest(m4, "M4", -14, 0, 1);
            MinTest(m5, "M5", 0, 0, 0);

            Console.WriteLine("===== ETAP 3 =====");

            Matrix m6 = new PartialArrayMatrix(3, 4, new int[] { 0, 0, 0, 0, 2, 2, 2, 2 }, new int[] { 0, 1, 2, 3, 0, 1, 2, 3 }, new double[] { 0, 1, 1, 1, 3, 3, 3, 4 });
            Matrix m7 = new PartialArrayMatrix(3, 3, new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 }, new double[] { -100, 0, 100 });
            Matrix m8 = new PartialArrayMatrix(3, 4, new int[] { 0, 0, 1, 1, 2, 2 }, new int[] { 0, 3, 0, 3, 0, 3 }, new double[] { 10, 11, 12, 4, 5, 6 });
            Matrix m9 = new PartialArrayMatrix(5, 4, new int[] { 3, 2, 1, 0, 1 }, new int[] { 0, 1, 2, 3, 1 }, new double[] { 10, 100, 1000, -100, -10 });

            MaxTest(m6, "M6", 4, 2, 3);
            MaxTest(m7, "M7", 100, 2, 2);
            MaxTest(m8, "M8", 12, 1, 0);
            MaxTest(m9, "M9", 1000, 1, 2);

            MinTest(m6, "M6", 0, 0, 0);
            MinTest(m7, "M7", -100, 0, 0);
            MinTest(m8, "M8", 4, 1, 3);
            MinTest(m9, "M9", -100, 0, 3);

            TransposeTest(m6, "M6");
            TransposeTest(m7, "M7");
            TransposeTest(m8, "M8");
            TransposeTest(m9, "M9");

            HasValueTest(m6 as PartialArrayMatrix, "M6", true, 0, 0);
            HasValueTest(m6 as PartialArrayMatrix, "M6", false, 1, 0);
            HasValueTest(m7 as PartialArrayMatrix, "M7", true, 1, 1);
            HasValueTest(m7 as PartialArrayMatrix, "M7", false, 0, 2);
            HasValueTest(m8 as PartialArrayMatrix, "M8", true, 1, 3);
            HasValueTest(m8 as PartialArrayMatrix, "M8", false, 2, 2);
            HasValueTest(m9 as PartialArrayMatrix, "M9", true, 3, 0);
            HasValueTest(m9 as PartialArrayMatrix, "M9", false, 0, 0);

        }

        //
        // Odkomentować do I etapu !!!
        //
        private static void TransposeTest(Matrix m, string name)
        {
            Console.WriteLine("{0}:", name);
            m.Print();
            m.Transpose();
            Console.WriteLine("{0} transponowana:", name);
            m.Print();
            m.Transpose();
            Console.WriteLine();
        }

        //
        // Odkomentować do II etapu !!!
        //
        private static void MaxTest(Matrix m, string name, double expectedValue, int expectedRow, int expectedColumn)
        {
            int r, c;
            var max = m.Max(out r, out c);
            Console.WriteLine("{0} max:", name);
            Console.WriteLine("{0} w elemencie [ {1}, {2} ]    - Powinno być {3} w [ {4}, {5} ]\n", max, r, c, expectedValue, expectedRow, expectedColumn);
        }

        //
        // Odkomentować do II etapu !!!
        //
        private static void MinTest(Matrix m, string name, double expectedValue, int expectedRow, int expectedColumn)
        {
            int r, c;
            var min = m.Min(out r, out c);
            Console.WriteLine("{0} min:", name);
            Console.WriteLine("{0} w elemencie [ {1}, {2} ]    - Powinno być {3} w [ {4}, {5} ]\n", min, r, c, expectedValue, expectedRow, expectedColumn);
        }

        //
        // Odkomentować do III etapu !!!
        //
        private static void HasValueTest(PartialArrayMatrix m, string name, bool expectedResult, int row, int column)
        {
            var result = m.HasValue(row, column);
            Console.WriteLine("Czy {0}[{1}, {2}] ma wartość? {3}. Powinno być {4}", name, row, column, result, expectedResult);
        }
    }
}
