//İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabProDeneme
{
    public class Satici : Kullanici
    {

        
        public Satici(string isim, string sifre, int statu, string kIsim, string ePosta, string telNo) : base(isim, sifre, statu, kIsim, ePosta, telNo)
        {
        }
        
        


        public void aracEkle(List<Araba> arabalar)
        {
            string[] DonanimPaketleri = new string[2];
            int[] ParcaSayilari=new int[14];
            int[] ParcaSayilari2 = new int[14];

            Console.WriteLine("Eklemek istediğiniz aracın markasını giriniz.");
            Console.Write("Marka : ");
            string marka=Console.ReadLine();
            Console.WriteLine("Eklemek istediğiniz aracın modelini giriniz.");
            Console.Write("Model : ");
            string model = Console.ReadLine();
            Console.WriteLine("Eklemek istediğiniz aracın 1. Donanım paketinin adını giriniz.");
            Console.Write("1.Donanım paketi adı : ");
            string paket1 = Console.ReadLine();
            
            Console.Clear();
            for(int i=0; i<14; i++)
            {

                Console.WriteLine((i+1)+"-"+arabalar[0].donanimPaketi[0].yedekParca.parcaAdi[i]);
                Console.WriteLine("Bu parçaya ait stok sayısını giriniz.");
                Console.Write("Stok : ");
                int yeniStok= Convert.ToInt32(Console.ReadLine());
                if(yeniStok<9999 && 0<=yeniStok)
                {

                    ParcaSayilari[i] = yeniStok;

                }
                else
                {
                    Console.WriteLine("Hatalı giriş stok default değre atandı.");
                    ParcaSayilari[i] = 0;

                }
                //ParcaSayilari[i]=Convert.ToInt32(Console.ReadLine());

            }

            DonanimPaketi ilk = new DonanimPaketi(paket1, arabalar[0].donanimPaketi[0].yedekParca.parcaAdi, ParcaSayilari );
            Console.Clear();
            Console.WriteLine("Eklemek istediğiniz aracın 2. Donanım paketinin adını giriniz.");
            Console.Write("2.Donanım paketi adı : ");
            string paket2 = Console.ReadLine();

            Console.Clear();
            for (int i = 0; i < 14; i++)
            {

                Console.WriteLine((i + 1) + "-" + arabalar[0].donanimPaketi[0].yedekParca.parcaAdi[i]);
                Console.WriteLine("Bu parçaya ait stok sayısını giriniz.");
                Console.Write("Stok : ");
                int yeniStok2= Convert.ToInt32(Console.ReadLine());
                if(yeniStok2 < 9999 && 0 <=yeniStok2)
                {

                    ParcaSayilari2[i]= yeniStok2;

                }
                else
                {
                    Console.WriteLine("Hatalı giriş stok default değre atandı.");
                    ParcaSayilari2[i] = 0;

                }
                //ParcaSayilari2[i] = Convert.ToInt32(Console.ReadLine());

            }
            DonanimPaketi ikinci = new DonanimPaketi(paket2, arabalar[0].donanimPaketi[0].yedekParca.parcaAdi, ParcaSayilari2);
            Araba Yeni = new Araba(marka,model, new List<DonanimPaketi> { ilk, ikinci });
            arabalar.Add(Yeni);
            Console.Clear();
            Console.WriteLine("Yeni araç başarıyla eklendi");


        }

        public void stokGuncelle(List<Araba> Arabalar)
        {

            for (int i = 0; i < Arabalar.Count; i++)
            {

                Console.WriteLine((i + 1) + "-" + Arabalar[i].marka);

            }
            Console.WriteLine("Marka seçiniz");
            int secim = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("1-" + Arabalar[secim - 1].model);
            Console.WriteLine("Model Seçiniz");
            int secim2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("1-" + Arabalar[secim - 1].donanimPaketi[0].paketIsmi);
            Console.WriteLine("2-" + Arabalar[secim - 1].donanimPaketi[1].paketIsmi);
            Console.WriteLine("Donanım Seçiniz");
            int secim3 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < 14; i++)
            {


                Console.WriteLine((i + 1) + "-" + Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaAdi[i]+ "  Mevcut Stok : " + Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaSayisi[i]);
                

            }
            Console.WriteLine("Stoğunu değiştirmek istediğiniz parçayı seçiniz.");
            int parcaSecim = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Parçanın yeni stoğunu giriniz.");
            Console.Write("Yeni stok :");
            int yeniStok= Convert.ToInt32(Console.ReadLine());
            
            Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaSayisi[parcaSecim - 1] = yeniStok;

            Thread.Sleep(500);
            Console.WriteLine("Stok başarıyla Güncellendi.");




        }
    }
}
