namespace DesignPattern.DesignPatterns
{
    public static class 策略模式
    {
        public static void Run()
        {
            // 简单策略模式演示
            IStrategy strategy = new ConcreteStrategyA();
            Context context = new Context(strategy);
            context.ContextInterface();
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

        public class Context
        {
            private readonly IStrategy _strategy;
            public Context(IStrategy strategy)
            {
                _strategy = strategy;
            }
            public void ContextInterface()
            {
                _strategy.AlgorithmInterface();
            }
        }
    }
}

