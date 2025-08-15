namespace DesignPattern.DesignPatterns;

public class 工厂模式
{
    public static void Run()
    {
        // 注册所有可用产品类型
        ProductFactory.Register<ProductA>("A");
        ProductFactory.Register<ProductB>("B");

        // 使用工厂创建产品
        IProduct productA = ProductFactory.Create("A");
        productA.Operation();

        IProduct productB = ProductFactory.Create("B");
        productB.Operation();
    }
}

// 产品接口
public interface IProduct
{
    void Operation();
}

// 具体产品实现
public class ProductA : IProduct
{
    public void Operation() => Console.WriteLine("生产A产品");
}

public class ProductB : IProduct
{
    public void Operation() => Console.WriteLine("生产B产品");
}

// 厂类
public static class ProductFactory
{
    private static readonly Dictionary<string, Func<IProduct>> _products = new();

    // 注册产品类型
    public static void Register<T>(string type) where T : IProduct, new()
    {
        _products[type] = () => new T();
    }

    // 创建产品
    public static IProduct Create(string type)
    {
        if (_products.TryGetValue(type, out var creator))
        {
            return creator();
        }
        throw new ArgumentException($"没有'{type}'这种产品");
    }
}