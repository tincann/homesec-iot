using System.Diagnostics;
using Telegram.Bot;

namespace HomeSec.Application
{
    public class TelegramNotifier : IActuator
    {
        private readonly Api _api;
        private readonly object _lock = new object();
        private readonly int[] _notifyIds;

        public TelegramNotifier(string token, int[] notifyIds)
        {
            _notifyIds = notifyIds;

            Debug.WriteLine("Connecting to Telegram API...");
            _api = new Api(token);
            Debug.WriteLine("Connected to Telegram API");
            //_api.MessageReceived += (sender, args) =>
            //{
            //    var m = args.Message;
            //    Debug.WriteLine(m.Chat.Username + " " + m.Text);
            //};
            //_api.StartReceiving();
        }

        public void Trigger(object sender, SensorArgs args)
        {
            lock (_lock)
            {
                Debug.WriteLine("Sending Telegram notification for open");
                foreach (var notifyId in _notifyIds)
                {
                    var m = _api.SendTextMessage(notifyId, "Open").Result;
                }
            }
        }

        public void Untrigger(object sender, SensorArgs args)
        {
            lock (_lock)
            {
                Debug.WriteLine("Sending Telegram notification for closed");
                foreach (var notifyId in _notifyIds)
                {
                    _api.SendTextMessage(notifyId, "Dicht");
                }
            }
        }
    }
}