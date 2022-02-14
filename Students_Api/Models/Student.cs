using System;
using System.Collections.Generic;

#nullable disable

namespace Students_Api.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public double Age { get; set; }
        public string City { get; set; }
        public string Genderd { get; set; }
    }
}
