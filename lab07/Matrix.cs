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

        public abstract void Increment();
        public static Matrix operator++(Matrix m)
        {
            m.Increment();
            return m;
        }

        public abstract Matrix Clone();
        public abstract void MultiplyByScalar(double scalar);
        public static Matrix operator*(double scalar, Matrix m)
        {
            Matrix cloned = m.Clone();
            cloned.MultiplyByScalar(scalar);
            return cloned;
        }

        public static Matrix operator *(Matrix m, double scalar)
        {
            return scalar * m;
        }

        public abstract void AddMatrix(Matrix m);
        public abstract void SetValue(int row, int column, double value);

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns || m1.Rows == -1 || m1.Columns == -1)
                return null;

            Matrix resultMatrix = m1.Clone();
            resultMatrix.AddMatrix(m2);
            return resultMatrix;
        }
    }
}
