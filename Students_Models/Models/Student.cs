using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

#nullable disable

namespace Students_UseCase.Models

{
    [Serializable, XmlRoot("Student")]

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
    [Serializable, XmlRoot("XMLStudent")]
    public class XMLStudent
    {
        public List<Student> students { get; set; }


    }
}
