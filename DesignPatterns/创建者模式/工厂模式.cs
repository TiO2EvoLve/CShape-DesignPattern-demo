namespace DesignPattern.DesignPatterns.创建者模式;

public class 工厂模式
{
    public static void Run()
    {
        IProduct productA = ProductFactory.Create("A");
        productA.Operation();

        IProduct productB = ProductFactory.Create("B");
        productB.Operation();
    }
}
//产品接口
public interface IProduct
{
    void Operation();
}
//产品A生产工厂
public class ProductA : IProduct
{
    public void Operation() => Console.WriteLine("生产A产品");
}
//产品B生产工厂
public class ProductB : IProduct
{
    public void Operation() => Console.WriteLine("生产B产品");
}

public static class ProductFactory
{
    private static readonly Dictionary<string, Func<IProduct>> _productCreators = new()
    {
        ["A"] = () => new ProductA(),
        ["B"] = () => new ProductB()
    };

    public static IProduct Create(string type) =>
        _productCreators.TryGetValue(type, out var creator) 
            ? creator() 
            : throw new ArgumentException($"无效的产品类型: {type}");
}