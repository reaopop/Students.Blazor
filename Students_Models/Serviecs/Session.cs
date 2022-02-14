using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Students_UseCase.Serviecs
{
    public static class Session
    {
        // but url here >>>  Example : https://192.168.1.5000
        public static string UrlString { get => "http://localhost:5000/"; }

        // xml file path
        public static string XMLPath { get => (Directory.GetCurrentDirectory() + "XMLFiles/LocalStudentActions.xml"); }
    }
}
