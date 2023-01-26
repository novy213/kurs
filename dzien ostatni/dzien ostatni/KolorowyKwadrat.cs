using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzien_ostatni
{
    internal class KolorowyKwadrat : Kwadrat
    {
        public string Kolor;
       
        public KolorowyKwadrat(int typ,int[] LewyGorny, int[] PrawyDolny, int id, string kolor) : base(typ,LewyGorny, PrawyDolny, id)
        {
            this.Kolor = kolor;
        }
        public new void Wyswietl()
        {
            base.Wyswietl();
            Console.WriteLine("Kolor kwadratu = " + Kolor);
        }
        public new string PobierzDane()
        {
            string dane = base.PobierzDane();
            dane += "." + Kolor;
            return dane;
        }
        public KolorowyKwadrat()
        {

        }
    }
}
