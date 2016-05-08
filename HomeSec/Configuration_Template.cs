namespace HomeSec
{
    //Rename this file and class to Configuration
    public static class Configuration_Template
    {
        //GPIO BCM Pin number for the door sensor
        public const int DoorSensorPin = 17;

        //Telegram Bot Token
        public const string TelegramApiToken = "";
        
        //Telegram chat ids that can send commands through the bot
        public static int[] CommandChatIdWhitelist = { };

        //Telgram chat ids of chats that will be notified when the notifier is triggered
        public static int[] NotifyChatIds = { };
    }
}
