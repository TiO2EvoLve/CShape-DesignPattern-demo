namespace DesignPattern.DesignPatterns.结构型模式;


public class 桥接模式
{
    public static void Run()
    {
        var ab = new RefinedAbstraction(new ConcreteImplementorA());
        ab.Operation();
    } 
}

public interface IImplementor
{
    void OperationImpl();
}

public class ConcreteImplementorA : IImplementor
{
    public void OperationImpl() => Console.WriteLine("实现A的具体操作");
}

public class ConcreteImplementorB : IImplementor
{
    public void OperationImpl() => Console.WriteLine("实现B的具体操作");
}

public abstract class Abstraction
{
    protected IImplementor implementor;
    protected Abstraction(IImplementor implementor) => this.implementor = implementor;
    public abstract void Operation();
}

public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor) { }
    public override void Operation()
    {
        implementor.OperationImpl();
    }
}

