namespace MatrixSize
{
    public class Size
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool IsSquare
        {
            get { return Width == Height; }
        }

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Size) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width*397) ^ Height;
            }
        }

        public static bool operator ==(Size left, Size right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !Equals(left, right);
        }
    }
}
