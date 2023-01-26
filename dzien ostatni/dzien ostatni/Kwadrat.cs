using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzien_ostatni
{
    public class Kwadrat : ObjectInterface
    {
        public int typ;
        public int[] LewyGorny = new int[2];
        public int[] PrawyDolny = new int[2];
        public int bok
        {
            get
            {
                return PrawyDolny[0] - LewyGorny[0];
            }            
        }
        public int id;
        public Kwadrat(int typ, int[] LewyGorny, int[] PrawyDolny, int id)
        {
            this.LewyGorny[0] = LewyGorny[0];
            this.LewyGorny[1] = LewyGorny[1];
            this.PrawyDolny[0] = PrawyDolny[0];
            this.PrawyDolny[1] = PrawyDolny[1];
            this.id = id;
            this.typ = typ;
        }

        public void Wyswietl()
        {
            Console.WriteLine($"Obiekt o id = {id}");
            if(this.typ==1) Console.WriteLine("Obiekt typu = Kwadrat");
            else if (this.typ == 2) Console.WriteLine("Obiekt typu = Prostokat");
            else if (this.typ == 3) Console.WriteLine("Obiekt typu = Kolorowy Kwadrat");
            Console.WriteLine("Wspolrzedne lewy gorny:");
            Console.WriteLine("x: " + LewyGorny[0]);
            Console.WriteLine("y: " + LewyGorny[1]);
            Console.WriteLine("Wspolrzedne prawy dolny:");
            Console.WriteLine("x: " + PrawyDolny[0]);
            Console.WriteLine("y: " + PrawyDolny[1]);
        }
        public string PobierzDane()
        {
            string dane;
            dane = id + "." + typ + "." + LewyGorny[0] + "." + LewyGorny[1] + "." + PrawyDolny[0] + "." + PrawyDolny[1] + "." + bok;
            return dane;
        }
        public Kwadrat()
        {

        }
    }
}
