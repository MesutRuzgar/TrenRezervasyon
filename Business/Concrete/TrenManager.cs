using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TrenManager : ITrenService
    {
        ITrenDal _trenDal;

        public TrenManager(ITrenDal trenDal)
        {
            _trenDal = trenDal;
        }

        public List<TrenDTO> Trenler()
        {
            return _trenDal.TrenDetaylari();
        }
    }
}
