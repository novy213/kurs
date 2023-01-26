using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzien_ostatni
{
    internal class Prostokat : Kwadrat
    {
        public int bokPros;
        public Prostokat(int typ,int[] LewyGorny, int[] PrawyDolny, int id, int bokPros) : base(typ,LewyGorny, PrawyDolny, id)
        {
            this.bokPros = bokPros;
        }
        public new void Wyswietl()
        {
            base.Wyswietl();
            Console.WriteLine("Bok prostokata = " + bokPros);
        }
        public new string PobierzDane()
        {
            string dane = base.PobierzDane();
            dane += "." + bokPros;
            return dane;
        }
        public Prostokat()
        {

        }
    }
}
