using System.Collections.Generic;

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

        public SparseMatrix(int _rows, int _columns, int[] _rowsVals, int[] _columnsVals, double[] _values)
            : base(_rows, _columns)
        {
            rows = _rowsVals;
            columns = _columnsVals;
            values = _values;
            nonZeroValues = _values.Length;
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
    }
}
