using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie02___Pracownicy_delagaty.model;

namespace Zadanie02___Pracownicy_delagaty
{
    class Program
    {
        static void Main(string[] args)
        {
            Firma firma = new Firma();

            firma.OnAdded += p =>
            {
                Console.WriteLine("Dodano " + p.imie + " " + p.nazwisko);
                Console.WriteLine("Wywolanie OnAdd po dodaniu obiektu");
            };

            firma.OnRemoved += p =>
            {
                Console.WriteLine("Usunieto " + p.imie + " " + p.nazwisko);
                Console.WriteLine("Wywolanie OnAdd po dodaniu obiektu");
            };

            firma.Dodaj(new Pracownik(0, "Wojciech", "Wojciechowski", 9, 2, 7000));
            firma.Dodaj(new Pracownik(1, "Bonifacy", "Bonifacowski", 52, 30, 7500));
            firma.Dodaj(new Pracownik(2, "Filemon", "Filemonowski", 12, 310, 20000));
            firma.Dodaj(new Pracownik(3, "Bartlomiej", "Bartkowski", 26, 200, 10000));
            firma.Dodaj(new Pracownik(4, "Lukasz", "Lukaszowski", 14, 110, 20300));


            firma.Usun(1);
            
            // zadanie 2.8
            Console.WriteLine("Wyświetlenie informacji");
            Console.WriteLine("----------------------");
            
            // firma.ShowSpecificInformation(p => p.Contains("imie"));
            
            
            Console.WriteLine("Szukanie pracowników wg dowolnych kryteriów");
            Console.WriteLine("----------------------");

            List<Pracownik> pracownik6 = firma.SearchSpecificInformation(p => p.pensja <= 7500);
            foreach (Pracownik pracownik in pracownik6)
            {
                Console.WriteLine(pracownik.imie);
            }

            // zadanie 3.2
            Console.WriteLine("----------------------");
            firma.MojaMetoda(new DelegatFirmowy(Dzial.ZwiekszPensje1));
            Console.WriteLine("----------------------");
            firma.MojaMetoda(new DelegatFirmowy(Dzial.ZwiekszPensje2));
            Console.WriteLine("----------------------");
            
            firma.MojaMetoda(new DelegatFirmowy(Dzial.ZerujSprzedaz));
            Console.WriteLine("----------------------");

            // zadanie 3.3
            Console.WriteLine("Szukanie po id");
            Console.WriteLine("----------------------");
            Pracownik pracownik1 = firma.FindById(2);
            Console.WriteLine(pracownik1.imie);

            Console.WriteLine("Szukanie po imieniu lub nazwisku");
            Console.WriteLine("----------------------");

            List<Pracownik> pracownik2 = firma.FindAllByFirstNameLastNameContains("cie");
            foreach (Pracownik pracownik in pracownik2)
            {
                Console.WriteLine(pracownik.imie);
            }

            Console.WriteLine("Szukanie sprzedajacych w przedziale 10-200");
            Console.WriteLine("----------------------");

            List<Pracownik> pracownik3 = firma.FindAllBySprzedaz();
            foreach (Pracownik pracownik in pracownik3)
            {
                Console.WriteLine(pracownik.imie);
            }

            Console.WriteLine("Szukanie najlepiej sprzedajacych");
            Console.WriteLine("----------------------");

            List<Pracownik> pracownik4 = firma.FindAllByMaxStaz();
            foreach (Pracownik pracownik in pracownik4)
            {
                Console.WriteLine(pracownik.imie);
            }
            
        }
    }
}