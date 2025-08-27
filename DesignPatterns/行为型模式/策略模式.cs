namespace DesignPattern.DesignPatterns.行为型模式;

public static class 策略模式
{
    public static void Run()
    {
        // 简单策略模式演示
        IStrategy strategy = new ConcreteStrategyA();
        StrategyContext strategyContext = new StrategyContext(strategy);
        strategyContext.ContextInterface();
    }

    
}

public interface IStrategy
{
    void AlgorithmInterface();
}

public class ConcreteStrategyA : IStrategy
{
    public void AlgorithmInterface()
    {
        Console.WriteLine("策略A被调用");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void AlgorithmInterface()
    {
        Console.WriteLine("策略B被调用");
    }
}
public class StrategyContext
{
    private readonly IStrategy _strategy;

    public StrategyContext(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ContextInterface()
    {
        _strategy.AlgorithmInterface();
    }
}

