namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable

    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            if (left.CompareTo(right) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
