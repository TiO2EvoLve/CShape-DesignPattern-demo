namespace DesignPattern.DesignPatterns.结构型模式;

public static class 装饰器模式
{
    public static void Run()
    {
        // 简单装饰器模式演示
        IComponent component = new ConcreteComponent();
        IComponent decorator = new ConcreteDecorator(component);
        decorator.Operation();
    }
}

public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("基础操作");
    }
}

public class ConcreteDecorator : IComponent
{
    private readonly IComponent _component;

    public ConcreteDecorator(IComponent component)
    {
        _component = component;
    }

    public void Operation()
    {
        _component.Operation();
        Console.WriteLine("装饰增强");
    }
}
