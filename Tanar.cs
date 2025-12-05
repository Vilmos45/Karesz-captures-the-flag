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

        void TANÁR_ROBOTJAI()
		{
            int kh = r.Next(28) + 1;
            new Robot("Karesz", 0, 0, 0, 0, 5, 1, kh, r.Next(3));//5 hógolyóval indít
            r.Next();
            int khk = r.Next(28) + 1;
            while (khk == kh)
                khk = r.Next(28) + 1;
            new Robot("Janesz", 0, 0, 0, 0, 5, 1, khk, r.Next(3));

            int kh2 = r.Next(28) + 1;

            Robot gonesz = new Robot("Gonesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 10, 39, kh2, 2, 1);//10 hógolyóval indít
            r.Next();
            int khk2 = r.Next(28) + 1;
            while (khk2 == kh2)
                khk2 = r.Next(28) + 1;
            Robot ganesz = new Robot("Ganesz", Robot.képkészlet_lilesz, 0, 0, 0, 0, 10, 39, khk2, 2, 1);


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