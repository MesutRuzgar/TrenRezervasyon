using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RezervasyonManager : IRezervasyonService
    {
        ITrenDal _trenDal;

        public RezervasyonManager(ITrenDal trenDal)
        {
            _trenDal = trenDal;
        }

        public RezervasyonSonucDTO Kontrol(RezervasyonDTO p)
        {
            var tren = _trenDal.TrenDetaylari();
            p.Tren = tren;

            RezervasyonSonucDTO sonuc = new RezervasyonSonucDTO()
            {
                RezervasyonYapilabilir = false,
                YerlesimAyrinti = new List<YerlesimAyrintiDTO>()
            };

            List<VagonDTO> uygunVagon = new List<VagonDTO>();

            foreach (var t in p.Tren)
            {
                foreach (var vagon in t.Vagonlar)
                {
                    int bosKoltuk = vagon.Kapasite - vagon.DoluKoltukAdet;
                    if (bosKoltuk <= vagon.Kapasite * 0.7 && bosKoltuk > 0)
                    {
                        uygunVagon.Add(vagon);
                    }
                }
            }
            if (uygunVagon.Count > 0 && p.KisilerFarkliVagonlaraYerlestirilebilir == true)
            {
                sonuc.RezervasyonYapilabilir = true;
                foreach (var item in uygunVagon)
                {
                    int vagonMaxRezervasyonSayisi = Convert.ToInt32(item.Kapasite * 0.7);
                    int bosKoltuk = vagonMaxRezervasyonSayisi - item.DoluKoltukAdet;
                    if (p.RezervasyonYapilacakKisiSayisi > 0)
                    {
                        if (p.RezervasyonYapilacakKisiSayisi >= bosKoltuk)
                        {
                            int digerVagonaKalanKisiSayisi = p.RezervasyonYapilacakKisiSayisi - bosKoltuk;
                            int vagonaYerlesenKisiSayisi = p.RezervasyonYapilacakKisiSayisi - digerVagonaKalanKisiSayisi;
                            if (bosKoltuk > 0)
                            {
                                sonuc.YerlesimAyrinti.Add(new YerlesimAyrintiDTO
                                {
                                    VagonAdi = item.Ad,
                                    KisiSayisi = vagonaYerlesenKisiSayisi
                                });
                                p.RezervasyonYapilacakKisiSayisi = digerVagonaKalanKisiSayisi;
                            }
                        }
                        else
                        {
                            sonuc.YerlesimAyrinti.Add(new YerlesimAyrintiDTO
                            {
                                VagonAdi = item.Ad,
                                KisiSayisi = p.RezervasyonYapilacakKisiSayisi
                            });
                            p.RezervasyonYapilacakKisiSayisi = 0;
                        }
                    }
                    else
                    {
                        if (sonuc.YerlesimAyrinti.Count <= 0)
                        {
                            sonuc.RezervasyonYapilabilir = false;
                        }
                        return sonuc;
                    }
                }
            }
            else if (uygunVagon.Count > 0 && p.KisilerFarkliVagonlaraYerlestirilebilir == false)
            {
                sonuc.RezervasyonYapilabilir = true;
                foreach (var item in uygunVagon)
                {
                    int vagonMaxRezervasyonSayisi = Convert.ToInt32(item.Kapasite * 0.7);
                    int bosKoltuk = vagonMaxRezervasyonSayisi - item.DoluKoltukAdet;
                    if (p.RezervasyonYapilacakKisiSayisi > 0)
                    {
                        if (p.RezervasyonYapilacakKisiSayisi > bosKoltuk)
                        {
                            sonuc.RezervasyonYapilabilir = false;
                        }
                        else
                        {
                            sonuc.YerlesimAyrinti.Add(new YerlesimAyrintiDTO
                            {
                                VagonAdi = item.Ad,
                                KisiSayisi = p.RezervasyonYapilacakKisiSayisi
                            });
                            p.RezervasyonYapilacakKisiSayisi = 0;
                        }
                    }
                    else
                    {
                        if (sonuc.YerlesimAyrinti.Count <= 0)
                        {
                            sonuc.RezervasyonYapilabilir = false;
                        }
                        return sonuc;
                    }
                }
            }
            else
            {
                return sonuc;
            }

            if (p.RezervasyonYapilacakKisiSayisi > 0)
            {
                sonuc.RezervasyonYapilabilir = false;
                sonuc.YerlesimAyrinti = new List<YerlesimAyrintiDTO>();
            }
            return sonuc;
        }


    }

}



