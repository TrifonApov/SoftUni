using System;

namespace GenericCountMethod;

public class Box<T> where T : IComparable
{
    private T value;

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public bool CompareToGivenElement(T element)
    {
        return this.Value.CompareTo(element) > 0;
    }
    public override string ToString()
    {
        return $"{typeof(T)}: {Value}";  
    }
}