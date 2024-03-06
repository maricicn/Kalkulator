using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp3
{
    internal class VelikiBroj
    {
        public string broj;
        public VelikiBroj(string broj)
        {
            this.broj = broj;
        }
        public int MestoZareza()
        {
            return broj.IndexOf('.');
        } 
        public bool Decimalan()
        {
            if (MestoZareza() != -1) return true;
            else return false;
        }
        public string CeoDeo()
        {
            if (MestoZareza() != -1) return broj.Substring(0, MestoZareza());
            else return broj;
        }
        public string DecimalniDeo()
        {
            int n = broj.Length - MestoZareza();
            if (MestoZareza() != -1) return broj.Substring(MestoZareza() + 1, broj.Length - MestoZareza() -1);
            else return "0";
        }
        public string DodajZareze()
        {
            return string.Empty;
        }
        public static string operator +(VelikiBroj a, VelikiBroj b)
        {
            string minus = string.Empty;
            /*if (a.broj[0].Equals('-'))
            {
                a.broj = a.broj.Replace("-", string.Empty);
            }
            if (b.broj[0].Equals('-'))
            {
                b.broj = b.broj.Replace("-", string.Empty);
            }*/

            if (a.Decimalan() && b.Decimalan())
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                if (string.IsNullOrEmpty(pom1) && string.IsNullOrEmpty(pom2))
                    return "0";
                int mz1 = 0; int mz2 = 0;
                if (pom1.IndexOf(".") != -1) { mz1 = pom1.IndexOf("."); }
                if (pom2.IndexOf(".") != -1) { mz2 = pom2.IndexOf("."); }
                if (mz1 > mz2)
                {
                    for (int i = 0; i < (mz1 - mz2); i++) { pom2 = "0" + pom2; }
                }
                else if (mz1 < mz2)
                {
                    for (int i = 0; i < (mz2 - mz1); i++) { pom1 = "0" + pom1; }
                }
                int n1 = pom1.Length;
                int n2 = pom2.Length;
                if (n1 > n2)
                {
                    for (int i = 0; i < (n1 - n2); i++) { pom2 = pom2 + "0"; }
                }
                else if (n1 < n2)
                {
                    for (int i = 0; i < (n2 - n1); i++) { pom1 = pom1 + "0"; }
                }

                string rez = string.Empty;
                n1 = pom1.Length;
                int prenesi = 0;
                for (int i = n1 - 1; i >= 0; i--)
                {
                    if (pom1[i] == 46) { rez = "." + rez; continue; }
                    int zbir = (pom1[i] - '0') + (pom2[i] - '0') + prenesi;
                    rez = (zbir % 10).ToString() + rez;
                    prenesi = zbir / 10;
                }

                if (prenesi != 0) rez = prenesi.ToString() + rez;
                return rez;
            }
            else if(!a.Decimalan() && (!b.Decimalan()))
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom1 = pom1 + "." + "0";
                pom2 = pom2 + "." + "0";
                string rez = new VelikiBroj(pom1) + new VelikiBroj(pom2);
                rez = rez.TrimEnd('0');
                rez = rez.Replace(".", string.Empty);
                return rez;
            }
            else if (a.Decimalan() && (!b.Decimalan()))
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom2 = pom2 + "." + "0";
                return new VelikiBroj(pom1) + new VelikiBroj(pom2);
            }
            
            else
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom1 = pom1 + "." + "0";
                return new VelikiBroj(pom1) + new VelikiBroj(pom2);
            }
        }
        public static string operator -(VelikiBroj a, VelikiBroj b)
        {
            /*if (a.broj[0].Equals('-'))
            {
                a.broj = a.broj.Replace("-", string.Empty);
            }
            if (b.broj[0].Equals('-'))
            {
                b.broj = b.broj.Replace("-", string.Empty);
            }*/
            if (!a.Decimalan() && !b.Decimalan())
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom1 = pom1 + "." + "0";
                pom2 = pom2 + "." + "0";
                string rez = new VelikiBroj(pom1) - new VelikiBroj(pom2);
                rez = rez.TrimEnd('0');
                rez = rez.Replace(".", string.Empty);
                return rez;

            }
            if(a.Decimalan() && b.Decimalan())
            {
                if (a.broj == b.broj) return "0";
                string pom1 = a.broj;
                string pom2 = b.broj;
                int mz1 = a.MestoZareza();
                int mz2 = b.MestoZareza();
                string minus = string.Empty;
                if(mz1 > mz2)
                {
                    for(int i = 0; i < (mz1 - mz2); i++) { pom2 = "0" + pom2; }
                }
                else if(mz1 < mz2)
                {
                    for(int i = 0; i < (mz2 - mz1); i++) {  pom1 = "0" + pom1; }
                }
                int n1 = pom1.Length;
                int n2 = pom2.Length;
                if(n1 > n2)
                {
                    for(int i = 0; i < (n1 - n2); i++) { pom2 = pom2 + "0"; }
                }
                else if(n1 < n2)
                {
                    for (int i = 0; i < (n2 - n1); i++) { pom1 = pom1 + "0"; }
                }
                n1 = pom1.Length;
                for(int i = 0; i < n1; i++)
                {
                    if (pom1[i] > pom2[i]) break;
                    else if ((pom1[i] - '0') < (pom2[i] - '0'))
                    {
                        string temp = pom1;
                        pom1 = pom2;
                        pom2 = temp;
                        minus = "-";
                        break;
                    }
                }
                string rez = string.Empty;
                int prenesi = 0;
                n1 = pom1.Length;
                for (int i = n1 - 1; i >= 0; i--)
                {
                    int zbir = 0;
                    if (pom1[i] == 46) { rez = "." + rez; continue; }

                    if (((pom1[i] - '0') - (pom2[i] - '0') - prenesi) < 0)
                    {
                        zbir = 10 + (pom1[i] - '0') - (pom2[i] - '0') - prenesi;
                        prenesi = 1;
                    }
                    else
                    {
                        zbir = (pom1[i] - '0') - (pom2[i] - '0') - prenesi;
                        prenesi = 0;
                    }
                    rez = zbir.ToString() + rez;

                }
                rez = rez.TrimStart('0');
                if (rez[0] == 46) rez = "0" + rez;
                return minus + rez;
            }
            if(a.Decimalan() && !b.Decimalan())
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom2 = pom2 + "." + "0";
                return new VelikiBroj(pom1) - new VelikiBroj(pom2);
            }
            else
            {
                string pom1 = a.broj;
                string pom2 = b.broj;
                pom1 = pom1 + "." + "0";
                return new VelikiBroj(pom1) - new VelikiBroj(pom2);
            }
            
        }

        public static string Pomnozi (VelikiBroj a, VelikiBroj b)
        {
            string broj1 = a.broj;
            string broj2 = b.broj;
            int[] rezultat = new int[broj1.Length + broj2.Length]; // rezultujući niz brojeva
            for (int i = 0; i < broj1.Length + broj2.Length; i++)
            {
                rezultat[i] = 0;
            }

            for (int i = broj1.Length - 1; i >= 0; i--)
            {
                // Iteracija unazad kroz drugi broj
                for (int j = broj2.Length - 1; j >= 0; j--)
                {
                    int mul = (broj1[i] - '0') * (broj2[j] - '0'); // Množenje cifara
                    int suma = mul + rezultat[i + j + 1]; // Dodavanje proizvoda na odgovarajuće mesto u rezultatu
                    rezultat[i + j] += suma / 10; // Dodavanje prenosne cifre na prethodnu poziciju
                    rezultat[i + j + 1] = suma % 10; // Dodavanje ostataka na trenutnu poziciju
                }
            }

            // Konverzija rezultata u string
            string rezultatString = "";
            foreach (int num in rezultat)
            {
                if (!(rezultatString.Length == 0 && num == 0)) // Ignorisanje vodećih nula
                    rezultatString += num;
            }

            return rezultatString.Length == 0 ? "0" : rezultatString; // Ako je rezultat prazan, vraćamo "0"
        }
    }
}
