using System;

namespace Lab11a
{
    class DollFactory : IToyFactory
    {
        public void BindToPostOffice(SantaPostOffice spo)
        {
            spo.MailArrived += _handleMessage;
        }

        private bool _handleMessage(Message message)
        {
            if (message.PresentType != "Doll")
                return false;

            Console.WriteLine("DollFactory: Building toy: " + message.PresentName);
            return true;
        }
    }
}
