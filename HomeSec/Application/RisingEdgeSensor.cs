using Windows.Devices.Gpio;

namespace HomeSec.Application
{
    internal class RisingEdgeSensor : ISensor
    {
        public RisingEdgeSensor(GpioPin pin)
        {
            pin.ValueChanged += PinOnValueChanged;
        }

        public event Detected OnDetected;
        public event Undetected OnUndetected;
        
        private void PinOnValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            if (args.Edge == GpioPinEdge.RisingEdge)
            {
                OnDetected?.Invoke(this, new DetectedArgs());
            }
            else
            {
                OnUndetected?.Invoke(this, new DetectedArgs());
            }
        }
    }
}