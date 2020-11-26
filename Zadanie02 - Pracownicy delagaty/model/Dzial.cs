using System;

namespace Zadanie02___Pracownicy_delagaty.model
{
    public static class Dzial
    {
        public static void ZwiekszPensje1(Pracownik pracownik)
        {
            if (pracownik.liczbaSprzedazy > 10)
            {
                pracownik.pensja += pracownik.pensja * 0.1;
                Console.WriteLine(pracownik.imie + " " + pracownik.nazwisko + 
                                  ": zwiększono pensję " + pracownik.pensja + " ze względu na sprzedaz");
            }
        }

        public static void ZwiekszPensje2(Pracownik pracownik)
        {
            if (pracownik.staz > 2)
            {
                pracownik.pensja += pracownik.pensja * 0.1;
                Console.WriteLine(pracownik.imie + " " + pracownik.nazwisko + 
                                  ": zwiększono pensję " + pracownik.pensja + " ze względu na staz");
            }
        }

        public static void ZerujSprzedaz(Pracownik pracownik)
        {
            pracownik.liczbaSprzedazy = 0;
            Console.WriteLine(pracownik.imie + " " + pracownik.nazwisko + 
                              ": wyzerowane liczbę sprzedaży " + pracownik.liczbaSprzedazy);
        }
    }
}