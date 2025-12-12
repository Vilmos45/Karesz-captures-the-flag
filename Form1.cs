using System.Windows.Forms;


namespace Karesz
{
    public partial class Form1 : Form
    {

        // IDE JÖNNEK AZ ELJÁRÁSOK ÉS FÜGGVÉNYEK


        void DIÁK_ROBOTJAI()
        {
            Robot.Get("Janesz").Feladat = delegate ()
            {
                Lépj();
            };

            Robot.Get("Karesz").Feladat = delegate ()
            {
                /*dpálya - legyenek falak, amik kékek
				 * 1-2 fal, ami mögé el lehet bújni
				 * 
				 *d2 karesz + 2 gonesz (karesz, Janesz, Gonesz, Ganesz)
				 * új képek robotokhoz + hozzájuk tenni
				 * ellenséges robot szenzor (int: távolság)
				 *dbarátságos-e (szembe levő legközelebbi robot: bool) -> igaz ha barátságos vagy nincs, false ha ellenséges
				 * leprogramozni botokat (védő, támadó) -> legyen ugyanolyan
				 * mindkettő robot:
				 *	- ha van itt fehér kavics vedd fel
				 *	támadó:
				 *	- elmegy az ellenséges kavicshoz, felveszi, és visszaviszi, és leteszi
				 *	- közben, ha találkozik valakivel, lő, amíg van kavicsa
				 *	védő: 
				 *	- vár a kavics mellett, amíg nem jön valaki, azt lelövi
				 * 
				 * tudjanak üzenni
				 * 
				 * Hógolyó felujítása:
				 *	- legyen fehér kavics, ahol leesik, ha belemegy a falba, üsszeütköznek egymással, ha belemegy robotba (mindig)
				 *	- szívjanak!
				 *	- legyen csak öt hógolyójuk
				 *	- ne ugorja át a közvetlenül előtte elő levő dolgokat
				 * 
				 *dha meghal a kavicsot horozó robot, csak olyan színű a sírja
				 *dMikor van vége, ablak bezárása
				 */
                Lépj();
                Lőjj();

                int a = Milyen_messze_van_hógolyó();
                bool b = Erre_jön_e_a_hógolyó();
                bool c = Barátságos_e();
                bool d = Mas
            };
        }

    }
}





/* USERS MANUAL -- LEGFONTOSABB PARANCSOK

PÁLYASPECIFIKUS

Lőjj();							-------- Karesz lő előre egy hógolyót

Milyen_messze_van_hógolyó()		-------- Visszaadja a Karesszal szemben levő legközelebbi hógolyó távolságát, vagy -1-et
Erre_jön_e_a_hógolyó()			-------- igaz, ha Karesz felé közeledik a Karesszal szembe levő legközelebbi hógolyó

HASZNOS

Várj();							-------- Karesz kihagyja magát egy körből, amíg a többiek lépnek

MOZGÁSOK

Lépj();                          -------- Karesz előre lép egyet.
Fordulj(jobbra);                 -------- Karesz jobbra fordul.
Fordulj(balra);                  -------- Karesz balra fordul.
Vegyél_fel_egy_kavicsot();       -------- Karesz felvesz egy kavicsot.
Tegyél_le_egy_kavicsot();        -------- Karesz letesz egy fekete kavicsot
Tegyél_le_egy_kavicsot(piros);   -------- Karesz letesz egy piros kavicsot.

Minden mozgás után a robot köre véget ér és a következő robot jön. 

SZENZOROK

Van_e_előttem_fal();        -------- igaz, ha Karesz fal előtt áll, egyébként hamis.
Kilépek_e_a_pályáról();     -------- igaz, ha Karesz a pálya szélén kifele néz, egyébként hamis.
Van_e_itt_Kavics();         -------- igaz, ha Karesz épp kavicson áll, egyébként hamis.
Köveinek_száma_ebből(piros) -------- Karesz piros köveinek a száma.
Mi_van_alattam();           -------- a kavics színe, amin Karesz áll. (Ez igazából egy szám!)
Ultrahang();                -------- a Karesz előtt található tárgy távolsága. Ez a tárgy lehet fal vagy másik robot is. 
SzélesUltrahang();          -------- ugyanaz, mint az ultrahangszenzor, de ez nem csak a Karesz előtti mezőket pásztázza, hanem a szomszédos mezőket is. Egy számhármast ad vissza. 
Hőmérséklet();              -------- a Karesz által mért hőmérséklet. A láva forrása 1000 fok, amitől lépésenként távolodva a hőmérséklet 200 fokonként hűl. Az alapértelmezett hőmérséklet 0 fok.

A szenzorokat bármennyiszer használhatja a robot a saját körén belül.
*/

//A pályát készíték: Kovács Ádám, Zenzerov Maxim, Vilmos45 /24F
