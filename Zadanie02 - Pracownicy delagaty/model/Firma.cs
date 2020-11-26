using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;

namespace Zadanie02___Pracownicy_delagaty.model
{
    public delegate void DelegatFirmowy(Pracownik pracownik);
    // do zadania 2.8
    public delegate bool BoolDelagetFirmowySpecific(List<string> list);
    public delegate bool BoolDelagetFirmowy(Pracownik pracownik);

    public class Firma
    {
        // zdefiniowanie zmiennej typu delagat
        public event DelegatFirmowy OnAdded;
        public event DelegatFirmowy OnRemoved;

        public List<Pracownik> pracownikList = new List<Pracownik>();
        
        // dodanie nowego pracownika
        public void Dodaj(Pracownik pracownik)
        {
            pracownikList.Add(pracownik);
            if (OnAdded != null)
                OnAdded(pracownik);
        }

        // usuniecie pracownika o podanym identyfikatorz
        public void Usun(int id)
        {
            int index = 0;
            foreach (Pracownik pracownik in pracownikList)
            {
                if (pracownik.id == id)
                {
                    break;
                }
                index += 1;
            }

            Pracownik pra = pracownikList.ElementAt(index);
            this.pracownikList.RemoveAt(index);
            if (OnRemoved != null)
                OnRemoved(pra);
        }


        // dodanie metod
        public void MojaMetoda(DelegatFirmowy delegatFirmowy)
        {
            foreach (Pracownik pracownik in this.pracownikList)
            {
                delegatFirmowy(pracownik);
            }
        }

        public Pracownik FindById(int id)
        {
            return pracownikList.Find(p => p.id == id);
        }

        public List<Pracownik> FindAllByFirstNameLastNameContains(string text)
        {
            List<Pracownik> pracowniks = pracownikList.FindAll(p => p.imie.Contains(text) || p.nazwisko.Contains(text));
            return pracowniks;
        }

        public List<Pracownik> FindAllBySprzedaz()
        {
            List<Pracownik> pracowniks =
                pracownikList.FindAll(p => p.liczbaSprzedazy >= 10 && p.liczbaSprzedazy <= 200);
            return pracowniks;
        }

        public List<Pracownik> FindAllByMaxStaz()
        {
            List<Pracownik> pracowniks = new List<Pracownik>();
            pracownikList.Sort((p1, p2) => p2.staz.CompareTo(p1.staz));
            Console.WriteLine(pracownikList);
            pracowniks.Add(pracownikList.ElementAt(0));
            pracowniks.Add(pracownikList.ElementAt(1));
            pracowniks.Add(pracownikList.ElementAt(2));

            Console.WriteLine(pracownikList);
            return pracowniks;
        }
        
        // zadanie 2.8 
        
        // public void ShowSpecificInformation(BoolDelagetFirmowySpecific boolDelagetFirmowySpecific)
        // {
        //     List<string> list = new List<string>();
        //
        //     if (boolDelagetFirmowySpecific(list))
        //     {
        //         foreach (Pracownik pracownik in pracownikList)
        //         {
        //             Console.WriteLine("Wskazane informacje o pracowniku: " + pracownik);
        //             
        //         }
        //     }
        //    
        // }
        
        public List<Pracownik> SearchSpecificInformation(BoolDelagetFirmowy boolDelagetFirmowy)
        {
            List<Pracownik> pracowniks = new List<Pracownik>();
            
            foreach (Pracownik pracownik in pracownikList)
            {
                // na kazdym z pracownikow zostanie wywolania metoda boolDelagetFirmowy(pracownik)
                // jesli zwroci true to pracownik dodany zostaje do listy
                if (boolDelagetFirmowy(pracownik))
                {
                    pracowniks.Add(pracownik);
                }
            }
            
            return pracowniks;
        }
        
    }
}