namespace DesignPattern.DesignPatterns.行为型模式;

public class 访问者模式
{
    public static void Run()
    {
        List<IElement> elements = [new ElementA(), new ElementB()];
        IVisitor visitor = new ConcreteVisitor();
        foreach (var e in elements)
            e.Accept(visitor);
    }
}
public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ElementA : IElement
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
    public void OperationA() => Console.WriteLine("元素A的操作");
}

public class ElementB : IElement
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
    public void OperationB() => Console.WriteLine("元素B的操作");
}

public class ConcreteVisitor : IVisitor
{
    public void Visit(ElementA element)
    {
        Console.Write("访问者访问");
        element.OperationA();
    }
    public void Visit(ElementB element)
    {
        Console.Write("访问者访问");
        element.OperationB();
    }
}

