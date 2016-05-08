using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace HomeSec.Application
{
    public class HomeSecController
    {
        public HomeSecController()
        {
            try
            {
                var gpio = GpioController.GetDefault();
                var pin = gpio.OpenPin(Configuration.DoorSensorPin);
                var doorSensor = new RisingEdgeSensor(pin);
            }
            catch
            {
                
            }

            var tbot = new TelegramNotifier(Configuration.TelegramApiToken);
        }
    }
}
