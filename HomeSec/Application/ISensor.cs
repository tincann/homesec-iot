namespace HomeSec.Application
{
    public interface ISensor
    {
        event Detected OnDetected;
        event Undetected OnUndetected;
    }
    
    public delegate void Detected(object sender, DetectedArgs args);
    public delegate void Undetected(object sender, DetectedArgs args);

    public class DetectedArgs
    {
    }
}
