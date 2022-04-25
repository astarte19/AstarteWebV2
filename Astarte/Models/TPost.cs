using System;
namespace Astarte.Models
{
	public class TPost
	{
		public string BotName = "BOT";
		public string ApiToken = "TOKEN";
		public string Mode = "html";
		
		public string PostType { get;set; }

		public string ImageUrl { get; set; }
		public string ImageCaption { get; set; }

		public string TextField { get; set; }

		public string DocumentUrl { get; set; }
		public string DocumentCaption { get; set; }

		public string AudioUrl { get; set; }
		public string AudioCaption { get; set; }

		public string VideoUrl { get; set; }
		public string VideoCaption { get; set; }



		public string ChatID { get; set; }

		public DateTime SendingTime { get; set; }

	}
}

