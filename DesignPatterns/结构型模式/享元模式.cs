namespace DesignPattern.DesignPatterns;

public class 享元模式
{
    public static void Run()
    {
        BulletFactory factory = new BulletFactory();

        // 获取（或创建）子弹对象
        Bullet bullet1 = factory.GetBullet("basic");
        bullet1.Display(10, 20, "上");

        Bullet bullet2 = factory.GetBullet("basic");
        bullet2.Display(15, 25, "下");

        Bullet bullet3 = factory.GetBullet("basic");
        bullet3.Display(30, 40, "左");
        
    }
    
}

//抽象享元类
public abstract class Bullet
{
    // 内部状态（共享部分）
    protected string Model;  
    protected string Texture; 
    protected int Speed;      

    public abstract void Display(int x, int y, string direction);
}


//具体享元类（共享对象）
public class ConcreteBullet : Bullet
{
    public ConcreteBullet(string model, string texture, int speed)
    {
        Model = model;
        Texture = texture;
        Speed = speed;
    }
    // 外部状态通过参数传入（不共享部分）
    public override void Display(int x, int y, string direction)
    {
        Console.WriteLine($"子弹模型:{Model}, 贴图:{Texture}, 速度:{Speed} " +
                          $"=> 出现在位置({x},{y})，方向:{direction}");
    }
}


//享元工厂（管理共享对象）
public class BulletFactory
{
    private Dictionary<string, Bullet> bullets = new();

    public Bullet GetBullet(string key)
    {
        if (!bullets.ContainsKey(key))
        {
            // 模拟创建一个耗时的对象
            Console.WriteLine($"创建新的子弹对象: {key}");
            bullets[key] = new ConcreteBullet("BasicModel", "BulletTexture.png", 10);
        }
        else
        {
            Console.WriteLine($"复用已有子弹对象: {key}");
        }

        return bullets[key];
    }
}