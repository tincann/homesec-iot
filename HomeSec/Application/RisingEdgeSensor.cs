using System;
using System.Diagnostics;
using Windows.Devices.Gpio;

namespace HomeSec.Application
{
    internal class RisingEdgeSensor : ISensor
    {
        public RisingEdgeSensor(GpioPin pin, TimeSpan debounceTimeout)
        {
            pin.DebounceTimeout = debounceTimeout;
            pin.ValueChanged += PinOnValueChanged;
        }

        public event Detected OnDetected;
        public event Undetected OnUndetected;
        
        private void PinOnValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            Debug.WriteLine(args.Edge);
            if (args.Edge == GpioPinEdge.RisingEdge)
            {
                OnDetected?.Invoke(this, new SensorArgs());
            }
            else
            {
                OnUndetected?.Invoke(this, new SensorArgs());
            }
        }
    }
}