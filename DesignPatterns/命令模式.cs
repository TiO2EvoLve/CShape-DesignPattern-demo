namespace DesignPattern.DesignPatterns
{
    public static class 命令模式
    {
        public static void Run()
        {
            // 简单命令模式演示
            Receiver receiver = new Receiver();
            ICommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker(command);
            invoker.ExecuteCommand();
        }

        public interface ICommand
        {
            void Execute();
        }

        public class ConcreteCommand : ICommand
        {
            private readonly Receiver _receiver;
            public ConcreteCommand(Receiver receiver)
            {
                _receiver = receiver;
            }
            public void Execute()
            {
                _receiver.Action();
            }
        }

        public class Receiver
        {
            public void Action()
            {
                Console.WriteLine("接收者执行操作");
            }
        }

        public class Invoker
        {
            private readonly ICommand _command;
            public Invoker(ICommand command)
            {
                _command = command;
            }
            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }
    }
}

