using System;

namespace MatrixLibrary
{
    public class ArrayMatrix : Matrix
    {
        private double[,] values;

        public ArrayMatrix(int _rows, int _columns, double [,] _values = null) : base(_rows, _columns)
        {
            if (Rows == -1 || Columns == -1)
                return;

            values = new double[Rows, Columns];

            if (_values == null)
                return;

            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    values[i, j] = _values[i, j];
        }

        public override double GetValue(int row, int column)
        {
            if (row >= Rows || row < 0 || column >= Columns || column < 0)
                return double.MinValue;

            return values[row, column];
        }

        // tu dopisać definicje metod Transpose, Max, Min
        public override void Transpose()
        {
            double[,] transposed = new double[Columns,Rows];
            for (int row=0; row < Rows; row++)
            {
                for (int column=0; column < this.Columns; column++)
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
            for (int i=0; i < Rows; i++)
                for (int j=0; j < Columns; j++)
                {
                    if (values[i, j] < values[row, column])
                    {
                        row = i;
                        column = j;
                    }
                }

            return values[row, column];
        }

        public override double Max(out int row, out int column)
        {
            row = column = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                {
                    if (values[i, j] > values[row, column])
                    {
                        row = i;
                        column = j;
                    }
                }

            return values[row, column];
        }

    }
}
