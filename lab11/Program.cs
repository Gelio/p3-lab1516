using System;
using System.Collections.Generic;

namespace Lab11a
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			SantaPostOffice santaPostOffice = new SantaPostOffice ();
			List<Message> messages = new List<Message> { new Message("Chess", "Game"), new Message("Checkers", "Game"), new Message("Go", "Game"), 
				new Message("Barbie", "Doll"), new Message("Ken", "Doll"), new Message("The Fellowship of the Ring", "Book")};


			
			System.Console.Out.WriteLine ("Etap1");

			IToyFactory unstable = new UnstableToyFactory ();
			IToyFactory doll = new DollFactory ();
			unstable.BindToPostOffice (santaPostOffice);
			doll.BindToPostOffice (santaPostOffice);

			foreach(Message message in messages) {
				santaPostOffice.ReceiveMessage (message);
			}

			System.Console.Out.WriteLine ();
            System.Console.Out.WriteLine("Etap2");

            unstable.UnbindFromPostOffice(santaPostOffice);

            System.Console.Out.WriteLine("Tylko doll");
            foreach (Message message in messages)
            {
                santaPostOffice.ReceiveMessage(message);
            }

            doll.UnbindFromPostOffice(santaPostOffice);

            System.Console.Out.WriteLine("nic");
            foreach (Message message in messages)
            {
                santaPostOffice.ReceiveMessage(message);
            }

            unstable.BindToPostOffice(santaPostOffice);
            System.Console.Out.WriteLine("Tylko unstable");
            foreach (Message message in messages)
            {
                santaPostOffice.ReceiveMessage(message);
            }

        }
	}
}
