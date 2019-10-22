using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.Models
{
  public  class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassromId { get; set; }
        public Classroom Classroom { get; set; }
        public List<Student> Students { get; set; }
    }
}

