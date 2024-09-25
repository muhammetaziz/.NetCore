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
    public class NatificationManager : INatificationService
    {
        INatificationDal _natificationDal;

        public NatificationManager(INatificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }

        public List<Natification> GetList()
        {
            return _natificationDal.GetListAll();
        }

        public void TAdd(Natification t)
        {
            _natificationDal.Insert(t);
        }

        public void TDelete(Natification t)
        {
            _natificationDal.Delete(t);
        }

        public Natification TGetById(int id)
        {
            return _natificationDal.GetById(id);
        }

        public void TUpdate(Natification t)
        {
            _natificationDal.Update(t);
        }
    }
}
