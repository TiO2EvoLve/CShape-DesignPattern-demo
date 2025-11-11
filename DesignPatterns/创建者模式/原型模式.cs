namespace DesignPattern.DesignPatterns.创建者模式;

public class 原型模式
{
    public static void Run()
    {
        // 创建原型对象
        GameCharacter warriorPrototype = new GameCharacter("战士", 10, "长剑");
        // 基于原型克隆
        GameCharacter warriorA = warriorPrototype.Clone();
        warriorA.Name = "战士A";
        warriorA.ShowInfo();

        GameCharacter warriorB = warriorPrototype.Clone();
        warriorB.Name = "战士B";
        warriorB.Level = 12;
        warriorB.Weapon = "战斧";
        warriorB.ShowInfo();

        GameCharacter warriorC = warriorPrototype.Clone();
        warriorC.Name = "战士C";
        warriorC.Level = 15;
        warriorC.ShowInfo();
        
    }
}

// 原型接口
public interface IPrototype<T>
{
    T Clone();
}

// 游戏角色类，实现原型接口
public class GameCharacter(string name, int level, string weapon) : IPrototype<GameCharacter>
{
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public string Weapon { get; set; } = weapon;

    // 克隆方法
    public GameCharacter Clone()
    {
        // MemberwiseClone 是浅拷贝
        return (GameCharacter)MemberwiseClone();
    }

    public void ShowInfo()
    {
        Console.WriteLine($"角色：{Name} | 等级：{Level} | 武器：{Weapon}");
    }
}