﻿using System;

namespace Zadanie02___Pracownicy_delagaty.model
{
    public class Pracownik
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int staz { get; set; }
        public int liczbaSprzedazy { get; set; }
        public double pensja { get; set; }

        public Pracownik(int id, string imie, string nazwisko, int staz, int liczbaSprzedazy, double pensja)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.staz = staz;
            this.liczbaSprzedazy = liczbaSprzedazy;
            this.pensja = pensja;
        }

        // public int CompareTo(Pracownik pracownik)
        // {
        //     if (pracownik.staz == null)
        //         return 1;
        //     else
        //     {
        //         return this.staz.CompareTo(pracownik.staz);
        //     }
        // }
    }
}