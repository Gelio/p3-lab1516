using System;

namespace MatrixLibrary
{
    class Program
    {
        static int testCounter = 1;

        static void Main(string[] args)
        {
            Matrix m1 = new ArrayMatrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            Matrix m2 = new ArrayMatrix(2, 3, new double[,] { { 5, 6, 10 }, { 7, 8, 100 } });
            Matrix m7 = new ArrayMatrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });

            Matrix m3 = new SparseMatrix(2, 3, new double[,] { { 1, -10, 0 }, { 0, 0, 0 } });
            Matrix m4 = new SparseMatrix(2, 2, new double[,] { { 13, 14 }, { 15, 16 } });
            Matrix m5 = new SparseMatrix(3, 2, new double[,] { { 0, 0 }, { 0, 0 }, { 100, -100 } });
            Matrix m6 = new SparseMatrix(2, 2, new double[,] { { 0, 0 }, { 100, 0 } });

            Console.WriteLine("===== ETAP 1 =====");
            Console.WriteLine();

            //UWAGA: Należy odkomentować metodę TestInc poniżej metody Main

            TestInc(m1, "M1");
            TestInc(m2, "M2");
            TestInc(m3, "M3");
            TestInc(m4, "M4");
            TestInc(m5, "M5");

            Console.WriteLine("==== ETAP 2 ====");
            Console.WriteLine();

            //UWAGA: Należy odkomentować metodę TestScalarMul poniżej metody Main

            TestScalarMul(m1, 2, "M1");
            TestScalarMul(m2, 0.5, "M1");
            TestScalarMul(m3, 100, "M3");
            TestScalarMul(m4, 1.001, "M4");
            TestScalarMul(m5, 4, "M5");

            Console.WriteLine("==== ETAP 3 ====");
            Console.WriteLine();

            //UWAGA: Należy odkomentować metodę TestAdd poniżej metody Main

            TestAdd(m1, m2, "M1", "M2", null);
            TestAdd(m2, m1, "M2", "M1", null);
            TestAdd(m4, m3, "M4", "M3", null);
            TestAdd(m3, m5, "M3", "M5", null);
            TestAdd(m1, m3, "M1", "M3", null);
            TestAdd(m2, m3, "M2", "M3", new ArrayMatrix(2, 3, new double[,] { { 8, -2, 11 }, { 8, 9, 101 } }));
            TestAdd(m1, m4, "M1", "M4", new ArrayMatrix(2, 2, new double[,] { { 16, 18 }, { 20, 22 } }));
            TestAdd(m1, m6, "M1", "M6", new ArrayMatrix(2, 2, new double[,] { { 2, 3 }, { 104, 5 } }));
            TestAdd(m4, m6, "M4", "M6", new ArrayMatrix(2, 2, new double[,] { { 14, 15 }, { 116, 17 } }));
            TestAdd(m1, m7, "M1", "M7", new ArrayMatrix(2, 2, new double[,] { { 3, 5 }, { 7, 9 } }));

        }

        static void TestInc(Matrix m, string name)
        {
            Console.WriteLine("==== TEST {0} ====", testCounter++);
            Console.WriteLine("Macierz " + name);
            m.Print();
            m++;
            Console.WriteLine("Maicerz {0} po inkrementacji", name);
            m.Print();
        }

        static void TestScalarMul(Matrix m, double scalar, string name)
        {
            Console.WriteLine("==== TEST {0} ====", testCounter++);
            Console.WriteLine("Macierz " + name);
            m.Print();
            Matrix newMR = m * scalar;
            Matrix newML = scalar * m;
            Console.WriteLine("Maicerz {0} po mnożeniu z prawej przez {1}", name, scalar);
            newMR.Print();

            Console.WriteLine("Maicerz {0} po mnożeniu z lewej przez {1}", name, scalar);
            newML.Print();

            if (m.GetType() != newMR.GetType() || m.GetType() != newML.GetType())
                Console.WriteLine("Błąd: niezgodność typów przy mnożeniu przez sklar\n");
        }

        static void TestAdd(Matrix m1, Matrix m2, string name1, string name2, Matrix shouldBe)
        {
            Console.WriteLine("==== TEST {0} ====", testCounter++);
            var res = m1 + m2;
            Console.WriteLine("{0} + {1} = ", name1, name2);

            if (res != null)
                res.Print();
            else
                Console.WriteLine("NULL\n");

            Console.WriteLine("Powinno być:");
            if (shouldBe != null)
                shouldBe.Print();
            else
                Console.WriteLine("NULL\n");

            if (m1 != null && m2 != null && res != null)
                if (m1.GetType() == typeof(SparseMatrix) && m2.GetType() == typeof(SparseMatrix) && res.GetType() != typeof(SparseMatrix))
                    Console.WriteLine("Błąd: niezgodność typów przy mnożeniu macierzy\n");

        }
    }
}
