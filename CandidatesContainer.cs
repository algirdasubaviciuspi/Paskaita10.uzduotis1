using System;
using System.Collections.Generic;
using System.Text;

namespace Paskaita10uzduotis1
{
    class CandidatesContainer
    {
        const int Cmax = 10000;
        public int n { get; set; }
        public Candidate[] CandidatesArray { get; set; }
        public CandidatesContainer()
        {
            n = 0;
            CandidatesArray = new Candidate[Cmax];
        }
        public void AddCandidate(Candidate c)
        {
            if (n + 1 < Cmax)
                CandidatesArray[n++] = c;
        }
        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                int maxInd = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (CandidatesArray[j] > CandidatesArray[maxInd])
                        maxInd = j;
                }
                Candidate temp = CandidatesArray[maxInd];
                CandidatesArray[maxInd] = CandidatesArray[i];
                CandidatesArray[i] = temp;
            }
        }
    }
}
