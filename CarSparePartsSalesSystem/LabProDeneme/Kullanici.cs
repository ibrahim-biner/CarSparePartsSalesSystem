// İbrahim_Biner
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabProDeneme
{
     public class Kullanici
    {
        

        public string isim { get; set; }    
        public string sifre {  get; set; }
        public int statu { get; set; }

        public string kIsim { get; set; }
        public string ePosta { get; set; }
        public string telNo { get; set; }

        public List<Araba> arabalar {  get; set; }
     
        public Kullanici(string isim, string sifre, int statu, string kIsim, string ePosta, string telNo)
        {
            this.isim = isim;
            this.sifre = sifre;
            this.statu = statu;
            this.kIsim = kIsim;
            this.ePosta = ePosta;
            this.telNo = telNo;
        }

        public Kullanici() 
        { 
        
        }

        public void arabaSil(List<Araba> arabalar)
        {
            for (int i = 0; i < arabalar.Count; i++)
            {

                Console.WriteLine((i + 1) + "-" + arabalar[i].marka);

            }
            Console.WriteLine("Silmek istediğiniz araç markasını seçiniz");
            int secim = Convert.ToInt32(Console.ReadLine());

            //C:\\Users\\user\\Desktop\\bb\\
            string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";
            string[] satirlar = File.ReadAllLines(dosyaAdi);
            int sayac = 0;


            foreach (string satir in satirlar)
            {
                string[] bilgiler = satir.Split(',');


                if (bilgiler[4] == arabalar[secim - 1].marka && bilgiler[9] == "3")
                {

                    Console.WriteLine("Silmek istediğiniz araca ait yedek parça talepleri var lütfen ilk önce taleplere yanıt verin");
                    sayac++;
                    Thread.Sleep(1500);
                    Console.Clear();

                }




            }

            if (sayac == 0)
            {


                arabalar.RemoveAt(secim-1);
                Console.WriteLine("Seçilen Araç silindi.");
                Thread.Sleep(1500);

            }

            


        }



    }
}
