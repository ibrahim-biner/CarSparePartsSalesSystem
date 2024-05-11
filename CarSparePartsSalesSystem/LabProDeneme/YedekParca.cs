// İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProDeneme
{
    public class YedekParca
    {
       

        public string[] parcaAdi {  get; set; }
        public int[] parcaSayisi { get; set; }

        public YedekParca(string[] parcaAdi, int[] parcaSayisi)
        {
            this.parcaAdi = parcaAdi;
            this.parcaSayisi = parcaSayisi;
        }
    }
}
