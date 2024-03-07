using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
        public static int Uporedi(VelikiBroj a, VelikiBroj b) //Uporedjuje dva cela broja
        {
            string pom1 = a.broj;
            string pom2 = b.broj;
            int n1 = pom1.Length;
            int n2 = pom2.Length;
            if (n1 > n2)
            {
                for (int i = 0; i < (n1 - n2); i++) { pom2 = "0" + pom2; }
            }
            else if (n1 < n2)
            {
                for (int i = 0; i < (n2 - n1); i++) { pom1 = "0" + pom1; }
            }
            for (int i = 0; i < pom1.Length; i++)
            {
                if ((pom1[i] - '0') > (pom2[i] - '0')) return 1;
                if ((pom2[i] - '0') > (pom1[i] - '0')) return 2;
            }
            return 0;
        }
        public static int Podeli(VelikiBroj a, VelikiBroj b) //Ova funkcia se koristi da se podele dva broja ciji je kolicnik max 9
        {
            string razlika = a - b;
            int t = 0;
            while (!(razlika[0] == 45))
            {
                if (razlika == "0") return t + 1;
                razlika = new VelikiBroj(razlika) - b;
                t++;
            }
            return t;

        }
        public static string Kolicnik(VelikiBroj a, VelikiBroj b) //ova funkcija se koristi da bi se celobrojno podelila dva string (nemaju zareze u sebi)
        {
            if (a.broj == "0") return "0";
            if (Uporedi(a, b) == 2) return "0";
            string pom1 = a.broj;
            string rez = string.Empty;
            string s1 = pom1.Substring(0, b.broj.Length);
            if (Uporedi(b,new VelikiBroj(s1)) == 1)
            {
                s1 = pom1.Substring(0, b.broj.Length + 1);
            }
            int duzina = s1.Length;
            for(int i = duzina ; i <= pom1.Length; i++)
            {
                int kol = Podeli(new VelikiBroj(s1), b);
                rez = rez + kol;
                if (i == pom1.Length) break;
                s1 = new VelikiBroj(s1) - new VelikiBroj(new VelikiBroj(kol.ToString()) * b);
                if (s1 == "0") { s1 = (pom1[i] - '0').ToString(); }
                else s1 = s1 + pom1[i];
            }
            return rez;
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
            if (a.broj == b.broj) return "0";
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

        public static string operator *(VelikiBroj a, VelikiBroj b)
        {
            if (a.broj == "0" || b.broj == "0") return "0";
            if (a.Decimalan() && b.Decimalan())
            {
                string broj1 = a.broj;
                string broj2 = b.broj;
                int mz1 = 0;
                int mz2 = 0;
                if (a.MestoZareza() != -1) { mz1 = a.MestoZareza(); broj1 = broj1.Replace(".", string.Empty); }
                if (b.MestoZareza() != -1) { mz2 = b.MestoZareza(); broj2 = broj2.Replace(".", string.Empty); }
                int ukupno = broj1.Length - mz1 + broj2.Length - mz2;
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
                int d = rezultatString.Length;
                StringBuilder sb = new StringBuilder(rezultatString);
                sb.Insert(d - ukupno, ".");
                //return rezultatString.Length == 0 ? "0" : rezultatString; // Ako je rezultat prazan, vraćamo "0"
                string rez = sb.ToString();
                if (rez[0] == '.') rez = "0" + rez;
                rez = rez.TrimEnd('0');
                return rez;
            }
            if (!a.Decimalan() && !b.Decimalan())
            {
                string broj1 = a.broj;
                string broj2 = b.broj;
                broj1 = broj1 + "." + "0";
                broj2 = broj2 + "." + "0";
                string rez = new VelikiBroj(broj1) * new VelikiBroj(broj2);
                rez = rez.Replace(".", string.Empty);
                return rez;
            }
            if(a.Decimalan() && !b.Decimalan())
            {
                string broj1 = a.broj;
                string broj2 = b.broj;
                broj2 = broj2 + ".";
                return a * new VelikiBroj(broj2);
            }
            else
            {
                string broj1 = a.broj;
                string broj2 = b.broj;
                broj1 = broj1 + ".";
                return new VelikiBroj(broj1) * b;
            }
        }
        public static string operator /(VelikiBroj a, VelikiBroj b)
        {
            int ukupno = 0;
            if (!a.Decimalan() && !b.Decimalan())
            {
                if (b.broj == "0") return "Ne mozete deliti sa 0";
                string rez = string.Empty;
                string kol = Kolicnik(a, b);
                string temp = a - new VelikiBroj(new VelikiBroj(kol) * b);
                if (temp == "0") return rez + kol;
                else rez = rez + kol + ".";
                /*while (temp != "0")
                {
                    temp = temp + "0";
                    kol = Kolicnik(new VelikiBroj(temp), b);
                    rez = rez + kol;
                    temp = new VelikiBroj(temp) - new VelikiBroj(new VelikiBroj(kol) * b);
                }*/
                int br_decimala = int.Parse(Form1.form1instance.brdcm.Text);
                for (int i = 0; i < br_decimala + ukupno; i++)
                {
                    if (temp == "0") break;
                    temp = temp + "0";
                    kol = Kolicnik(new VelikiBroj(temp), b);
                    rez = rez + kol;
                    temp = new VelikiBroj(temp) - new VelikiBroj(new VelikiBroj(kol) * b);
                }
                return rez;
            }
            if(a.Decimalan() && b.Decimalan())
            {
                int mz1 = a.MestoZareza();
                int mz2 = b.MestoZareza();
                ukupno = 0;
                int do_kraja1 = a.broj.Length - mz1 - 1;
                int do_kraja2 = b.broj.Length - mz2 - 1;
                string pom1 = a.broj;
                string pom2 = b.broj;
                ukupno = do_kraja2 - do_kraja1;
                if (ukupno > 0)
                {
                    for (int i = 0; i < ukupno; i++)
                    {
                        pom1 = pom1 + "0";
                    }
                }
                else
                {
                    ukupno = -ukupno;
                    for (int i = 0; i < ukupno; i++)
                    {
                        pom2 = pom2 + "0";
                    }
                }
                pom1 = pom1.Replace(".", string.Empty);
                pom2 = pom2.Replace(".", string.Empty);
                do_kraja1 = pom1.Length - mz1;
                do_kraja2 = pom2.Length - mz2;
                pom1 = pom1.TrimStart('0');
                pom2 = pom2.TrimStart('0');
                if (do_kraja2 > do_kraja1)
                {
                    
                    string rez = new VelikiBroj(pom1) / new VelikiBroj(pom2);
                    int mz_rezultata = 0;
                    if (rez.IndexOf('.') == -1) 
                    {
                        mz_rezultata = rez.Length - 1;
                    }
                    else
                    {
                        mz_rezultata = rez.IndexOf('.');
                        rez = rez.Replace(".", string.Empty);
                    }
                    StringBuilder sb = new StringBuilder(rez);
                    sb.Insert(mz_rezultata + ukupno, ".");
                    rez = sb.ToString();
                    rez = rez.TrimStart('0');
                    if (rez[0] == 46) rez = "0" + rez;
                    return rez;
                    
                }
                else if (do_kraja1 > do_kraja2)
                {
                    ukupno = do_kraja1 - do_kraja2;
                    string rez = new VelikiBroj(pom1) / new VelikiBroj(pom2);
                    int mz_rezultata = rez.IndexOf('.');
                    rez = rez.Replace(".", string.Empty);
                    StringBuilder sb = new StringBuilder(rez);
                    sb.Insert(mz_rezultata - ukupno, ".");
                    rez = sb.ToString();
                    rez = rez.TrimStart('0');
                    return rez;
                }
                else
                {
                    string rez = new VelikiBroj(pom1) / new VelikiBroj(pom2);
                    return rez;
                }
                
            }
            if(a.Decimalan() && !b.Decimalan())
            {
                int mz1 = a.MestoZareza();
                string pom1 = a.broj.Replace(".", string.Empty);
                ukupno = pom1.Length - mz1;
                string pom = b.broj;
                pom = pom + ".";
                return a / new VelikiBroj(pom);
            }
            else
            {
                string pom = a.broj;
                pom = pom + ".";
                return new VelikiBroj(pom) / b;
            }
            
            
        }
            
    }
}
