using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace Tehtava_3a
{
    public class BLLogin
    {
        List<User> users = new List<User>();
        public BLLogin()
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + "XML\\users.xml";
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(User), new XmlRootAttribute("ArrayOfUsers"));
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                //j = (List<wine>)reader.Deserialize(file);
                users = (List<User>)reader.Deserialize(file);
                file.Close();
            }
            catch
            {

            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}