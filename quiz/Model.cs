using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace quiz
{
    class Model
    {
        public int index = 1, i = 0;
        public List<Questions> listOfQuestions = new List<Questions>();
        string path = "d:\\";

        public void Add_new(string question, string ansA, string ansB, string ansC, string ansD, decimal valA, decimal valB, decimal valC, decimal valD, decimal time)
        { 
            listOfQuestions.Add(new Questions (index.ToString(),  question,  ansA,  ansB,  ansC,  ansD,  valA.ToString(),  valB.ToString(),  valC.ToString(),  valD.ToString(),  time.ToString()));
  
            index++;
        }
        public string nazwa() 
        {                     
            string name;      
            if (listOfQuestions.Any())
            {
                if (i == 0)
                {
                    name = "/pytanie.xml";
                }
                else
                {
                    name = "/pytanie(" + i + ").xml";
                }
            }
            else name = "Błąd - pusta lista";
            return name;
        }
        public string Path() //Change a path
        { 
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                //dlg.Description = "Select a folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.SelectedPath;
                    //Console.WriteLine(path);
                }
            }
            return path;
        }
        public void EndGenerator()
        {
            if (listOfQuestions.Any())
            {
                WriteXML(listOfQuestions); //Serializing the question
                listOfQuestions.Clear(); //Clearing a list after save
                index = 1;
            }
        }
        public void WriteXML(List<Questions> listOfQuestions) //class serializing single question
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Questions>));

            var filepath = path + nazwa();
            Console.WriteLine(filepath);
            System.IO.FileStream file = System.IO.File.Create(filepath);
            writer.Serialize(file, listOfQuestions);
            file.Close();
            i++;
        }
        public string Add_To_ListBox(string question)
        {
            return (index - 1).ToString() + " " + question;
        }
        public string clear(string text) //Clear textboxes
        {
            return "";
        }
        public decimal clear_num(decimal num) //Clear numeric updown
        {
            return 0;
        }
    }
}
