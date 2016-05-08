using System;
using Windows.Devices.Gpio;

namespace HomeSec.Application
{
    public class HomeSecController
    {
        public HomeSecController()
        {
            var gpio = GpioController.GetDefault();
            var pin = gpio.OpenPin(Configuration.DoorSensorPin);
            var doorSensor = new RisingEdgeSensor(pin, TimeSpan.FromMilliseconds(200));
            
            var tbot = new TelegramNotifier(Configuration.TelegramApiToken, Configuration.NotifyChatIds);

            var rule = new Rule(doorSensor, tbot);
        }
    }
}
