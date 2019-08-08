using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using WCF_Project_Client_Powers.ServiceReference1;

namespace WCF_Project_Client_Powers
{
    public partial class Form1 : Form
    {
        StudentServiceClient proxy = new StudentServiceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetStudent_Click(object sender, EventArgs e)
        {
            int studentID;
            int.TryParse(txtStudentID.Text, out studentID);

            Student student = proxy.GetStudentByID(studentID);
            if (student != null)
            {
                richTextBox1.Clear();
                richTextBox1.Text = string.Format("First name: {0}\nLastName: {1}\nID: {2}\nScores: {3}",
                    student.First, student.Last, student.ID, displayScores(student));
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.Text = "Invalid student ID";
            }
        }

        private string displayScores(Student students)
        {
            string scores = "";
            foreach(int score in students.Scores)
            {
               scores += score.ToString() + " ";
            }
            return scores;
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            string firstName = txtFName.Text;
            string lastName = txtLName.Text;
            int ID;
            int.TryParse(txtID.Text, out ID);
            int score1;
            int.TryParse(txtScore1.Text, out score1);
            int score2;
            int.TryParse(txtScore2.Text, out score2);
            int score3;
            int.TryParse(txtScore3.Text, out score3);
            proxy.AddNewStudent(firstName, lastName, ID, new int[] { score1, score2, score3 });
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            int grade;
            int.TryParse(txtGrade.Text, out grade);
            int ID;
            int.TryParse(txtAddGradeStudentID.Text, out ID);
            proxy.AddGrade(grade, ID);
        }

        private void btnBelowAverage_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach(Student student in proxy.BelowAverage())
            {
                richTextBox1.AppendText(string.Format("First name: {0}\nLastName: {1}\nID: {2}\nScores: {3}",
                    student.First, student.Last, student.ID, displayScores(student)));
            }
        }
    }
}
