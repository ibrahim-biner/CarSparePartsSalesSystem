// İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LabProDeneme
{
    public class Yonetici : Kullanici
    {
        public Yonetici(string isim, string sifre, int statu, string kIsim, string ePosta, string telNo) : base(isim, sifre, statu, kIsim, ePosta, telNo)
        {
        }

        public void musteriSil(List<Kullanici>kullanicilar )
        {

            List<Kullanici> musteriListesi = kullanicilar.Where(kullanici => kullanici.statu == 1).ToList();

            int siraNo = 1;
            foreach (var kullanici in musteriListesi)
            {
                Console.WriteLine($"{siraNo}. Kullanıcı Adı: {kullanici.isim}, Şifresi: {kullanici.sifre}, İsimi: {kullanici.kIsim}, E-posta :{kullanici.ePosta},Tel No :{kullanici.telNo} ");
                siraNo++;
            }

            Console.WriteLine("Hesabını silmek istediğiniz müşteriyi seçiniz");
            int secim=Convert.ToInt32(Console.ReadLine());
            string silinecekIsim = musteriListesi[secim - 1].isim;

            Kullanici silinecekKullanici = kullanicilar.Find(kullanici => kullanici.isim == silinecekIsim);
              
            kullanicilar.Remove(silinecekKullanici);
            Console.WriteLine("Seçilen kullanıcı silindi.");
            


        }

        public void saticiSil(List<Kullanici> kullanicilar)
        {

            List<Kullanici> saticiListesi = kullanicilar.Where(kullanici => kullanici.statu == 2).ToList();

            int siraNo = 1;
            foreach (var kullanici in saticiListesi)
            {
                Console.WriteLine($"{siraNo}. Kullanıcı Adı: {kullanici.isim}, Şifresi: {kullanici.sifre}, İsimi: {kullanici.kIsim}, E-posta :{kullanici.ePosta},Tel No :{kullanici.telNo} ");
                siraNo++;
            }

            Console.WriteLine("Hesabını silmek istediğiniz satıcıyı seçiniz");
            int secim = Convert.ToInt32(Console.ReadLine());
            string silinecekIsim = saticiListesi[secim - 1].isim;

            Kullanici silinecekKullanici = kullanicilar.Find(kullanici => kullanici.isim == silinecekIsim);

            kullanicilar.Remove(silinecekKullanici);
            Console.WriteLine("Seçilen satıcı silindi.");

        }

       
    }
}
