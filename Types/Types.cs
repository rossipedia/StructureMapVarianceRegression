namespace Types
{
    public interface ISomeInterface<in T> {}
    public class Base {}
    public class Derived : Base {}
    public class Concrete : ISomeInterface<Base> {}
}
