namespace GenericBoxOfT;

public class Box<T>
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

    public override string ToString()
    {
        return $"{typeof(T)}: {Value}";  
    }
}