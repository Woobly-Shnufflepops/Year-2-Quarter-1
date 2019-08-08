using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace AccountsServiceLibrary
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int AccountNumber { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public string Bank { get; set; }
    }
}
