using System;

namespace Lab11a
{
	public class SantaPostOffice
	{
        //TU napisać zdarzenie i ew. metody pomocniczne
        public event Func<Message, bool> MailArrived = null;

		public void ReceiveMessage(Message message){
            if (MailArrived != null)
            {
                foreach (var handler in MailArrived.GetInvocationList())
                {
                    if ((handler as Func<Message, bool>)(message))
                        return;
                }
            }
            Console.WriteLine("Unhandled message " + message);
		}
	}
}

