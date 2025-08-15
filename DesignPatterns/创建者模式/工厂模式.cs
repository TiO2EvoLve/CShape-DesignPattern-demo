namespace DesignPattern.DesignPatterns;

public class 工厂模式
{
    public static void Run()
    {
        IProduct productA = SimpleFactory.CreateProduct("A");
        productA.Operation();

        IProduct productB = SimpleFactory.CreateProduct("B");
        productB.Operation();
    }
}
public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("生产A产品");
    }
}

// 具体产品类B
public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("生产B产品");
    }
}

// 简单工厂类
public class SimpleFactory
{
    public static IProduct CreateProduct(string type)
    {
        switch (type)
        {
            case "A":
                return new ConcreteProductA();
            case "B":
                return new ConcreteProductB();
            default:
                throw new ArgumentException("没有这种产品");
        }
    }
}
public interface IProduct
{
    void Operation(); 
}