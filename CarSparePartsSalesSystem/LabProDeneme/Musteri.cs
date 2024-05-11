//İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProDeneme
{
    public class Musteri : Kullanici
    {
        public Musteri(string isim, string sifre, int statu, string kIsim, string ePosta, string telNo) : base(isim, sifre, statu, kIsim, ePosta, telNo)
        {
        }


    }
}
