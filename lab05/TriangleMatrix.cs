using System;

namespace MatrixLibrary
{
    class TriangleMatrix : Matrix
    {
        public int size;
        public double[][] values;
        public TriangleMatrix(int _size, double[,] _values):base(_size, _size, null)
        {
            if (_values == null || _values.GetLength(0) != _size || _values.GetLength(1) != _size)
            {
                this.size = 0;
                this.values = null;
                return;
            }

            this.Rows = this.Columns = this.size = _size;
            this.values = new double[_size][];
            for (int i=0; i < _size; i++)
            {
                this.values[i] = new double[i + 1];
                for (int j = 0; j <= i; j++)
                    this.values[i][j] = _values[i, j];
            }
        }

        public override double GetValue(int row, int column)
        {
            if (!this.IsValidElement(row, column))
                return double.MinValue;
            if (this.IsAboveDiagonal(row, column))
                return 0;

            return this.values[row][column];
        }
        public override void SetValue(int row, int column, double value)
        {
            if (this.IsValidElement(row, column) && !this.IsAboveDiagonal(row, column))
                this.values[row][column] = value;
        }

        public override bool IsValidElement(int row, int column)
        {
            return (row >= 0 && row < base.Rows && column >= 0 && column < base.Columns);
        }

        public bool IsAboveDiagonal(int row, int column)
        {
            return row < column;
        }
    }
}
