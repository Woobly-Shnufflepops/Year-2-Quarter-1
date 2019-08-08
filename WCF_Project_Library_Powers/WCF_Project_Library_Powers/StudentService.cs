using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Project_Library_Powers
{
    public class StudentService : IStudentService
    {
        public Student GetStudentByID(int ID)
        {
            Student student = StudentDatabase.students.Find(s => s.ID == ID);
            return student;
        }
        public bool AddNewStudent(string fName, string lName, int ID, List<int> scores)
        {
            Student newStudent = new Student { First = fName, Last = lName, ID = ID, Scores = new List<int>(scores)};
            if (IDExists(ID)) return false;
            else
            {
                StudentDatabase.students.Add(newStudent);
                return true;
            }
        }

        public bool IDExists(int ID)
        {
            foreach(Student student in StudentDatabase.students)
            {
                if (student.ID == ID) return true;
            }
            return false;
        }

        public bool AddGrade(int grade, int ID)
        {
            Student student = StudentDatabase.students.Find(s => s.ID == ID);
            if (student == null) return false;
            else
            {
                student.Scores.Add(grade);
                return true;
            }
        }
        public Student[] BelowAverage()
        {
            List<Student> belowAverageStudentList = new List<Student>();
            List<double> average = new List<double>();
            foreach(Student student in StudentDatabase.students)
            {
                average.Add(student.Scores.Average());
            }
            foreach(Student studentScore in StudentDatabase.students)
            {
                if(studentScore.Scores.Average() < average.Average())
                {
                    belowAverageStudentList.Add(studentScore);
                }
            }
            Student[] belowAverageStudentArray = belowAverageStudentList.ToArray();
            return belowAverageStudentArray;
        }
    }
}
