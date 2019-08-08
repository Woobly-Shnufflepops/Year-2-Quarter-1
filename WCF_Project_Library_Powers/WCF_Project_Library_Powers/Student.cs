using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCF_Project_Library_Powers
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string First { get; set; }
        [DataMember]
        public string Last { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public List<int> Scores;
    }

    
}
