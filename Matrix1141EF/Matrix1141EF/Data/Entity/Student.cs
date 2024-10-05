using Microsoft.VisualBasic;
using System;

namespace Matrix1141EF.Data.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public DateTime BirthDate{ get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
