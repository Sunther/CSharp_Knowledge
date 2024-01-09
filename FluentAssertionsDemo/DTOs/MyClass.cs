public class MyClass
{
    public int SomeProperty { get; internal set; }

    public MyClass SetProperty(int p)
    {
        SomeProperty = p;
        return this;
    }
}