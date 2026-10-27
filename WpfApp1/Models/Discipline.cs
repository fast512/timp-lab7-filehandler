using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class Discipline
    {
        public string TeacherLogin { get; set; } = "";
        public string Name { get; set; } = "";
        public string Group { get; set; } = "";

        public string Display => $"{Name} ({Group})";




    }
}
