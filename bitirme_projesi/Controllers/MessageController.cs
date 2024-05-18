using bitirme_projesi.BusinessLayer.Abstract;
using bitirme_projesi.DtoLayer.MessageDtos;
using bitirme_projesi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bitirme_projesi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDtos createMessageDtos)
		{
			Message message = new Message()
			{
				MessageBody = createMessageDtos.MessageBody,
				MessageSendDate = createMessageDtos.MessageSendDate,
				MessageSenderEmail = createMessageDtos.MessageSenderEmail,
				MessageSenderName = createMessageDtos.MessageSenderName,
				MessageSenderPhone = createMessageDtos.MessageSenderPhone,
				MessageSenderSurname = createMessageDtos.MessageSenderSurname,
				MessageSubject = createMessageDtos.MessageSubject,
			};
			_messageService.TInsert(message);
			return Ok("Mesaj başarıyla eklendi.");
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var values = _messageService.TGetById(id);
			_messageService.TDelete(values);
			return Ok("Başarıyla silindi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id) 
		{ 
			var values = _messageService.TGetById(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDtos)
		{
			Message message = new Message()
			{
				MessageID = updateMessageDtos.MessageID,
				MessageBody = updateMessageDtos.MessageBody,
				MessageSendDate = updateMessageDtos.MessageSendDate,
				MessageSenderEmail = updateMessageDtos.MessageSenderEmail,
				MessageSenderName = updateMessageDtos.MessageSenderName,
				MessageSenderPhone = updateMessageDtos.MessageSenderPhone,
				MessageSenderSurname = updateMessageDtos.MessageSenderSurname,
				MessageSubject = updateMessageDtos.MessageSubject,
			};
			_messageService.TUpdate(message);
			return Ok("Başarıyla güncellendi.");
		}
	}
}
