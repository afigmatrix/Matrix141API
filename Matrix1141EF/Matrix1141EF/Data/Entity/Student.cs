﻿using Microsoft.VisualBasic;
using System;

namespace Matrix1141EF.Data.Entity
{
    public class Student :  BaseEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public DateTime BirthDate{ get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
