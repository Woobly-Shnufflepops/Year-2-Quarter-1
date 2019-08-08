using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Project_Library_Powers
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        Student GetStudentByID(int ID);
        [OperationContract]
        bool AddNewStudent(string firstName, string lastName, int ID, List<int> scores);
        [OperationContract]
        bool AddGrade(int grade, int ID);
        [OperationContract]
        Student[] BelowAverage();
    }
}
