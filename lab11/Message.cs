using System;

namespace Lab11a
{
	public class Message
	{
		public Message(String presentName, String presentType){
			this.PresentName = presentName;
			this.PresentType = presentType;
		}

		public String PresentName {
			get;
			private set;
		}

		public String PresentType {
			get;
			private set;
		}

		public override string ToString ()
		{
			return string.Format ("[Message: PresentName={0}, PresentType={1}]", PresentName, PresentType);
		}
		
	}
}

