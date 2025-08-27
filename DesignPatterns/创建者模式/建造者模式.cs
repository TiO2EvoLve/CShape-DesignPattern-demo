namespace DesignPattern.DesignPatterns.创建者模式;

public class 建造者模式
{
    public static void Run()
    {
        var director = new Director();
        var builder = new ConcreteBuilder();
        director.Construct(builder);
        var product = builder.GetResult();
        product.Show();
    }
}

public class Product
{
    public List<string> Parts { get; } = new();
    public void Show() => Console.WriteLine($"产品部件：{string.Join(", ", Parts)}");
}

public abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
}

public class ConcreteBuilder : Builder
{
    private readonly Product _product = new();
    public override void BuildPartA() => _product.Parts.Add("部件A");
    public override void BuildPartB() => _product.Parts.Add("部件B");
    public override Product GetResult() => _product;
}

public class Director
{
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}