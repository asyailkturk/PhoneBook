using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Entities
{
    public class ReportContext
    {
        //Konum Bilgisi
        public string Location { get; set; }

        //O konumda yer alan rehbere kayıtlı kişi sayısı
        public int ContactCount { get; set; }

        //O konumda yer alan rehbere kayıtlı telefon numarası sayısı
        public int PhoneNumberCount { get; set; }
    }
}

