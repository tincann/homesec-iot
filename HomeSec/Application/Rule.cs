using System.Collections.Generic;

namespace HomeSec.Application
{
    public class Rule
    {
        private readonly ISensor _sensor;
        private readonly IEnumerable<IActuator> _actuators;

        public Rule(ISensor sensor, IActuator actuator)
        {
            _sensor = sensor;
            _actuators = new List<IActuator> {actuator};
            SubscribeEvents(sensor, actuator);
        }

        public Rule(ISensor sensor, IEnumerable<IActuator> actuators)
        {
            _sensor = sensor;
            _actuators = actuators;
            foreach (var actuator in actuators)
            {
                SubscribeEvents(sensor, actuator);
            }
        }

        public void Remove()
        {
            foreach (var actuator in _actuators)
            {
                UnsubscribeEvents(_sensor, actuator);
            }
        }

        private static void SubscribeEvents(ISensor sensor, IActuator actuator)
        {
            sensor.OnDetected += actuator.Trigger;
            sensor.OnUndetected += actuator.Untrigger;
        }

        private static void UnsubscribeEvents(ISensor sensor, IActuator actuator)
        {
            sensor.OnDetected -= actuator.Trigger;
            sensor.OnUndetected -= actuator.Untrigger;
        }
    }
}
