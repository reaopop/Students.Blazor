using Students.Blazor.Interfaces;
using Students_UseCase.Models;
using Students_UseCase.Serviecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students.Blazor.Services
{

    public class XMLStudentSerializer : IXMLStudentSerializer
    {
        #region Properties
        public string connection { get => (Session.XMLPath + "UserAccess.xml"); }
        private static BindingList<StudentAction> _ActionXML;
        public static BindingList<StudentAction> ActionXML
        {
            get
            {
                if (_ActionXML == null)
                {
                    _ActionXML = new BindingList<StudentAction>(new XMLStudentSerializer().ReadStudent());
                }
                return _ActionXML;
            }
            set { _ActionXML = value; }
        }
        #endregion

        #region Constractor
        public XMLStudentSerializer()
        {

        }
        #endregion

        #region Helper
        bool PostData()
        {
            try
            {
                XMLAction xml = new XMLAction() { studentAction = ActionXML.ToList() };
                XmlSerializer serializer = new XmlSerializer(typeof(XMLAction));
                TextWriter writer = new StreamWriter(connection, false, Encoding.UTF8);
                XMLAction po = xml;

                serializer.Serialize(writer, po);
                writer.Flush
                    ();
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateAction(int Id, int actionType)
        {
            ActionXML.Add(new StudentAction() { ID = Id, ActionType = actionType });
            return PostData();
        }

        public List<StudentAction> ReadStudent()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLAction));
            FileStream fs = new FileStream(connection, FileMode.Open);
            XMLAction dezerializedList = (XMLAction)serializer.Deserialize(fs);
            return dezerializedList.studentAction;
        }
        #endregion


    }
}
