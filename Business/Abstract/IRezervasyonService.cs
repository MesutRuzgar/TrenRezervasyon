﻿using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRezervasyonService
    {
        RezervasyonSonucDTO Kontrol(RezervasyonDTO p);
    }
}
