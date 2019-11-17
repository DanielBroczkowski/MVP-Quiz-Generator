using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    public class Questions  //class describing single question
    {
        public string index;
        public string question;
        public string ansA;
        public string ansB;
        public string ansC;
        public string ansD;
        public string time;
        public string valA;
        public string valB;
        public string valC;
        public string valD;

        public Questions() { }
        public Questions(string index, string question, string ansA, string ansB, string ansC, string ansD, string valA, string valB, string valC, string valD, string time)
        {
            this.index = index;
            this.question = question;
            this.ansA = ansA;
            this.ansB = ansB;
            this.ansC = ansC;
            this.ansD = ansD;
            this.valA = valA;
            this.valB = valB;
            this.valC = valC;
            this.valD = valD;
            this.time = time;
        }
        public override string ToString()
        {
            return index + " " + question + " " +  ansA + " " +  ansB + " " +  ansC + " " + ansD + " " + valA + " " + valB + " " + valC + " " + valD + " " + time;
        }
    }
}
