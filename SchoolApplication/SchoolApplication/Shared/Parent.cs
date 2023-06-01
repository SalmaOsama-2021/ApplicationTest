using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Shared
{
    public class Parent :Default
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public int Phone1 { get; set; }
        public int WorkPhone { get; set; }
        public int HomePhone { get; set; }
        public int Sibilings { get; set; }
   
    }
}
