using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfTrenDal : ITrenDal
    {
        public List<TrenDTO> TrenDetaylari()
        {
            using (Context context = new Context())
            {
                var result = from t in context.Trenler                             
                             select new TrenDTO
                             {
                                 Ad = t.Ad,
                                 Vagonlar = (from i in context.Vagonlar
                                             where i.TrenID == t.TrenID
                                             select new VagonDTO
                                             {
                                                 Ad = i.Ad,
                                                 Kapasite = i.Kapasite,
                                                 DoluKoltukAdet = i.DoluKoltukAdet
                                             }).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
