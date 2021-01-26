using System;
using System.IO;

namespace Paskaita10uzduotis1
{
    class Program
    {
        const string CFd = "..\\..\\..\\Duomenys.txt";
        const string CFr = "..\\..\\..\\Rezultatai1.txt";
        static void Main(string[] args)
        {
            CandidatesContainer ListOfCandidates = new CandidatesContainer();

            ReadData(CFd, ListOfCandidates);

            if (File.Exists(CFr))
                File.Delete(CFr);

            PrintCandidatesTable(CFr, "Pradinis kandidatų sąrašas", ListOfCandidates);
            ListOfCandidates.Sort();
            PrintCandidatesTable(CFr, "Rikiuoti duomenys", ListOfCandidates);
        }
        static void ReadData(string file, CandidatesContainer Candid)
        {
            if (File.Exists(file))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts;
                        parts = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        string nameSurname = parts[0].Trim();
                        int mindBattles = int.Parse(parts[1]);
                        int answere = int.Parse(parts[2]);
                        int time = int.Parse(parts[3]);

                        Candidate newCandid = new Candidate(nameSurname, mindBattles, answere, time);
                        Candid.AddCandidate(newCandid);
                    }
                }
            }
        }
        static void PrintCandidatesTable(string file, string tableName, CandidatesContainer Candid)
        {
            using (var fr = File.AppendText(file))
            {
                fr.WriteLine(tableName);
                if (Candid.n > 0)
                {
                    string tableHead = new string('-', 87) + '\n' +
                         String.Format("{0,-20} {1,20} {2,20} {3,22}", "Vardas ir pavardė", "Prieš tai dalyvavęs", "Teisingi atsakymai", "Sugaištas laikas (sek.)") + '\n' +
                         new string('-', 87);
                    fr.WriteLine(tableHead);
                    for (int i = 0; i < Candid.n; i++)
                    {
                        fr.WriteLine(Candid.CandidatesArray[i].ToString());
                    }
                    fr.WriteLine(new string('-', 87));
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias");
                }
                fr.WriteLine();
            }
        }
    }
}
