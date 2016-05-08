namespace HomeSec.Application
{
    public interface IActuator
    {
        void Trigger(object sender, SensorArgs args);
        void Untrigger(object sender, SensorArgs args);
    }
}