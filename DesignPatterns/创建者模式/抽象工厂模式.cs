namespace DesignPattern.DesignPatterns.创建者模式;

public class 抽象工厂模式
{
    public static void Run()
    {
        IFactory factory = new Factory1();
        var a = factory.CreateProductA();
        var b = factory.CreateProductB();
        a.Show();
        b.Show();
    }
}

public interface IProductA
{
    void Show();
}

public interface IProductB
{
    void Show();
}

public class ProductA1 : IProductA
{
    public void Show() => Console.WriteLine("产品A1");
}

public class ProductA2 : IProductA
{
    public void Show() => Console.WriteLine("产品A2");
}

public class ProductB1 : IProductB
{
    public void Show() => Console.WriteLine("产品B1");
}

public class ProductB2 : IProductB
{
    public void Show() => Console.WriteLine("产品B2");
}

public interface IFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class Factory1 : IFactory
{
    public IProductA CreateProductA() => new ProductA1();
    public IProductB CreateProductB() => new ProductB1();
}

public class Factory2 : IFactory
{
    public IProductA CreateProductA() => new ProductA2();
    public IProductB CreateProductB() => new ProductB2();
}