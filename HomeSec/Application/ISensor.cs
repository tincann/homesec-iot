namespace HomeSec.Application
{
    public interface ISensor
    {
        event Detected OnDetected;
        event Undetected OnUndetected;
    }

    public delegate void Detected(object sender, SensorArgs args);
    public delegate void Undetected(object sender, SensorArgs args);

    public class SensorArgs { }
}