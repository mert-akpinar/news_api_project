using bitirme_projesi.BusinessLayer.Abstract;
using bitirme_projesi.DataAccessLayer.Abstract;
using bitirme_projesi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitirme_projesi.BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;
		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void TDelete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public Message TGetById(int id)
		{
			return _messageDal.GetById(id);
		}

		public List<Message> TGetListAll()
		{
			return _messageDal.GetListAll();
		}

		public void TInsert(Message entity)
		{
			_messageDal.Insert(entity);
		}

		public void TUpdate(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}
