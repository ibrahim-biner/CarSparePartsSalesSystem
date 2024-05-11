// İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProDeneme
{
    public class Araba
    {
        
        public string marka {  get; set; }
        public string model { get; set; }
        public List<DonanimPaketi> donanimPaketi {  get; set; }

        public Araba(string marka, string model, List<DonanimPaketi> donanimPaketi)
        {
            this.marka = marka;
            this.model = model;
            this.donanimPaketi = donanimPaketi;
        }





    }
}
