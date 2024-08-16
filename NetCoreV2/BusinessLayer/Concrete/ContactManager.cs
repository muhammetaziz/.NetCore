using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetListAll();
        }

        public void TAdd(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Contact t)
        {
             _contactDal.Delete(t);
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);

        }

        public void TUpdate(Contact t)
        {
            throw new NotImplementedException();
        }
        public List<Contact> GetBlogById(int id)
        {
            return _contactDal.GetListAll(x => x.ContactID == id);
        }
    }
}
