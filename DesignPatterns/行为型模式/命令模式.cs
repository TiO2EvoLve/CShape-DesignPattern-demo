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

        private class ConcreteCommand(Receiver receiver) : ICommand
        {
            public void Execute()
            {
                receiver.Action();
            }
        }

        private class Receiver
        {
            public void Action()
            {
                Console.WriteLine("接收者执行操作");
            }
        }

        private class Invoker(ICommand command)
        {
            public void ExecuteCommand()
            {
                command.Execute();
            }
        }
    }
}

