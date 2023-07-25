using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_ConsoleApp1.Models
{
    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string StudentName { get; set; }
        public virtual string Reg { get; set; }
        public virtual string Class { get; set; }
        public virtual string Section { get; set; }
    }
}
