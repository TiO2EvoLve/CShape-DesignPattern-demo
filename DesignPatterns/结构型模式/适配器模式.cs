namespace DesignPattern.DesignPatterns.结构型模式;

public static class 适配器模式
{
    public static void Run()
    {
        ITarget target = new Adapter(new Adaptee());
        target.Request();
    }
}

public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("适配者方法被调用");
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}