using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.ComponentModel;

namespace Flammenwerfer
{
    class XML_Creator
    {
        public void FileTest()
        {
            XmlTextWriter xWriter = new XmlTextWriter("xDoc1.xml", Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.WriteStartElement("Students");
            xWriter.WriteStartElement("Student");
            xWriter.WriteStartElement("NAME");
            xWriter.WriteString("John");
            xWriter.WriteEndElement();
            xWriter.WriteEndElement();
            xWriter.WriteEndElement();
            xWriter.Close();
            
        }
    }
}
