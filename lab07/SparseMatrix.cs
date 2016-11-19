using System;
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

        public override void Increment()
        {
            for (int i = 0; i < values.Length; i++)
                values[i]++;
        }

        public override Matrix Clone()
        {
            int[] clonedRows = new int[rows.Length],
                clonedColumns = new int[columns.Length];
            double[] clonedValues = new double[values.Length];
            for (int i = 0; i < rows.Length; i++)
                clonedRows[i] = rows[i];
            for (int i = 0; i < columns.Length; i++)
                clonedColumns[i] = columns[i];
            for (int i = 0; i < values.Length; i++)
                clonedValues[i] = values[i];

            return new SparseMatrix(Rows, Columns, clonedRows, clonedColumns, clonedValues);
        }

        public override void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] *= scalar;
        }

        public override void AddMatrix(Matrix m)
        {
            for (int i=0; i < nonZeroValues; i++)
            {
                int row = rows[i],
                    column = columns[i];
                double value = values[i];
                SetValue(row, column, value + m.GetValue(row, column));
            }
        }

        public override void SetValue(int row, int column, double value)
        {
            for (int i=0; i < nonZeroValues; i++)
            {
                if (rows[i] == row && columns[i] == column)
                {
                    values[i] = value;
                    return;
                }
            }

            int[] extendedRows = new int[nonZeroValues + 1],
                extendedColumns = new int[nonZeroValues + 1];
            double[] extendedValues = new double[nonZeroValues + 1];
            for (int i=0; i < nonZeroValues; i++)
            {
                extendedRows[i] = rows[i];
                extendedColumns[i] = columns[i];
                extendedValues[i] = values[i];
            }
            extendedRows[nonZeroValues] = row;
            extendedColumns[nonZeroValues] = column;
            extendedValues[nonZeroValues] = value;

            rows = extendedRows;
            columns = extendedColumns;
            values = extendedValues;
            nonZeroValues += 1;
        }
    }
}
