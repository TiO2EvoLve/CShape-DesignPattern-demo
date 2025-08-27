namespace DesignPattern.DesignPatterns.行为型模式;

public static class 模板方法模式
{
    public static void Run()
    {
        AbstractClass c = new ConcreteClass();
        c.TemplateMethod();
    }
}

public abstract class AbstractClass
{
    public void TemplateMethod()
    {
        PrimitiveOperation1();
        PrimitiveOperation2();
        Console.WriteLine("模板方法执行完毕");
    }

    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();
}

public class ConcreteClass : AbstractClass
{
    public override void PrimitiveOperation1()
    {
        Console.WriteLine("操作1实现");
    }

    public override void PrimitiveOperation2()
    {
        Console.WriteLine("操作2实现");
    }
}