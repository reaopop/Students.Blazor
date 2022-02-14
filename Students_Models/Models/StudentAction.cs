using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students_UseCase.Models
{
    [Serializable, XmlRoot("StudentAction")]

    public class StudentAction
    {
        public int ID { get; set; }
        public int ActionType { get; set; }
    }
    [Serializable, XmlRoot("XMLStudent")]
    public class XMLAction
    {
        public List<StudentAction> studentAction { get; set; }


    }
    public enum ActionType
    {
        Add = 1,
        Update,
        Delete
    }
}
