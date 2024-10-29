using System.Collections;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students{ get; set; }

    }
}
