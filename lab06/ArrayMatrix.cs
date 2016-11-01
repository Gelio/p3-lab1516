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

    }
}
