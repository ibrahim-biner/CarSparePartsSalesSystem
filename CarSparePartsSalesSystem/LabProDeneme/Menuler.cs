//İbrahim_Biner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;

namespace LabProDeneme
{
    public class Menuler
    {
        List<Araba> Arabalar {  get; set; }
        List<Kullanici> Kullanicilar { get; set; }
        public Satici Saticilar { get; set; }
        public Kullanici kullanici { get; set; }
        public Yonetici yonetici { get; set; }

        public string kAdi {  get; set; }
        public Menuler(List<Araba> arabalar, List<Kullanici> kullanicilar,Satici saticilar,Yonetici yonetici1,string kadi)
        { 
          Arabalar = arabalar;
          Kullanicilar=kullanicilar;
          Saticilar= saticilar;
          yonetici=yonetici1;
          kAdi = kadi;
        }
        public Menuler() { }
        public int secim;



        //ListOfVehicles   AracListele
        public void ListOfVehicles()
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


                Console.WriteLine((i + 1) + "-" + Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaAdi[i]);

            }
            Console.WriteLine("Lütfen bir parça seçiniz.");
            int parcaSecim= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Parça Adı : "+Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaAdi[parcaSecim-1]);
            Console.WriteLine("Mevcut Stok : " + Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaSayisi[parcaSecim - 1]);
            Console.WriteLine("Satın almak istediğiniz miktarı giriniz.");
            Console.Write("Miktar :");
            int talepMiktar=Convert.ToInt32(Console.ReadLine());
            if(talepMiktar > 0 && talepMiktar<= Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaSayisi[parcaSecim - 1])
            {
                //kullanıcılar listesinde kadi ile ara bul indexini bütün bilgilerini sepet.txt e istediği parça ve sayısı ile kaydet
                int index = Kullanicilar.FindIndex(kullanici => kullanici.isim == kAdi);

                string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";
                using (StreamWriter writer = new StreamWriter(dosyaAdi,true))
                {


                    writer.WriteLine($"{Kullanicilar[index].isim},{Kullanicilar[index].kIsim},{Kullanicilar[index].ePosta},{Kullanicilar[index].telNo},{Arabalar[secim - 1].marka},{Arabalar[secim - 1].model},{Arabalar[secim - 1].donanimPaketi[secim3 - 1].paketIsmi},{Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaAdi[parcaSecim - 1]},{talepMiktar},3");

                }
                Console.Clear();
                Console.WriteLine("Satın alma talebi başarılı bir şekilde gönderildi");
                
                Console.WriteLine("\nİşleme devam etmek için (D) | Ana menüye dönmek için (A)  basınız");
                string aMenü = Console.ReadLine();
                if (aMenü == "A" || aMenü == "a")
                {
                    Console.Clear();
                    CustomerPage();
                }
                else if (aMenü == "D" || aMenü == "d")
                {
                    Console.Clear();
                    ListOfVehicles();

                }
                else
                {
                    Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                    Thread.Sleep(500);
                    Console.Clear();
                    ShowRequest();
                }
                
            }
            else
            {

                Console.WriteLine("Talep edilen miktar mevcut stok sayısından fazla ve sıfırdan küçük olmamalıdır.");
                Thread.Sleep(1500);
                Console.Clear();
                ListOfVehicles();

            }
            

        }
        // ShowCart  sepetGoster
        public void ShowCart(string kullaniciAdi)
        {
            //C:\\Users\\user\\Desktop\\bb\\
            string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";

            string[] satirlar = File.ReadAllLines(dosyaAdi);
            bool kullaniciBulundu = false;
            int sayac = 0;
            string durum="durum";
            Console.WriteLine("---------------SEPET---------------");
            foreach (string satir in satirlar)
            {
                string[] bilgiler = satir.Split(',');

                if (bilgiler.Length > 0 && bilgiler[0] == kullaniciAdi)
                {
                    kullaniciBulundu = true;
                    sayac++;
                    if (bilgiler[9] == "1")
                    {
                        durum = "Onaylandı";
                    }
                    else if(bilgiler[9] == "2")
                    {

                        durum = "Reddedildi";
                    }
                    else
                    {
                        durum = "Bekleniyor";
                    }
                        

                    Console.WriteLine($"{sayac}- Marka: {bilgiler[4]} | Model:{bilgiler[5]} | Paket:{bilgiler[6]} | Parça Adı: {bilgiler[7]} | Talep edilen miktar:{bilgiler[8]}| Sipariş Durumu : {durum}");
                    
                    
                }
            }

            if (!kullaniciBulundu)
            {
                Console.WriteLine("---------SEPETİNİZ BOŞ---------");
            }

            Console.WriteLine("Ana menüye dönmek için (A)  basınız");
            string aMenü =Console.ReadLine();
            if(aMenü=="A"||aMenü=="a")
            {
                Console.Clear();
                CustomerPage();
            }
            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                Thread.Sleep(500);
                Console.Clear();
                ShowCart(kAdi);
            }


        }

        

        //SignUp  KayitOl
        public void SignUp()
        {
            String KullaniciAdi = "ibrahim";
            String Sifre = "A11111111111";
            string kIsim = "1";
            string email="";
            string telNo = "";
            bool kontrol = true;

            while (kAdKontrol(KullaniciAdi))
            {
                Console.WriteLine("---------Kullanıcı Adı Kuralları---------");
                Console.WriteLine("1-Kullanıcı adı uzunluğu  5 ile 20 karakter arasında olmalıdır.");
                Console.WriteLine("2-Kullanıcı adı yalnızca nümerik veya alfabetik karakterler içerebilir.");
                Console.WriteLine("3-Kullanıcı adının ilk karakteri alfabetik karakter olmalıdır.\n");
                Console.WriteLine("Lütfen Sisteme Kayıt Olmak İstediğiniz Kullanıcı Adını Giriniz");
                Console.Write("Kullanıcı Adı : ");
                KullaniciAdi= Console.ReadLine();
                
                if(kAdKontrol(KullaniciAdi))
                {
                    Console.WriteLine("Girdiğiniz Kullanıcı Adı Siteme Kayıtlıdır.Lüttfen farklı bir kullanıcı adı giriniz.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                
                else if (string.IsNullOrWhiteSpace(KullaniciAdi))
                {
                    Console.WriteLine("Kullanıcı adı boş olamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();
                    KullaniciAdi = "ibrahim";
                    
                }
                else if(KullaniciAdi.Length<5 || KullaniciAdi.Length>20)
                {
                    Console.WriteLine("Kullanıcı adı 5 karakterden küçük, 20 karakterden büyük olamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();
                    KullaniciAdi = "ibrahim";

                }
                else if(!Char.IsLetter(KullaniciAdi[0]))
                {
                    Console.WriteLine("Kullanıcı adının ilk karakteri alfabetik karakter olmalıdır.");
                    Thread.Sleep(1600);
                    Console.Clear();
                    KullaniciAdi = "ibrahim";

                }
                else if(!Regex.IsMatch(KullaniciAdi, "^[a-zA-Z0-9]+$")) 
                {
                    Console.WriteLine("Kullanıcı adı yalnızca nümerik veya alfabetik karakterler içerebilir.");
                    Thread.Sleep(1600);
                    Console.Clear();
                    KullaniciAdi = "ibrahim";


                }
            }
            while(kontrol)
            {
                Console.WriteLine("---------Şifre Kuralları---------");
                Console.WriteLine("1-En az 8, en fazla 20 karakter içermelidir.Hiçbir boşluk içeremez");
                Console.WriteLine("2-En az bir rakam,en az bir büyük harf alfabesi,en az bir küçük harf alfabesi içermelidir.");
                Console.WriteLine("3-\"!@#$%&*-+\" karakterlerinden oluşan en az bir özel karakter içermelidir.\n");
                Console.WriteLine("Lürfen oluşturmak istediğiniz şifreyi girin");
                Console.Write("Şifre : ");
                Sifre = Console.ReadLine();

                if (Sifre.Length < 8 || Sifre.Length > 20)
                {
                    Console.WriteLine("Şifreniz 8 karakterden küçük, 20 karakterden büyük olamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    
                    continue;
                }
                else if(!Sifre.Any(char.IsDigit))
                {
                    Console.WriteLine("Şifreniz en az bir rakam içermelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(!Sifre.Any(char.IsUpper))
                {

                    Console.WriteLine("Şifreniz en az bir büyük harf içermelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(!Sifre.Any(char.IsLower))
                {
                    Console.WriteLine("Şifreniz en az bir küçük harf içermelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;


                }
                else if(!Sifre.Any(c => "!@#$%&*-+".Contains(c)))
                {

                    Console.WriteLine("Şifreniz ! @ # $ % & * - + karakterlerinden oluşan en az bir özel karakter içermelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(Sifre.Contains(" "))
                {

                    Console.WriteLine("Şifreniz boşluk içermemelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(string.IsNullOrWhiteSpace(Sifre))
                {
                    Console.WriteLine("Şifre alanı boş bırakılamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;


                }


                break;

            }

            while (kontrol)
            {
                Console.WriteLine("---------Kullanıcı isimi Kuralları---------");
                Console.WriteLine("1-Büyük veya küçük harfle başlamalıdır. 2-Özel karakter içermemelidir.\n");
                Console.WriteLine("Lürfen isminizi girin");
                Console.Write("İsim : ");
                kIsim = Console.ReadLine();
                
                
                if (string.IsNullOrWhiteSpace(kIsim))
                {
                    Console.WriteLine("Kullanıcı isimi  boş bırakılamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(kIsim.Contains("!") || kIsim.Contains("@") || kIsim.Contains("#") || kIsim.Contains("$") ||
            kIsim.Contains("%") || kIsim.Contains("&") || kIsim.Contains("*") || kIsim.Contains("-") ||
            kIsim.Contains("+"))
                {
                    Console.WriteLine("Kullanıcı isimi özel karakter içermemelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;



                }
                else if (kIsim.Length>0)
                {
                    char ilkKarakter = kIsim[0];
                    if (!(Char.IsLetter(ilkKarakter) && (Char.IsUpper(ilkKarakter) || Char.IsLower(ilkKarakter))))
                    {
                        Console.WriteLine("Kullanıcı isimi  büyük veya küçük harfle başlamalıdır.");
                        Thread.Sleep(1600);
                        Console.Clear();

                        continue;

                    }
                    

                }

                break;


            }
            while(kontrol)
            {
                Console.WriteLine("---------Kullanıcı e-posta Kuralları---------");
                Console.WriteLine("1-Özel karakterlerle başlatılamaz. 2- @ sembolü içermelidir.\n");
                Console.WriteLine("Kullanıcı e-mailini giriniz:");
                Console.Write("E-mail : ");
                email = Console.ReadLine();
                

                if (string.IsNullOrWhiteSpace(email))
                {

                    Console.WriteLine("Kullanıcı e-maili  boş bırakılamaz.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if(!email.Contains("@"))
                {
                    Console.WriteLine("Kullanıcı e-maili  @ sembolünü içermelidir.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;



                }
                else if(email.Length > 0)
                {
                    char ilkKarakter2 = email[0];
                    if (!Char.IsLetterOrDigit(ilkKarakter2))
                    {

                        Console.WriteLine("Kullanıcı e-maili  özel karakterlerle başlatılamaz.");
                        Thread.Sleep(1600);
                        Console.Clear();

                        continue;


                    }
                    


                }

                break;

            }
            while(kontrol)
            {
                Console.WriteLine("---------Kullanıcı telefon numarası Kuralları---------");
                Console.WriteLine("1- \"xxx-xxx-xxxx\" şeklinde olmalıdır. 2-Hiçbir harf içermemelidir.\n");
                Console.WriteLine("Kullanıcı telefon numarasını giriniz:");
                Console.Write("Tel No : ");
                telNo = Console.ReadLine();

                if(telNo.Length != 12)
                {
                    Console.WriteLine("Girilen telefon numarası belirtilen formata uymuyor.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;

                }
                else if (!Regex.IsMatch(telNo, @"^\d{3}-\d{3}-\d{4}$"))
                {

                    Console.WriteLine("Girilen telefon numarası belirtilen formata uymuyor.");
                    Thread.Sleep(1600);
                    Console.Clear();

                    continue;



                }
                else if(true)
                {
                    int sayac = 0;
                    foreach (char karakter in telNo)
                    {
                        if (!Char.IsDigit(karakter) && karakter != '-')
                        {
                            sayac++;
                            
                        }
                
                    }

                    if(sayac!=0)
                    {
                        Console.WriteLine("Telefon numarası sadece rakam içermelidir.");
                        Thread.Sleep(1600);
                        Console.Clear();

                        continue;

                    }

                    
                    
                }

                Kullanicilar.Add(new Kullanici(KullaniciAdi, Sifre, 1, kIsim, email, telNo));
                SaveUser(Kullanicilar);
                break;
             
            }
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Kullanıcı başarıyla oluşturuldu.");
            Thread.Sleep(1000);
            Console.Clear();
            LoginPage();

        }

        
        public bool kAdKontrol(string yKulaniciAdi)
        {
            string dosyaYolu = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\kullanicilar.txt";// C:\\Users\\user\\Desktop\\bb\\kullanicilar.txt
            string[] satirlarr = File.ReadAllLines(dosyaYolu);
            foreach (var satir in satirlarr)
            {
                string[] dosyaKullaniciAdlari = satir.Split(',');

                if (dosyaKullaniciAdlari[0] == yKulaniciAdi)  
                {
                    return true; 
                }
            }
            return false;
        }




        //GirisEkrani LoginPage

        public void LoginPage()
        {

            Console.WriteLine("------------BNR Yedek Parçaya Hoşgeldiniz----------\n ");
            Console.WriteLine("1- Müşteri Giriş");
            Console.WriteLine("2- Satıcı Giriş");
            Console.WriteLine("3- Admin Giriş");
            Console.WriteLine("4- Kayıt Ol");
            Console.WriteLine("\n***Yapmak istediğiniz işlemi seçiniz***");
            secim = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(350);
            Console.Clear();
            
            switch (secim)

            {
                case 1:

                    if (this.KullanciGirisEkrani())
                    {
                        this.CustomerPage();

                    }
                    else
                    {
                        while (!this.KullanciGirisEkrani())
                            this.KullanciGirisEkrani();

                        this.CustomerPage();
                    }


                    break;
                case 2:
                    if (this.KullanciGirisEkrani())
                    {

                        this.SellerPage();
                    }
                    else
                    {
                        while (!this.KullanciGirisEkrani())
                            this.KullanciGirisEkrani();

                        this.SellerPage();
                    }
                    break;
                case 3:

                    if (this.KullanciGirisEkrani())
                    {

                        this.AdminEkrani();

                    }
                    else
                    {
                        while (!this.KullanciGirisEkrani())
                            this.KullanciGirisEkrani();

                        this.AdminEkrani();
                    }


                    break;

                case 4:
                    SignUp();
                        break;
                default:
                    Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz.");
                    LoginPage();
                    break;

            }


        }
        //CustomerPage  MusteriEkrani
        public void CustomerPage()
        {

            Console.WriteLine("------------BNR Yedek Parçaya Hoşgeldiniz---------- ");
            Console.WriteLine("1- Yedek Parça Ara");
            Console.WriteLine("2- Sepetim");
            Console.WriteLine("3- Hesabı Sil");
            Console.WriteLine("4- Çıkış Yap");

            secim = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(350);
            Console.Clear();

            switch (secim)

            {
                case 1:


                    ListOfVehicles();
                    CustomerPage();

                    break;
                case 2:
                    ShowCart(kAdi);
                    break;
                case 3:
                    DeleteAccount(Kullanicilar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();
                    LoginPage();

                    break;
                case 4:
                    Console.WriteLine("Çıkış yapılıyor...");
                    Thread.Sleep(350);
                    Console.Clear();
                    
                    this.LoginPage();

                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız");
                    break;

            }


        }
        //SellerPage   SaticiEkrani
        public void SellerPage()
        {

            Console.WriteLine("------------BNR Yedek Parçaya Hoşgeldiniz---------- ");
            Console.WriteLine("1- Araç Ekle");
            Console.WriteLine("2- Araç Sil");
            Console.WriteLine("3- Mevcut Stoğu Gör");
            Console.WriteLine("4- Stok Güncelle");
            Console.WriteLine("5- Satın Alma Talepelerini Gör");
            Console.WriteLine("6- Hesabı Sil");
            Console.WriteLine("7- Çıkış Yap");

            secim = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(350);
            Console.Clear();

            switch (secim)

            {
                case 1:
                    
                    Saticilar.aracEkle(Arabalar);
                    SaveCars(Arabalar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();

                    SellerPage();
                    break;
                case 2:
                    Saticilar.arabaSil(Arabalar);
                    SaveCars(Arabalar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();

                    SellerPage();

                    break;
                case 3:
                    ShowStock();

                    break;
                case 4:
                    Saticilar.stokGuncelle(Arabalar);
                    SaveCars(Arabalar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();

                    SellerPage();

                    break;
                case 5:
                    ShowRequest();
                    break;
                case 6:
                    DeleteAccount(Kullanicilar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();
                    LoginPage();

                    break;
                case 7:
                    Console.WriteLine("Çıkış yapılıyor...");
                    Thread.Sleep(350);
                    Console.Clear();
                    this.LoginPage();
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız");
                    SellerPage();
                    break;

            }


        }

        public void AdminEkrani()
        {

            Console.WriteLine("------------BNR Yedek Parçaya Hoşgeldiniz---------- ");
            Console.WriteLine("1- Araç Sil");
            Console.WriteLine("2- Satıcı Sil");
            Console.WriteLine("3- Müşteri Sil");
            Console.WriteLine("4- Çıkış Yap");

            secim = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(350);
            Console.Clear();

            switch (secim) 
            {
                case 1:
                    yonetici.arabaSil(Arabalar);
                    SaveCars(Arabalar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(750);
                    Console.Clear();
                    AdminEkrani();
                    break;
                case 2:
                    yonetici.saticiSil(Kullanicilar);
                    SaveUser(Kullanicilar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(900);
                    Console.Clear();
                    AdminEkrani();
                    break;
                case 3:
                    yonetici.musteriSil(Kullanicilar);
                    SaveUser(Kullanicilar);
                    Console.WriteLine("Ana menüye yönlerndiriliyorsunuz...");
                    Thread.Sleep(900);
                    Console.Clear();
                    AdminEkrani();
                    break;
                case 4:
                    Console.WriteLine("Çıkış yapılıyor...");
                    Thread.Sleep(350);
                    Console.Clear();
                    this.LoginPage();
                    break;
                default :
                    Console.WriteLine("Hatalı Seçim Yaptınız");
                    break;
                    


            }


        }



        public bool KullanciGirisEkrani()
        {
            Console.WriteLine("Kullanıcı Adı:");
            string kullaniciAdi = Console.ReadLine();


            Console.WriteLine("Şifrenizi girin: ");

            string sifre = "";

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                
                if (char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar) || char.IsSymbol(key.KeyChar))
                {
                    sifre += key.KeyChar;
                    Console.Write("*");
                }
                
                else if (key.Key == ConsoleKey.Backspace && sifre.Length > 0)
                {
                    sifre = sifre.Substring(0, sifre.Length - 1);
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();


            string dosyaYolu = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\kullanicilar.txt"; //C:\\Users\\user\\Desktop\\bb\\kullanicilar.txt

            if (KullaniciGirisKontrolu(kullaniciAdi, sifre, secim.ToString(), dosyaYolu))
            {
                kAdi = kullaniciAdi;
                Thread.Sleep(750);
                Console.WriteLine("Giriş Başarılı!");
                Thread.Sleep(450);
                Console.Clear();

                return true;
                
            }
            else
            {
                Thread.Sleep(750);
                Console.WriteLine("Hatalı Kullanıcı Adı veya Şifre! Lütfen Tekrar Deneyiniz ! ");
                Thread.Sleep(1500);
                Console.Clear();
                Thread.Sleep(600);
                return false;
            }
        }




        public bool KullaniciGirisKontrolu(string kullaniciAdi, string sifre, string statu, string dosyaYolu)
        {
           
            string[] satirlar = File.ReadAllLines(dosyaYolu);

            foreach (var satir in satirlar)
            {
                string[] bilgiler = satir.Split(',');

                if (bilgiler.Length == 6 &&
                    bilgiler[0].Trim() == kullaniciAdi &&
                    bilgiler[1].Trim() == sifre &&
                    bilgiler[2].Trim() == statu)
                {
                    return true; 
                }
            }

            return false; 
        }

        //SaveCars  saveArabalar
        public void SaveCars(List<Araba> arabalar)
        {
            string filePath = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\Arablar3.txt"; //C:\\Users\\user\\Desktop\\bb\\Arablar3.txt
            List<string> lines = new List<string>();

            foreach (var araba in arabalar)
            {
                foreach (var paket in araba.donanimPaketi)
                {
                    string parcaStokLine = $"{string.Join(",", Enumerable.Range(0, paket.yedekParca.parcaAdi.Length).Select(i => $"{paket.yedekParca.parcaAdi[i]}[{paket.yedekParca.parcaSayisi[i]}]"))}";
                    lines.Add($"{araba.marka}|{araba.model}|{paket.paketIsmi}|{parcaStokLine}");
                }
            }

            File.WriteAllLines(filePath, lines);
        }
        //LoadCars  loadArabalar
        public List<Araba> LoadCars()
        {
            List<Araba> arabalar = new List<Araba>();
            string filePath = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\Arablar3.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    string marka = parts[0];
                    string model = parts[1];
                    string paketAdi = parts[2];

                    string[] parcaStokPairs = parts[3].Split(',');

                    
                    string[] parcaIsimleri = new string[parcaStokPairs.Length];
                    int[] stoklar = new int[parcaStokPairs.Length];

                    for (int i = 0; i < parcaStokPairs.Length; i++)
                    {
                        string[] pairParts = parcaStokPairs[i].Split('[');
                        parcaIsimleri[i] = pairParts[0];

                        
                        int stok;
                        if (int.TryParse(pairParts[1].Replace("]", ""), out stok))
                        {
                            stoklar[i] = stok;
                        }
                        else
                        {
                            
                            stoklar[i] = 0; 
                        }
                    }

                    DonanimPaketi paket = new DonanimPaketi(paketAdi, parcaIsimleri, stoklar);

                    Araba existingAraba = arabalar.Find(a => a.marka == marka && a.model == model);
                    if (existingAraba != null)
                    {
                        existingAraba.donanimPaketi.Add(paket);
                    }
                    else
                    {
                        Araba araba = new Araba(marka, model, new List<DonanimPaketi> { paket });
                        arabalar.Add(araba);
                    }
                }
            }

            return arabalar;
        }
        //SaveUser dosyayaYaz
        public void SaveUser(List<Kullanici> kullaniciListesi)
        {
            string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\kullanicilar.txt";
            using (StreamWriter writer = new StreamWriter(dosyaAdi))
            {
                foreach (var kullanici in kullaniciListesi)
                {
                    writer.WriteLine($"{kullanici.isim},{kullanici.sifre},{kullanici.statu},{kullanici.kIsim},{kullanici.ePosta},{kullanici.telNo}");
                }
            }
        }
        //LoadUser  dosyadanOku
        public List<Kullanici> LoadUser()
        {
            List<Kullanici> okunanKullanicilar = new List<Kullanici>();
            string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\kullanicilar.txt";
            using (StreamReader reader = new StreamReader(dosyaAdi))
            {
                while (!reader.EndOfStream)
                {
                    string[] satir = reader.ReadLine().Split(',');

                    if (satir.Length == 6)
                    {
                        string isim = satir[0];
                        string sifre = satir[1];
                        int durum = Convert.ToInt32(satir[2]);
                        string kIsim = satir[3];
                        string ePosta = satir[4];
                        string telNo = satir[5];

                        Kullanici kullanici = new Kullanici(isim, sifre, durum, kIsim, ePosta, telNo);
                        okunanKullanicilar.Add(kullanici);
                    }
                }
            }

            return okunanKullanicilar;
        }
        //DeleteAccount  hesapSil
        public void DeleteAccount(List<Kullanici>kullanicilar)
        {
            Kullanicilar = LoadUser();
            Console.WriteLine("Lütfen hesap silme işlemini onaylamak için Kullanıcı adı ve şifrenizi giriniz.");
            Console.Write("Kullanıcı adı : ");
            string kullaniciAdi=Console.ReadLine();
            Console.Write("Şifre :");
            string kSifre=Console.ReadLine();
            Console.Clear();
            int index = -1;

            string[] satirlar = File.ReadAllLines("C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\kullanicilar.txt");

            foreach (var satir in satirlar)
            {
                string[] bilgiler = satir.Split(',');

                if (bilgiler[0].Trim() == kullaniciAdi && bilgiler[1].Trim() == kSifre)
                {
                     index = Kullanicilar.FindIndex(kullanici => kullanici.isim==kullaniciAdi);
                }
            }

            if(index!=-1)
            {

                Kullanicilar.RemoveAt(index);
                Console.WriteLine("Hesap başaryla silinmiştir.");
                Thread.Sleep(800);
                SaveUser(Kullanicilar);

            }
            else
            {
                Console.WriteLine("Girilen kullanıcı adı veya şifre hatalı tekrar deneyiniz.");
                DeleteAccount(kullanicilar); 
            }

        }
        //ShowRequest talepGor
        public void ShowRequest()
        {
            string dosyaAdi = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";

            
            string[] satirlar = File.ReadAllLines(dosyaAdi);
            
            int sayac = 0;
            int sayac2 = 0;
            int index = 0;
          
            Console.WriteLine("---------------Satın Alma Talepleri---------------");
            foreach (string satir in satirlar)
            {
                string[] bilgiler = satir.Split(',');
                
                if (bilgiler[9]=="3")
                {
                    sayac++;
                    index = sayac2;
                    Console.WriteLine($"{sayac2}- İsim: {bilgiler[1]} E-posta: {bilgiler[2]} Tel No: {bilgiler[3]} Marka: {bilgiler[4]} | Model:{bilgiler[5]} | Paket:{bilgiler[6]} | Parça Adı: {bilgiler[7]} | Talep edilen miktar:{bilgiler[8]}|");

                }
                

                sayac2++;
                


            }
            if(sayac==0)
            {

                Console.WriteLine("\n *************Mevcut satın alma talebi yok***********");
                Console.WriteLine("\nAna menüye yönlerndiriliyorsunuz...");
                Thread.Sleep(1500);
                Console.Clear();
                SellerPage();

            }
            Console.WriteLine("İşlem yapmak istediğinz talep numarasını giriniz :");
            int talepNo=Convert.ToInt32(Console.ReadLine());
            string[] bilgiler2=satirlar[talepNo].Split(',');
            int aracIndex =-1;
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz : Onayla(1) | Reddet(2)");
            int islem=Convert.ToInt32(Console.ReadLine());
            int j = 0;
            if(islem==1)
            {
                int deger = 0;
                for(j=0;j<2;j++)
                {

                    aracIndex = Arabalar.FindIndex(arac => arac.marka == bilgiler2[4] && arac.model == bilgiler2[5] && arac.donanimPaketi[j].paketIsmi == bilgiler2[6]);
                    if(aracIndex!=-1)
                    {
                        deger = j;
                        break;
                    }

                }



                for (int i = 0; i < Arabalar[aracIndex].donanimPaketi[deger].yedekParca.parcaAdi.Length; i++) 
                    {
                        if (Arabalar[aracIndex].donanimPaketi[deger].yedekParca.parcaAdi[i] == bilgiler2[7])
                        {

                            Arabalar[aracIndex].donanimPaketi[deger].yedekParca.parcaSayisi[i]= Arabalar[aracIndex].donanimPaketi[deger].yedekParca.parcaSayisi[i] - Convert.ToInt32(bilgiler2[8]);
                        SaveCars(Arabalar);
                            break;
                        }
                    
                    }

                  

                satirlar[talepNo] = ($"{bilgiler2[0]},{bilgiler2[1]},{bilgiler2[2]},{bilgiler2[3]},{bilgiler2[4]},{bilgiler2[5]},{bilgiler2[6]},{bilgiler2[7]},{bilgiler2[8]},1");

                string dosyaYolu = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";
              
                File.WriteAllLines(dosyaYolu, satirlar);

                

            }
            else
            {
                satirlar[talepNo] = ($"{bilgiler2[0]},{bilgiler2[1]},{bilgiler2[2]},{bilgiler2[3]},{bilgiler2[4]},{bilgiler2[5]},{bilgiler2[6]},{bilgiler2[7]},{bilgiler2[8]},2");

                string dosyaYolu2 = "C:\\Users\\user\\Desktop\\gituhb\\CarSparePartsSalesSystem\\sepet.txt";

                File.WriteAllLines(dosyaYolu2, satirlar);



            }

            




            Console.WriteLine("İşleme devam etmek için (D) | Ana menüye dönmek için (A)  basınız");
            string aMenü = Console.ReadLine();
            if (aMenü == "A" || aMenü == "a")
            {
                Console.Clear();
                SellerPage();
            }
            else if(aMenü == "D" || aMenü == "d")
            {
                Console.Clear();
                ShowRequest();

            }
            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                Thread.Sleep(500);
                Console.Clear();
                ShowRequest();
            }




        }
        //ShowStock stokGor
        public void ShowStock()
        {
            Arabalar = LoadCars();
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


                Console.WriteLine((i + 1) + "-" + Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaAdi[i]+" | "+" Miktar :"+ Arabalar[secim - 1].donanimPaketi[secim3 - 1].yedekParca.parcaSayisi[i]);

            }

            Console.WriteLine("\nAna menüye dönmek için (A)  basınız");
            string aMenü = Console.ReadLine();
            if (aMenü == "A" || aMenü == "a")
            {
                Console.Clear();
                SellerPage();
            }
            else
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız.");
                Thread.Sleep(500);
                Console.Clear();
                ShowStock();
            }



        }

    }
}
