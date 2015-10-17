using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MatrixSize;

namespace Matrix
{
    public class CoolMatrix
    {
        public int[,] ArrInts { get; set; }
        public Size Size { get; private set; }
        public bool IsSquare => Size.IsSquare;

        public CoolMatrix(int[,] array)
        {
            if (ReferenceEquals(null, array)) throw new ArgumentNullException("array");

            Size = new Size(array.GetLength(0), array.GetLength(1));

            ArrInts = new int[Size.Width, Size.Height];
            Array.Copy(array, ArrInts, array.Length);
        }
        
        public static implicit operator CoolMatrix (int[,] array)
        {
            return new CoolMatrix(array);
        }
        
        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < Size.Width; i++)
            {
                result += i == 0 ? "" : Environment.NewLine;

                for (var j = 0; j < Size.Height; j++)
                    result += (j == 0 ? "[" : ", ") + ArrInts[i, j];

                result += "]";
            }

            return result;
        }

        public int this[int row, int col]
        {
            get
            {
                if ((col < 0) || (col >= Size.Width) ||
                     (row < 0) || (row >= Size.Height))
                    throw new IndexOutOfRangeException();

                return ArrInts[row, col];
            }
            set
            {
                if ((col < 0) || (col >= Size.Width) ||
                     (row < 0) || (row >= Size.Height))
                    throw new IndexOutOfRangeException();

                ArrInts[row, col] = value;
            }
        }

        protected bool Equals(CoolMatrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (Size != other.Size) return false;

            for(var i=0;i<Size.Width;i++)
                for (var j = 0; j < Size.Height; j++)
                {
                    if (ArrInts[i, j] != other.ArrInts[i, j]) return false;
                }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoolMatrix)obj);
        }

        public override int GetHashCode()
        {
            return (ArrInts != null ? ArrInts.GetHashCode() : 0);
        }

        public static bool operator ==(CoolMatrix left, CoolMatrix right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CoolMatrix left, CoolMatrix right)
        {
            return !Equals(left, right);
        }

        public static CoolMatrix operator *(CoolMatrix left, int right)
        {
            CoolMatrix result = left.ArrInts;

            for (var i = 0; i < result.Size.Width; i++)
            {
                for (var j = 0; j < result.Size.Height; j++)
                    result.ArrInts[i, j] *= right;
            }
        
            return result;
        }

        public static CoolMatrix operator +(CoolMatrix left, CoolMatrix right)
        {
            if (left.Size != right.Size) throw new ArgumentException("different sizes");

            CoolMatrix result = new CoolMatrix(new int[left.Size.Width, left.Size.Height]);

            for (var i = 0; i < result.Size.Width; i++)
            {
                for (var j = 0; j < result.Size.Height; j++)
                    result.ArrInts[i, j] = left.ArrInts[i, j] + right.ArrInts[i, j];
            }

            return result;
        }

        public CoolMatrix Transpose()
        {
            int[,] transposedArray = new int[Size.Height, Size.Width];

            for (var i = 0; i < Size.Width; i++)
                for (var j = 0; j < Size.Height; j++)
                    transposedArray[j, i] = ArrInts[i, j];

            Size = new Size(transposedArray.GetLength(0), transposedArray.GetLength(1));
            ArrInts = transposedArray;

            return this;
        }
    }
}
