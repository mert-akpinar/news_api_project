using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitirme_projesi.DtoLayer.MessageDtos
{
	public class UpdateMessageDtos
	{
		public int MessageID { get; set; }
		public string MessageSubject { get; set; }
		public string MessageSenderName { get; set; }
		public string MessageBody { get; set; }
		public string MessageSenderSurname { get; set; }
		public string MessageSenderEmail { get; set; }
		public string MessageSenderPhone { get; set; }
		public DateTime MessageSendDate { get; set; }
	}
}
