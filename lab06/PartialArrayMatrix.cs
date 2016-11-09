using System;

namespace MatrixLibrary
{
    class PartialArrayMatrix : Matrix
    {
        private double?[,] values;

        public PartialArrayMatrix(int _rows, int _columns, int[] rowsT, int[] columnsT, double[] valuesT) : base(_rows, _columns)
        {
            if (Rows == -1 || Columns == -1)
                return;

            values = new double?[Rows, Columns];

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    values[i, j] = null;

            for (int i = 0; i < rowsT.Length; ++i)
                values[rowsT[i], columnsT[i]] = valuesT[i];
        }

        public bool HasValue(int row, int column)
        {
            return values[row, column].HasValue;
        }

        public override double GetValue(int row, int column)
        {
            if (row >= Rows || row < 0 || column >= Columns || column < 0)
                return double.MinValue;

            if (!HasValue(row, column))
                throw new InvalidOperationException();
            return values[row, column].Value;
        }

        public override void Transpose()
        {
            double?[,] transposed = new double?[Columns, Rows];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < this.Columns; column++)
                {
                    transposed[column, row] = values[row, column];
                }
            }
            values = transposed;

            int c = Rows;
            Rows = Columns;
            Columns = c;
        }

        public override double Min(out int row, out int column)
        {
            row = column = 0;
            double minVal = double.MaxValue;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                {
                    if (HasValue(i, j) && values[i, j] < minVal)
                    {
                        row = i;
                        column = j;
                        minVal = values[i, j].Value;
                    }
                }

            return minVal;
        }

        public override double Max(out int row, out int column)
        {
            row = column = 0;
            double maxVal = double.MinValue;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                {
                    if (HasValue(i, j) && values[i, j] > maxVal)
                    {
                        row = i;
                        column = j;
                        maxVal = values[i, j].Value;
                    }
                }

            return maxVal;
        }

        public override void Print()
        {
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    if (HasValue(i, j))
                        Console.Write("{0, 4}   ", GetValue(i, j));
                    else
                        Console.Write("{0, 4}   ", "null");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
