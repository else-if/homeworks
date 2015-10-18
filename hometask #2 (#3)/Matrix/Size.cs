namespace Matrix

{
    public class Size
    {
        public int Width { get; }
        public int Height { get; }
        public bool IsSquare => Width == Height;

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Size)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
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
