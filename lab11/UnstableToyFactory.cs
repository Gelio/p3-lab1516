using System;

namespace Lab11a
{
    class UnstableToyFactory : IToyFactory
    {
        Random rand = new Random();
        public void BindToPostOffice(SantaPostOffice spo)
        {
            spo.MailArrived += _handleMessage;
        }

        private bool _handleMessage(Message message)
        {
            if (rand.Next() % 2 == 0)
                return false;

            Console.WriteLine("UnstableToyFactory: Building toy: " + message.PresentName);
            return true;
        }
    }
}
