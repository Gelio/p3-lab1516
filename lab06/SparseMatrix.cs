using System;

namespace MatrixLibrary
{
    public class SparseMatrix : Matrix
    {
        private int nonZeroValues;
        private int[] rows;
        private int[] columns;
        private double[] values;

        public SparseMatrix(int _rows, int _columns, double [,] _values) : base(_rows, _columns)
        {
            if (Rows == -1 || Columns == -1)
                return;

            nonZeroValues = 0;

            for (int i = 0; i < _rows; ++i)
                for (int j = 0; j < _columns; ++j)
                    if (_values[i, j] != 0)
                        ++nonZeroValues;

            rows = new int[nonZeroValues];
            columns = new int[nonZeroValues];
            values = new double[nonZeroValues];

            int counter = 0;
            for (int i = 0; i < _rows; ++i)
                for (int j = 0; j < _columns; ++j)
                    if (_values[i, j] != 0)
                    {
                        rows[counter] = i;
                        columns[counter] = j;
                        values[counter] = _values[i, j];
                        ++counter;
                    }

        }

        public override double GetValue(int row, int column)
        {
            if (row >= Rows || row < 0 || column >= Columns || column < 0)
                return double.MinValue;

            for (int i = 0; i < nonZeroValues; ++i)
                if (rows[i] == row && columns[i] == column)
                    return values[i];

            return 0;
        }

        // tu dopisać definicje metod Transpose, Max, Min
        public override void Transpose()
        {
            int c;
            for (int i=0; i < nonZeroValues; i++)
            {
                c = rows[i];
                rows[i] = columns[i];
                columns[i] = c;
            }

            c = Rows;
            Rows = Columns;
            Columns = c;
        }

        public override double Min(out int row, out int column)
        {
            if (nonZeroValues == 0)
            {
                row = column = 0;
                return 0;
            }

            int minIndex = 0;
            for (int i = 1; i < nonZeroValues; i++)
            {
                if (values[i] < values[minIndex])
                    minIndex = i;
            }

            if (values[minIndex] > 0 && nonZeroValues < Rows * Columns)
            {
                // Najmniejszy element to zero, szukamy go
                for (int i=0; i < Rows; i++)
                    for (int j=0; j < Columns; j++)
                    {
                        if (GetValue(i, j) == 0)
                        {
                            row = i;
                            column = j;
                            return 0;
                        }
                    }
            }

            row = rows[minIndex];
            column = columns[minIndex];
            return values[minIndex];
        }

        public override double Max(out int row, out int column)
        {
            if (nonZeroValues == 0)
            {
                row = column = 0;
                return 0;
            }

            int maxIndex = 0;
            for (int i=1; i < nonZeroValues; i++)
            {
                if (values[i] > values[maxIndex])
                    maxIndex = i;
            }

            if (values[maxIndex] < 0 && nonZeroValues < Rows * Columns)
            {
                // Najwiekszy element to element zerowy, szukamy go
                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                    {
                        if (GetValue(i, j) == 0)
                        {
                            row = i;
                            column = j;
                            return 0;
                        }
                    }
            }

            row = rows[maxIndex];
            column = columns[maxIndex];
            return values[maxIndex];
        }

    }
}
