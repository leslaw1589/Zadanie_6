using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_6
{
    class Program
    {
        static void Main(string[] args)
        {
            String PESEL;
            bool control;

            Console.Write("Podaj PESEL: ");
            while (true)
            {
                control = false;
                PESEL = Console.ReadLine();
                if (PESEL.Length == 11)
                {
                    for (int i = 0; i < PESEL.Length; i++)
                    {
                        if (jakaCyfra(PESEL[i]) == 99) control = true;
                    }

                    if (!control) break;
                }
                Console.WriteLine("Błąd!");
                Console.Write("Podaj prawidłowy PESEL: ");
            }

            Console.WriteLine(walidacja(PESEL));

            Console.ReadKey();
        }

        private static String walidacja(string PESEL)
        {
            int result = jakaCyfra(PESEL[0]) * 1 + jakaCyfra(PESEL[1]) * 3 + jakaCyfra(PESEL[2]) * 7 + jakaCyfra(PESEL[3]) * 9 + jakaCyfra(PESEL[4]) * 1 + jakaCyfra(PESEL[5]) * 3 + jakaCyfra(PESEL[6]) * 7 + jakaCyfra(PESEL[7]) * 9 + jakaCyfra(PESEL[8]) * 1 + jakaCyfra(PESEL[9]) * 3;
            result = result % 10;
            result = 10 - result;
            result = result % 10;
            if (result == jakaCyfra(PESEL[10]))
            {
                int year = getYear(PESEL);
                int month = getMonth(PESEL, year);
                int day = jakaCyfra(PESEL[4]) * 10 + jakaCyfra(PESEL[5]);
                String sex = getSex(PESEL);
                String dataUrodzenia = Convert.ToString(day) + "." + Convert.ToString(month) + "." + Convert.ToString(year);

                return "Osoba to " + sex + ". Data urodzenia: " + dataUrodzenia;
            }

            else return null;
        }

        private static String getSex(string PESEL)
        {
            if (PESEL[9] % 2 == 0) return "Kobieta";
            else return "Mężczyzna";
        }

        private static int getMonth(string PESEL, int rok)
        {
            int miesiac = jakaCyfra(PESEL[2])*10 + jakaCyfra(PESEL[3]);

            if (rok >= 1800 && rok <= 1899) miesiac -= 80;
            else if (rok >= 1900 && rok <= 1999) miesiac -= 0;
            else if (rok >= 2000 && rok <= 2099) miesiac -= 20;
            else if (rok >= 2100 && rok <= 2199) miesiac -= 40;
            else if (rok >= 2200 && rok <= 2299) miesiac -= 60;
            else miesiac = 0;

            return miesiac;
        }

        private static int getYear(string PESEL)
        {
            int miesiac1 = jakaCyfra(PESEL[2]);
            int miesiac2 = jakaCyfra(PESEL[3]);
            int suma = miesiac1 * 10 + miesiac2;
            int rok = jakaCyfra(PESEL[0]) * 10 + jakaCyfra(PESEL[1]);

            if (suma >= 1 && suma <= 12) rok += 1900;
            else if (suma >= 21 && suma <= 32) rok += 2000;
            else if (suma >= 41 && suma <= 52) rok += 2100;
            else if (suma >= 61 && suma <= 72) rok += 2200;
            else if (suma >= 81 && suma <= 92) rok += 1800;
            else rok = 0;

            return rok;
        }

        private static int jakaCyfra(char znak)
        {
            switch (znak)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default: return 99;
            }
        }

    }
}
