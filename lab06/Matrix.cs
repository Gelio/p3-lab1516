using System;

namespace MatrixLibrary
{
    public abstract class Matrix
    {
        public int Rows;
        public int Columns;

        public Matrix(int _rows, int _columns)
        {
            Rows = _rows;
            Columns = _columns;
        }

        public abstract double GetValue(int row, int column);

        public virtual void Print()
        {
            for(int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                    Console.Write("{0, 4}   ", GetValue(i, j));
                Console.WriteLine();
            }

            Console.WriteLine();
        }

// tu dopisać deklaracje metod abstrakcyjnych Transpose, Max, Min

    }
}
