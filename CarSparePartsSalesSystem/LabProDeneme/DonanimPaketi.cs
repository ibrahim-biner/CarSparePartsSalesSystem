//İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProDeneme
{
    public class DonanimPaketi
    {
        

        public string paketIsmi {  get; set; }
        public YedekParca yedekParca { get; set; }

        public DonanimPaketi(string paketIsmi, string[] parcaAdi, int[] parcaSayisi)
        {
            this.paketIsmi = paketIsmi;
            yedekParca = new YedekParca(parcaAdi,parcaSayisi);
        }
    }
}
