using Microsoft.Vbe.Interop.Forms;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace dzien_ostatni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] LewyGorny = new int[2];
            string fileName = "objects.txt";
            int[] PrawyDolny = new int[2];
            int id = 0;
            List<Kwadrat> objects = new List<Kwadrat>();
            int bok;
            string kolor;
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("1.Dodaj Obiekt");
                Console.WriteLine("2.Pokaż obiekty");
                Console.WriteLine("3.Usuń obiekt");
                Console.WriteLine("4.Zapisz obiekty");
                Console.WriteLine("5.Wczytaj obiekty");
                Console.WriteLine("6.Generuj losowe obiekty");
                int wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1.Dodaj Kwadrat");
                        Console.WriteLine("2.Dodaj Prostokat");
                        Console.WriteLine("3.Dodaj Kolorowy Kwadrat");
                        int wybor2 = int.Parse(Console.ReadLine());
                        switch (wybor2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Podaj wspolrzedne lewego gornego rogu");
                                Console.Write("x: ");
                                LewyGorny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                LewyGorny[1] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Podaj wspolrzedne prawego dolnego rogu");
                                Console.Write("x: ");
                                PrawyDolny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                PrawyDolny[1] = int.Parse(Console.ReadLine());
                                objects.Add(new Kwadrat(1,LewyGorny, PrawyDolny, id));
                                id++;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Podaj wspolrzedne lewego gornego rogu");
                                Console.Write("x: ");
                                LewyGorny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                LewyGorny[1] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Podaj wspolrzedne prawego dolnego rogu");
                                Console.Write("x: ");
                                PrawyDolny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                PrawyDolny[1] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Podaj długość boku prostokąta");
                                bok = int.Parse(Console.ReadLine());
                                objects.Add(new Prostokat(2,LewyGorny, PrawyDolny, id, bok));
                                id++;
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Podaj wspolrzedne lewego gornego rogu");
                                Console.Write("x: ");
                                LewyGorny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                LewyGorny[1] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Podaj wspolrzedne prawego dolnego rogu");
                                Console.Write("x: ");
                                PrawyDolny[0] = int.Parse(Console.ReadLine());
                                Console.Write("y: ");
                                PrawyDolny[1] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Podaj kolor");
                                kolor = Console.ReadLine();
                                objects.Add(new KolorowyKwadrat(3,LewyGorny, PrawyDolny, id, kolor));
                                id++;
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Twoje obiekty:");
                        foreach(var kwadrat in objects)
                        {
                            if(kwadrat.typ == 1) kwadrat.Wyswietl();
                            else if(kwadrat.typ == 2) (kwadrat as Prostokat).Wyswietl();
                            else if(kwadrat.typ == 3) (kwadrat as KolorowyKwadrat).Wyswietl();
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Lista obiektów");
                        foreach (var kwadrat in objects)
                        {
                            if (kwadrat.typ == 1) kwadrat.Wyswietl();
                            else if (kwadrat.typ == 2) (kwadrat as Prostokat).Wyswietl();
                            else if (kwadrat.typ == 3) (kwadrat as KolorowyKwadrat).Wyswietl();
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Podaj id elementu który chcesz usunąć");
                        int wybor3 = int.Parse(Console.ReadLine());
                        objects.Remove(objects.Where(item => item.id == wybor3).ToList()[0]);
                        break;
                    case 4:
                        StreamWriter streamWriter;
                        try
                        {
                            streamWriter = new StreamWriter(fileName, false);
                            foreach (var kwadrat in objects)
                            {
                                if (kwadrat.typ == 1) streamWriter.WriteLine(kwadrat.PobierzDane());
                                else if (kwadrat.typ == 2) streamWriter.WriteLine((kwadrat as Prostokat).PobierzDane());
                                else if (kwadrat.typ == 3) streamWriter.WriteLine((kwadrat as KolorowyKwadrat).PobierzDane());                                
                            }
                            streamWriter.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:                        
                        StreamReader streamReader;
                        try
                        {
                            objects = new List<Kwadrat>();
                            streamReader = new StreamReader(fileName);
                            string line = streamReader.ReadLine();
                            while (line!=null)
                            {
                                objects.Add(ReadFromFile(line, new Kwadrat()));                                
                                line = streamReader.ReadLine();
                            }
                            id = objects[objects.Count-1].id;
                            id++;
                            streamReader.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Podaj ile elementów chcesz wygenerować");
                        int wybor4 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj typ obiektów");
                        Console.WriteLine("1.Kwadrat"); 
                        Console.WriteLine("2.Prostokat"); 
                        Console.WriteLine("3.Kolorowy kwadrat");
                        int wybor5 = int.Parse(Console.ReadLine());
                        switch (wybor5)
                        {
                            case 1:
                                for(int i = 0; i < wybor4; i++)
                                {
                                    LewyGorny[0] = LosujLiczbe(r);
                                    LewyGorny[1] = LosujLiczbe(r);
                                    PrawyDolny[0] = LosujLiczbe(r);
                                    PrawyDolny[1] = LosujLiczbe(r);
                                    objects.Add(new Kwadrat(1, LewyGorny, PrawyDolny, id));
                                    id++;
                                }
                                break;
                            case 2:
                                for (int i = 0; i < wybor4; i++)
                                {
                                    LewyGorny[0] = LosujLiczbe(r);
                                    LewyGorny[1] = LosujLiczbe(r);
                                    PrawyDolny[0] = LosujLiczbe(r);
                                    PrawyDolny[1] = LosujLiczbe(r);
                                    bok = LosujLiczbe(r);
                                    objects.Add(new Prostokat(2, LewyGorny, PrawyDolny, id,bok));
                                    id++;
                                }
                                break;
                                case 3:
                                for (int i = 0; i < wybor4; i++)
                                {
                                    LewyGorny[0] = LosujLiczbe(r);
                                    LewyGorny[1] = LosujLiczbe(r);
                                    PrawyDolny[0] = LosujLiczbe(r);
                                    PrawyDolny[1] = LosujLiczbe(r);
                                    kolor = LosujKolor(r);
                                    objects.Add(new KolorowyKwadrat(3, LewyGorny, PrawyDolny, id, kolor));
                                    id++;
                                }
                                break;
                        }
                        break;
                }

            }
        }
        public static Kwadrat ReadFromFile(string data,Kwadrat kwadrat)
        {
            Kwadrat kwa = new Kwadrat();
            int i1 = 0;
            int licznik = 0;
            int i2;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == '.' || i == data.Length-1)
                {
                    i++;
                    i2=i-1;
                    if(licznik==0) kwa.id = int.Parse(ToWord(i1, i2, data));
                    else if(licznik==1) kwa.typ = int.Parse(ToWord(i1, i2, data));
                    else if(licznik==2) kwa.LewyGorny[0] = int.Parse(ToWord(i1, i2, data));
                    else if(licznik==3) kwa.LewyGorny[1] = int.Parse(ToWord(i1, i2, data));
                    else if(licznik==4) kwa.PrawyDolny[0] = int.Parse(ToWord(i1, i2, data));
                    else if(licznik==5) kwa.PrawyDolny[1] = int.Parse(ToWord(i1, i2, data));
                    if (kwa.typ == 1)
                    {
                        kwadrat = new Kwadrat();
                        kwadrat.id = kwa.id;
                        kwadrat.typ = kwa.typ;
                        kwadrat.LewyGorny[0] = kwa.LewyGorny[0];
                        kwadrat.LewyGorny[1] = kwa.LewyGorny[1];
                        kwadrat.PrawyDolny[0] = kwa.PrawyDolny[0];
                        kwadrat.PrawyDolny[1] = kwa.PrawyDolny[1];
                    }
                    else if (kwa.typ == 2)
                    {
                        kwadrat = new Prostokat();
                        (kwadrat as Prostokat).bokPros = int.Parse(ToWord(i1, i2, data));
                        kwadrat.id = kwa.id;
                        kwadrat.typ = kwa.typ;
                        kwadrat.LewyGorny[0] = kwa.LewyGorny[0];
                        kwadrat.LewyGorny[1] = kwa.LewyGorny[1];
                        kwadrat.PrawyDolny[0] = kwa.PrawyDolny[0];
                        kwadrat.PrawyDolny[1] = kwa.PrawyDolny[1];
                    }
                    else if (kwa.typ == 3)
                    {
                        kwadrat = new KolorowyKwadrat();
                        kwadrat.id = kwa.id;
                        kwadrat.typ = kwa.typ;
                        kwadrat.LewyGorny[0] = kwa.LewyGorny[0];
                        kwadrat.LewyGorny[1] = kwa.LewyGorny[1];
                        kwadrat.PrawyDolny[0] = kwa.PrawyDolny[0];
                        kwadrat.PrawyDolny[1] = kwa.PrawyDolny[1];
                        (kwadrat as KolorowyKwadrat).Kolor = ToWord(i1, i2+1, data);

                    }
                    licznik++;
                    i1 = i;
                }                
            }
            return kwadrat;
        }
        public static string ToWord(int i1, int i2, string data)
        {
            string word="";
            for (int j = i1; j < i2; j++)
            {
                word += data[j];
            }
            return word;
        }
        public static int LosujLiczbe(Random r) => r.Next(1, 200);
        public static string LosujKolor(Random r)
        {
            string[] kolory = { "Czerwony" , "Czarny","Niebieski","Zielony","Pomarańczowy","Brązowy","Biały","Bordowy","Granatowy","Ciemny zielony"};
            return kolory[r.Next(kolory.Length)];
        }
    }
}