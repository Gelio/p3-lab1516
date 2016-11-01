using System;

namespace MatrixLibrary
{
    class ArrayMatrix : Matrix
    {
        public ArrayMatrix(int rows, int columns, double[,] values):base(rows, columns, values) { }

        public override double GetValue(int row, int column)
        {
            if (!this.IsValidElement(row, column))
                return double.MinValue;

            return base.Values[row, column];
        }
        public override void SetValue(int row, int column, double value)
        {
            if (this.IsValidElement(row, column))
                base.Values[row, column] = value;
        }

        public override bool IsValidElement(int row, int column)
        {
            return (row >= 0 && row < base.Rows && column >= 0 && column < base.Columns);
        }
    }
}
