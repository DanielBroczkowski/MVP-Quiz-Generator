using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region inferfejsu
        public string pytanie
        {
            get
            {
                return textBoxQuestion.Text;
            }
            set
            {
                textBoxQuestion.Text = value;
            }
        }
        
        public string odp1
        {
            get
            {
                return textBoxA.Text;
            }
            set
            {
                textBoxA.Text = value;
            }
        }
        public string odp2
        {
            get
            {
                return textBoxB.Text;
            }
            set
            {
                textBoxB.Text = value;
            }
        }
        public string odp3
        {
            get
            {
                return textBoxC.Text;
            }
            set
            {
                textBoxC.Text = value;
            }
        }
        public string odp4
        {
            get
            {
                return textBoxD.Text;
            }
            set
            {
                textBoxD.Text = value;
            }
        }     

        public decimal num1
        {
            get
            {
                return numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value=value;
            }
        }
        public decimal num2
        {
            get
            {
                return numericUpDown2.Value;
            }
            set
            {
                numericUpDown2.Value = value;
            }
        }
        public decimal num3
        {
            get
            {
                return numericUpDown3.Value;
            }
            set
            {
                numericUpDown3.Value = value;
            }
        }
        public decimal num4
        {
            get
            {
                return numericUpDown4.Value;
            }
            set
            {
                numericUpDown4.Value = value;
            }
        }
        
        public decimal time
        {
            get
            {
                return numeric_time.Value;
            }
            set
            {
                numeric_time.Value = value;
            }
        }

        public string list
        {
            get
            {

                return listBoxQuestions.SelectedItem.ToString();

            }
            set
            {
                listBoxQuestions.Items.Add(value);
            }
        }

        public string nazwa
        {
            set
            {
                label9.Text = value;
            }
        }
        public string sciezka
        {
            get
            {
                return textBoxPath.Text;
            }
            set
            {
                textBoxPath.Text = value;
            }
        }
        #endregion
        public event Action Add;
        public event Action Exit;
        public event Action PathEdit;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((textBoxA.Text != "" && textBoxB.Text != "") && (textBoxC.Text != "" && textBoxC.Visible==true || textBoxC.Visible == false)  && (textBoxD.Text != "" && textBoxD.Visible==true || textBoxD.Visible==false)  && textBoxQuestion.Text!= "" )
            {
                if (numericUpDown1.Value <= 0 && numericUpDown2.Value <= 0 && numericUpDown3.Value <= 0 &&  numericUpDown4.Value <= 0)
                {
                    MessageBox.Show("Przynajmniej 1 odpowiedź musi być punktowana dodatnio");
                }
                else
                {
                    Add?.Invoke();
                    numericUpDown1.Value = 1;
                }
            } 
            else
            {
                MessageBox.Show("Wypełnij puste pola!");
            }
        }

        private void add_answerC_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBoxC.Visible = true;
            numericUpDown3.Visible = true;
            add_answerD.Visible = true;
            remove_answerC.Visible = true;
            add_answerC.Visible = false;
        }

        private void add_answerD_Click(object sender, EventArgs e)
        {
            add_answerD.Visible = false;
            remove_answerC.Visible = false;
            remove_answerD.Visible = true;
            label2.Visible = true;
            textBoxD.Visible = true;
            numericUpDown4.Visible = true;
        }

        private void remove_answerD_Click(object sender, EventArgs e)
        {
            if (textBoxC.Text == "" && textBoxD.Text != "")
            {
                textBoxC.Text = textBoxD.Text;
            }
            label2.Visible = false;
            textBoxD.Visible = false;
            remove_answerD.Visible = false;
            remove_answerC.Visible = true;
            numericUpDown4.Visible = false;
            add_answerD.Visible = true;
            textBoxD.Text = "";
            numericUpDown4.Value = 0;
        }

        private void remove_answerC_Click(object sender, EventArgs e)
        {
            if (textBoxB.Text == "" && textBoxC.Text != "")
            {
                textBoxB.Text = textBoxC.Text;
            }
            remove_answerC.Visible = false;
            add_answerD.Visible = false;
            add_answerC.Visible = true;
            label3.Visible = false;
            textBoxC.Visible = false;
            numericUpDown3.Visible = false;
            textBoxC.Text = "";
            numericUpDown3.Value = 0;
        }

        private void End_creator(object sender, EventArgs e)
        {
            label9.Visible = true;
            label10.Visible = true;
            listBoxQuestions.Items.Clear();
            Exit?.Invoke();
            numericUpDown1.Value = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Int16.Parse( listBoxQuestions.SelectedIndex.ToString());
            listBoxQuestions.Items.Remove(listBoxQuestions.SelectedItem);
            try
            {
                listBoxQuestions.SelectedIndex = i;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                try
                {
                    listBoxQuestions.SelectedIndex = i-1;
                }
                catch(System.ArgumentOutOfRangeException)
                {

                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            PathEdit();
        }
    }
}
