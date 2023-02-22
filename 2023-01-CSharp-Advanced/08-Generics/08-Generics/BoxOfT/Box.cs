namespace BoxOfT
{
    public class Box<T>
    {
        private int count;
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public int Count { get { return this.count; } }

        public void Add(T element)
        {
            count++;
            elements.Add(element);
        }

        public T Remove()
        {
            count--;
            T elementToRemove = elements[count];
            elements.Remove(elementToRemove);

            return elementToRemove;
        }
    }
}
