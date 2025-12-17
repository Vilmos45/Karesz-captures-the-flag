using System;
using System.Windows.Forms;

namespace Karesz
{
    public partial class Form1 : Form
    {
        static Random r = new Random();
        string betöltendő_pálya = "Palya01.txt";

        void TANÁR_ROBOTJAI()
        {

            #region TANÁR_FÜGGVÉNYEI
            void BaratsagosRobotSpawn()
            {
                int kh = r.Next(1, 30);
                while (pálya.MiVanItt(new Vektor(1, kh)) == fal)
                    kh = r.Next(1, 30);
                new Robot("Karesz", 0, 0, 0, 0, 5, 1, kh, r.Next(3));//5 hógolyóval indít
                int khk = r.Next(1, 30);
                r.Next(3);
                while (khk == kh || pálya.MiVanItt(new Vektor(1, khk)) == fal)
                    khk = r.Next(1, 30);
                new Robot("Janesz", 0, 0, 0, 0, 5, 1, khk, r.Next(3));
            }

            (Robot, Robot) EllensegesRobotSpawn()
            {
                int kh = r.Next(1, 30);
                while (pálya.MiVanItt(new Vektor(39, kh)) == fal) //még mindig spawnolhat a falba valamilyen misztikus okból...
                    kh = r.Next(1, 30);
                Robot gpnesz = new Robot("Gonesz", Robot.képkészlet_lilesz, 0, 0, 0, 1, 10, 39, kh, 3, 1, false);//10 hógolyóval indít
                int khk = r.Next(1, 30);
                while (khk == kh || pálya.MiVanItt(new Vektor(39, khk)) == fal)
                    khk = r.Next(1, 30);
                Robot gbnesz = new Robot("Ganesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 10, 39, khk, 3, 1, false);
                return (gpnesz, gbnesz);
            }

            void Támadás(Robot r)
            {
                while (true)
                    Lépj(r);
                //r.Lőjj();
            }

            bool Biztonságos_e(Robot r)
            {
                return !(r.Erre_jön_e_a_hógolyó() && (r.Milyen_messze_van_hógolyó() < 4 || r.Milyen_messze_van_hógolyó() == -1));
            }

            bool Biztonságos_e_lepni(Robot r, int irány = 0)
            {
                switch (irány)
                {
                    case -1:
                        int b = r.SzélesUltrahangSzenzor().Item1;
                        if (b > 1 || b == -1)
                            return true;
                        return false;
                    case 0:
                        int e = r.SzélesUltrahangSzenzor().Item2;
                        if (e > 1 || e == -1)
                            return true;
                        return false;
                    case 1:
                        int j = r.SzélesUltrahangSzenzor().Item3;
                        if (j > 1 || j == -1)
                            return true;
                        return false;
                    case 2:
                        r.Fordulj(balra);
                        b = r.SzélesUltrahangSzenzor().Item1;
                        r.Fordulj(jobbra);
                        if (b > 1 || b == -1)
                            return true;
                        return false;
                }
                return false;
            }

            void Lépj(Robot r, int n = 1, int irány = 0)
            {
                switch (irány)
                {
                    case -1:
                        r.Fordulj(balra);
                        break;
                    case 1:
                        r.Fordulj(jobbra);
                        break;
                    case 2:
                        r.Fordulj(balra);
                        r.Fordulj(balra);
                        break;
                    case -45:
                        return;
                }
                for (int i = 0; (i < n) && Biztonságos_e_lepni(r); i++)
                    r.Lépj();
                switch (irány)
                {
                    case -1:
                        r.Fordulj(jobbra);
                        break;
                    case 1:
                        r.Fordulj(balra);
                        break;
                    case 2:
                        r.Fordulj(jobbra);
                        r.Fordulj(jobbra);
                        break;
                }
                return;
            }

            void Vár(Robot r, int n)
            {
                for (int i = 0; i < n; i++)
                    r.Várj();
            }
            #endregion

            BaratsagosRobotSpawn();
            (Robot gonesz, Robot ganesz) = EllensegesRobotSpawn();

            bool nalunk_e_a_masik_zaszlo = false;
            bool meg_van_e_a_zaszlo = true;

            ganesz.Feladat = delegate //védelmező
            {
                while (true)
                {
                    if (!meg_van_e_a_zaszlo)
                    {
                        Támadás(ganesz);
                    }
                    /*if (!Baratsagos_e())
                    {
                        if (ganesz.Köveinek_száma_ebből(kék) == 0)
                            meg_van_e_a_zaszlo = false;
                    }*/
                    else if (!Biztonságos_e(ganesz))
                    {
                        int szI1 = ganesz.SzélesUltrahangSzenzor().Item1;
                        int szI3 = ganesz.SzélesUltrahangSzenzor().Item3;
                        Lépj(ganesz, 1, (szI1 > 0 || szI1 == -1) ? -1 : (szI3 > 0 || szI3 == -1) ? 1 : -45);
                        if (!Biztonságos_e(ganesz))
                            ganesz.Lőjj();
                    }
                    else
                    {
                        Vár(ganesz, 2);
                        ganesz.Fordulj(jobbra);
                    }

                }

            };

            gonesz.Feladat = delegate //támadó
            {
                while (true)
                {
                    if (!nalunk_e_a_masik_zaszlo)
                    {
                        Támadás(gonesz);
                        if (gonesz.Köveinek_száma_ebből(kék) == 1)
                            nalunk_e_a_masik_zaszlo = true;
                    }
                    if (!Biztonságos_e(gonesz))
                    {
                        int szI1 = gonesz.SzélesUltrahangSzenzor().Item1;
                        int szI3 = gonesz.SzélesUltrahangSzenzor().Item3;
                        Lépj(gonesz, 1, (szI1 > 0 || szI1 == -1) ? -1 : (szI3 > 0 || szI3 == -1) ? 1 : -45);
                        if (!Biztonságos_e(gonesz))
                            gonesz.Lőjj();
                    }
                    else
                    {
                        Vár(gonesz, 2);
                        gonesz.Fordulj(jobbra);
                    }
                }
            };
        }
    }
}