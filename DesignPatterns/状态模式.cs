namespace DesignPattern.DesignPatterns
{
    public static class 状态模式
    {
        public static void Run()
        {
            Context context = new Context(new ConcreteStateA());
            context.Request();
            context.Request();
        }

        public abstract class State
        {
            public abstract void Handle(Context context);
        }

        public class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("当前状态：A，切换到B");
                context.State = new ConcreteStateB();
            }
        }

        public class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("当前状态：B，切换到A");
                context.State = new ConcreteStateA();
            }
        }

        public class Context
        {
            public State State { get; set; }
            public Context(State state)
            {
                State = state;
            }
            public void Request()
            {
                State.Handle(this);
            }
        }
    }
}

