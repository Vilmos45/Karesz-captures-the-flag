using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Karesz
{
    public partial class Form1 : Form
    {
        static Random r = new Random();
		string betöltendő_pálya = "Palya01.txt";

        void BaratsagosRobotSpawn()
        {
            int kh = r.Next(28) + 1;
            while (pálya.MiVanItt(new Vektor(1, kh)) == 1)
                kh = r.Next(28) + 1;
            new Robot("Karesz", 0, 0, 0, 0, 5, 1, kh, r.Next(3));//5 hógolyóval indít
            int khk = r.Next(28) + 1;
            while (khk == kh || pálya.MiVanItt(new Vektor(1, khk)) == 1)
                khk = r.Next(28) + 1;
            new Robot("Janesz", 0, 0, 0, 0, 5, 1, khk, r.Next(3));
        }

        (Robot, Robot) EllensegesRobotSpawn()
        {
            int kh = r.Next(28) + 1;
            while (pálya.MiVanItt(new Vektor(1, kh)) == 1)
                kh = r.Next(28) + 1;
            Robot gonesz = new Robot("Gonesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 10, 39, kh, 2, 1);//10 hógolyóval indít
            int khk = r.Next(28) + 1;
            while (khk == kh || pálya.MiVanItt(new Vektor(1, khk)) == 1)
                khk = r.Next(28) + 1;
            Robot ganesz = new Robot("Ganesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 10, 39, khk, 2, 1);
            return (gonesz, ganesz);
        }

        void TANÁR_ROBOTJAI()
		{
            BaratsagosRobotSpawn();
            (Robot gonesz, Robot ganesz) =  EllensegesRobotSpawn();

            ganesz.Feladat = delegate
            {
                ganesz.Lépj();
            };

            gonesz.Feladat = delegate
			{
				gonesz.Lőjj();
			};
		}

		void Vár(Robot r, int n)
		{
			for (int i = 0; i < n; i++)
                r.Várj();
		}

	}
}