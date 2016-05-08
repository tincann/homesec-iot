using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace HomeSec.Application
{
    public class TelegramNotifier : IActuator
    {
        private Api _api;

        public TelegramNotifier(string token)
        {
            _api = new Api(token);
            
            _api.MessageReceived += (sender, args) =>
            {
                var m = args.Message;
                Debug.WriteLine(m.Chat.Username + " " + m.Text);
            };
            _api.StartReceiving();
        }

        public void Trigger()
        {
            throw new NotImplementedException();
        }

        public void Untrigger()
        {
            throw new NotImplementedException();
        }
    }

    public interface IActuator
    {
        void Trigger();
        void Untrigger();
    }
}
