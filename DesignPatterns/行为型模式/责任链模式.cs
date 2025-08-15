namespace DesignPattern.DesignPatterns;

public class 责任链模式
{
    public static void Run()
    {
        // 创建具体处理者实例
        ConcreteHandlerA handlerA = new ConcreteHandlerA();
        ConcreteHandlerB handlerB = new ConcreteHandlerB();
        ConcreteHandlerC handlerC = new ConcreteHandlerC();

        // 构建责任链
        handlerA.SetNext(handlerB).SetNext(handlerC);

        // 定义请求
        object[] requests = { "A 问题", "B 问题", "C 问题", "D 问题" };

        // 遍历请求并传递给责任链处理
        foreach (object request in requests)
        {
            Console.WriteLine($"Client: 谁能处理 {request}?");
            object result = handlerA.Handle(request);
            if (result != null)
            {
                Console.WriteLine($"  {result}");
            }
            else
            {
                Console.WriteLine($"  {request} 没人能处理！");
            }
        }
    }
}
public abstract class AbstractHandler : IHandler
{
    // 下一个处理者
    private IHandler nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        this.nextHandler = handler;
        // 返回下一个处理者，方便链式调用
        return handler;
    }

    public virtual object Handle(object request)
    {
        if (this.nextHandler != null)
        {
            // 如果有下一个处理者，将请求传递给下一个处理者
            return this.nextHandler.Handle(request);
        }
        else
        {
            // 没有下一个处理者，返回null
            return null;
        }
    }
}
public class ConcreteHandlerA : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string)?.StartsWith("A") == true)
        {
            // 如果请求以A开头，处理该请求
            return $"ConcreteHandlerA: Handled request {request}";
        }
        else
        {
            // 否则，将请求传递给下一个处理者
            return base.Handle(request);
        }
    }
}

// 具体处理者类B
public class ConcreteHandlerB : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string)?.StartsWith("B") == true)
        {
            // 如果请求以B开头，处理该请求
            return $"ConcreteHandlerB: Handled request {request}";
        }
        else
        {
            // 否则，将请求传递给下一个处理者
            return base.Handle(request);
        }
    }
}

// 具体处理者类C
public class ConcreteHandlerC : AbstractHandler
{
    public override object Handle(object request)
    {
        if ((request as string)?.StartsWith("C") == true)
        {
            // 如果请求以C开头，处理该请求
            return $"ConcreteHandlerC: Handled request {request}";
        }
        else
        {
            // 否则，将请求传递给下一个处理者
            return base.Handle(request);
        }
    }
}
// 定义处理者接口
public interface IHandler
{
    // 设置下一个处理者
    IHandler SetNext(IHandler handler);
    // 处理请求
    object Handle(object request);
}