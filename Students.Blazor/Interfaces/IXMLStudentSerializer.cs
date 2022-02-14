using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Students_UseCase.Models;

namespace Students.Blazor.Interfaces
{
    interface IXMLStudentSerializer
    {
        private static BindingList<StudentAction> _ActionXML;
        public static BindingList<StudentAction> ActionXML { get; set; }
        public string connection { get; }
        bool CreateAction(int ID, int ActionType);

    }
}
