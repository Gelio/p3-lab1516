using System;

namespace Lab9
{
    class Program
    {
        static void TestPalindrom()
        {
            Console.WriteLine("--ETAP 1.0--");
            bool good = true;
            string s1 = "ikar lapal raki";
            Console.WriteLine("Testujemy " + s1 + ", wynikiem jest " + s1.IsPalindrom() + " powinno byc: True");
            good = good && (s1.IsPalindrom() == true);
            string s2 = "asdwdsa";
            Console.WriteLine("Testujemy " + s2 + ", wynikiem jest " + s2.IsPalindrom() + " powinno byc: True");
            good = good && (s2.IsPalindrom() == true);
            string s3 = "asddsa";
            Console.WriteLine("Testujemy " + s3 + ", wynikiem jest " + s3.IsPalindrom() + " powinno byc: True");
            good = good && (s3.IsPalindrom() == true);
            string s4 = "asdesa";
            Console.WriteLine("Testujemy " + s4 + ", wynikiem jest " + s4.IsPalindrom() + " powinno byc: False");
            good = good && (s4.IsPalindrom() == false);
            string s5 = "asaaaadesa";
            Console.WriteLine("Testujemy " + s5 + ", wynikiem jest " + s5.IsPalindrom() + " powinno byc: False");
            good = good && (s5.IsPalindrom() == false);
            Console.WriteLine("Ogolny wynik etapu: " + (good ? "PASSED" : "FAILED"));
        }

        static void TestPriorityQueueArray()
        {
            Console.WriteLine("--ETAP 2.1--");
            Console.WriteLine("TESTUJE KOLEJKE PRIORYTETOWA");
            MinPriorityQueueArray<int> pq = new MinPriorityQueueArray<int>();
            bool good = true;
            good = good && pq.Size == 0;
            bool good2 = true;
            pq.Put(8);
            pq.Put(3);
            pq.Put(5);
            pq.Put(2);
            pq.Put(1);
            pq.Put(5);
            pq.Put(9);
            pq.Put(8);

            int[] expected = new int[] { 1, 2, 3, 5, 5, 8, 8, 9 };

            for (int i = 0; i < expected.Length; i++)
            {
                if (pq.Get() != expected[i])
                    good2 = false;
            }
            Console.WriteLine("Scenariusz1 : " + (good && good2 ? "PASSED" : "FAILED"));

            MinPriorityQueueArray<double> pq2 = new MinPriorityQueueArray<double>();
            good = true;
            good = good && pq.Size == 0;
            good2 = true;
            pq2.Put(1.8);
            pq2.Put(1.3);
            pq2.Put(1.5);
            pq2.Put(1.2);
            pq2.Put(1.1);
            pq2.Put(1.5);
            pq2.Put(1.9);
            pq2.Put(1.8);

            double[] expected2 = new double[] { 1.1, 1.2, 1.3, 1.5, 1.5, 1.8, 1.8, 1.9 };

            for (int i = 0; i < expected.Length; i++)
            {
                if (pq2.Get() != expected2[i])
                    good2 = false;
            }
            Console.WriteLine("Scenariusz2 : " + (good && good2 ? "PASSED" : "FAILED"));
        }

        static void TestPriorityQueueArrayClone()
        {
            //Console.WriteLine("--ETAP 2.2--");
            //Console.WriteLine("TESTUJE KOLEJKE PRIORYTETOWA");
            //MinPriorityQueueArray<int> pq = new MinPriorityQueueArray<int>();
            //bool good = true;
            //good = good && pq.Size == 0;
            //Console.WriteLine("ROZMIAR: " + (good ? "PASSED" : "FAILED"));
            //bool good2 = true;
            //pq.Put(8);
            //pq.Put(3);
            //pq.Put(5);
            //pq.Put(2);
            //pq.Put(1);
            //pq.Put(5);
            //pq.Put(9);
            //pq.Put(8);

            //MinPriorityQueueArray<int> pq2 = (MinPriorityQueueArray<int>)pq.Clone();

            //int[] expected = new int[] { 1, 2, 3, 5, 5, 8, 8, 9 };

            //for (int i = 0; i < expected.Length; i++)
            //{
            //    if (pq.Get() != expected[i])
            //        good2 = false;
            //}

            //for (int i = 0; i < expected.Length; i++)
            //{
            //    if (pq2.Get() != expected[i])
            //        good2 = false;
            //}
            //Console.WriteLine("Wartosci zwracane przez kolejke: " + (good2 ? "PASSED" : "FAILED"));
            //Console.WriteLine("Ogolny wynik etapu: " + (good && good2 ? "PASSED" : "FAILED"));
        }

        static void TestToArray()
        {
            //Console.WriteLine("--ETAP 2.3--");
            //Console.WriteLine("TESTUJE KOLEJKE PRIORYTETOWA");
            //MinPriorityQueueArray<int> pq = new MinPriorityQueueArray<int>();
            //bool good = true;
            //good = good && pq.Size == 0;

            //bool good2 = true;
            //pq.Put(8);
            //pq.Put(3);
            //pq.Put(5);
            //pq.Put(2);
            //pq.Put(1);
            //pq.Put(5);
            //pq.Put(9);
            //pq.Put(8);

            //int[] expected = new int[] { 1, 2, 3, 5, 5, 8, 8, 9 };
            //int[] result = pq.ToSortedArray();

            //if (result.Length != expected.Length)
            //    good = false;
            //Console.WriteLine("ROZMIAR TABLICY: " + (good ? "PASSED" : "FAILED"));
            //if (good)
            //{
            //    for (int i = 0; i < expected.Length; i++)
            //    {
            //        if (result[i] != expected[i])
            //            good2 = false;
            //    }
            //}
            //Console.WriteLine("Wartosci w tablicy: " + (good2 ? "PASSED" : "FAILED"));
            //Console.WriteLine("Ogolny wynik etapu: " + (good && good2 ? "PASSED" : "FAILED"));
        }

        static void Main(string[] args)
        {
            TestPalindrom();
            Console.WriteLine(String.Empty);
            TestPriorityQueueArray();
            Console.WriteLine(String.Empty);
            TestPriorityQueueArrayClone();
            Console.WriteLine(String.Empty);
            TestToArray();
            Console.WriteLine(String.Empty);
        }
    }
}
