namespace DesignPattern.DesignPatterns.行为型模式;

public class 观察者模式
{
    public static void Run()
    {
        var station = new WeatherStation();

        var display1 = new PhoneDisplay("用户A的手机");
        var display2 = new PhoneDisplay("用户B的手机");

        display1.Subscribe(station);
        display2.Subscribe(station);

        station.SetTemperature(25.3f);
        station.SetTemperature(30.1f);

        Console.WriteLine("用户B的手机取消订阅");
        display2.Unsubscribe(station);

        station.SetTemperature(22.8f);
    }
}
//用户手机
public class PhoneDisplay(string name)
{
    public void Subscribe(WeatherStation station)
    {
        station.OnTemperatureChanged += Update;
    }

    public void Unsubscribe(WeatherStation station)
    {
        station.OnTemperatureChanged -= Update;
    }

    private void Update(float temperature)
    {
        Console.WriteLine($"[{name}] 收到天气更新：当前温度为 {temperature}°C");
    }
}
//气象站
public class WeatherStation
{
    public event Action<float>? OnTemperatureChanged;
    
    public void SetTemperature(float temp)
    {
        Console.WriteLine($"\n[WeatherStation] 温度更新为：{temp}°C");
        OnTemperatureChanged?.Invoke(temp); // 通知所有订阅者
    }
}