using System;

namespace MatrixLibrary
{
    abstract class Matrix
    {
        public int Rows;
        public int Columns;
        protected double[,] Values;

        public Matrix(int rows, int columns, double[,] values)
        {
            if (values == null || values.GetLength(0) != rows || values.GetLength(1) != columns)
            {
                this.Rows = this.Columns = -1;
                return;
            }

            this.Rows = rows;
            this.Columns = columns;
            this.Values = new double[rows, columns];
            for (int i=0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    this.Values[i, j] = values[i, j];
        }

        abstract public double GetValue(int row, int column);
        abstract public void SetValue(int row, int column, double value);
        abstract public bool IsValidElement(int row, int column);

        public void Print()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                    Console.Write(this.GetValue(i, j) + " ");
                Console.WriteLine();
            }
        }
    }
}
