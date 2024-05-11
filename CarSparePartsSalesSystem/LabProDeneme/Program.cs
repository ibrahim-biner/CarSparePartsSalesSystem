//İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;




namespace LabProDeneme
{
    internal class Program
    {
       


        static void Main(string[] args)
        {
            DonanimPaketi comfort= new DonanimPaketi("Comfort", new[] {"Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası","Vites Kutusu","Amortisör","Şanzıman","Şaft","Ön cam","kanat Aynası","Egzoz","Buji","Debriyaj Balatası" }, new[] {250,250,250,250,250,250,250,250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Exclusive = new DonanimPaketi("Exclusive", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Toyota =new Araba("Toyota","corolla",new List<DonanimPaketi> {comfort,Exclusive});

            DonanimPaketi Msport = new DonanimPaketi("Msport", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Sport = new DonanimPaketi("Sport", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Bmw = new Araba("BMW", "M4", new List<DonanimPaketi> { Msport, Sport });

            DonanimPaketi Highline = new DonanimPaketi("HighLine", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Lux = new DonanimPaketi("Lux", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Volswagen = new Araba("Volswagen", "Passat", new List<DonanimPaketi> { Highline, Lux });

            DonanimPaketi Easy = new DonanimPaketi("Easy", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Multi = new DonanimPaketi("Multi", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Volvo = new Araba("Volvo", "Xc90", new List<DonanimPaketi> { Easy, Multi });

            DonanimPaketi Street = new DonanimPaketi("Street", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Urban = new DonanimPaketi("Urban", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Fiat = new Araba("Fiat", "Egea", new List<DonanimPaketi> { Street, Urban });

            DonanimPaketi Ambiance = new DonanimPaketi("Ambiance", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Stepway = new DonanimPaketi("Stepway", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Dacia = new Araba("Dacia", "Sandero", new List<DonanimPaketi> { Ambiance, Stepway });

            DonanimPaketi Advanced = new DonanimPaketi("Advanced ", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Dynamic = new DonanimPaketi("Dynamic", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Audi = new Araba("Audi", "A6", new List<DonanimPaketi> { Advanced, Dynamic });

            DonanimPaketi Sx = new DonanimPaketi("SX ", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Confort = new DonanimPaketi("Confort", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Citroen = new Araba("Citroen", "C3", new List<DonanimPaketi> { Sx, Confort });

            DonanimPaketi Active = new DonanimPaketi("Active", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Elit = new DonanimPaketi("Elit", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Skoda = new Araba("Skoda", "Superb", new List<DonanimPaketi> { Active, Elit });

            DonanimPaketi Rs = new DonanimPaketi("Rs", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            DonanimPaketi Sclub = new DonanimPaketi("Sclub", new[] { "Motor", "Motor Kaputu", "Far", "Fren Diski", "Fren Balatası", "Vites Kutusu", "Amortisör", "Şanzıman", "Şaft", "Ön cam", "kanat Aynası", "Egzoz", "Buji", "Debriyaj Balatası" }, new[] { 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250, 250 });
            Araba Porsche = new Araba("Porsche", "GT3", new List<DonanimPaketi> { Rs, Sclub });

            Menuler menu1=new Menuler();

            List<Araba> arabalar = new List<Araba>();

            arabalar = menu1.LoadCars();

            if (arabalar.Count == 0)
            {
                arabalar.Add(Toyota);
                arabalar.Add(Bmw);
                arabalar.Add(Volswagen);
                arabalar.Add(Volvo);
                arabalar.Add(Fiat);
                arabalar.Add(Dacia);
                arabalar.Add(Audi);
                arabalar.Add(Citroen);
                arabalar.Add(Skoda);
                arabalar.Add(Porsche);


                menu1.SaveCars(arabalar);
            }



            
            Yonetici yonetici = new Yonetici("1","5",5,"D","K","85");
            Satici satici=new Satici("1", "5", 5, "D", "K", "85");
            Kullanici kullanici = new Kullanici();

            List<Kullanici> kullanicilar = new List<Kullanici>();

            kullanicilar = menu1.LoadUser();
            
            
            if (kullanicilar.Count==0)
            {
                Kullanici musteri1 = new Kullanici("ibrahim", "Sifre19*", 1, "İbrahim", "ibrahim@hotmail", "253-045-8789");
                Kullanici musteri2 = new Kullanici("musatfa", "Sifre19*", 1, "Musatfa", "musatfa@hotmail", "253-045-8789");
                Kullanici satici1 = new Kullanici("mehmet", "Sifre19*", 2, "Mehmet", "mehmet@hotmail", "253-045-8789");
                Kullanici satici2 = new Kullanici("murat", "Sifre19*", 2, "Murat", "murat@hotmail", "253-045-8789");
                Kullanici admin1 = new Kullanici("alperen", "Sifre19*", 3, "Alperen", "alperen@hotmail", "253-045-8789");
                kullanicilar.Add(admin1);
                kullanicilar.Add(satici1);
                kullanicilar.Add(satici2);
                kullanicilar.Add(musteri1);
                kullanicilar.Add(musteri2);
                
            }

            

            Menuler menu = new Menuler(arabalar, kullanicilar, satici, yonetici, "");
            
            menu.SaveUser(kullanicilar);
            
            
            menu.LoginPage();
           
            menu.SaveCars(arabalar);
            menu.SaveUser(kullanicilar);

            
            

        }
    }
}
 