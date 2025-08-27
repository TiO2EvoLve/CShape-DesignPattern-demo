namespace DesignPattern.DesignPatterns.结构型模式;

public static class 代理模式
{
    public static void Run()
    {
        // 简单代理模式演示
        ISubject subject = new Proxy();
        subject.Request();
    }
}

public interface ISubject
{
    void Request();
}

public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("真实请求被调用");
    }
}

public class Proxy : ISubject
{
    private RealSubject? _realSubject;

    public void Request()
    {
        _realSubject ??= new RealSubject();
        Console.WriteLine("代理前置处理");
        _realSubject.Request();
        Console.WriteLine("代理后置处理");
    }
}