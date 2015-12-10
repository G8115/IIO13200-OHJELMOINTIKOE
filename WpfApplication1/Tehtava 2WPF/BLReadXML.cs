using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava_2WPF
{
    class BLReadXML
    {
        public string path;
        public CountryData countries;
        public bool ERROR = false;
        public BLReadXML()
        {
            path = ConfigurationManager.AppSettings["fileLocation"] + "\\" + ConfigurationManager.AppSettings["fileName"];
            countries = readData();
            if (!ERROR)
            {
                foreach (Country s in countries.Countries)
                {
                    int index = s.SurfaceArea.IndexOf('.');
                    s.SurfaceArea = s.SurfaceArea.Remove(index);
                }
            }
        }

        public CountryData readData()
        {
            CountryData data = null;
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(CountryData), new XmlRootAttribute("DATA"));
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                //j = (List<wine>)reader.Deserialize(file);
                data = (CountryData)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception)
            {

                ERROR = true;
            }

            return data;
        }
        public List<Country> getLikeName(string name)
        {
            return (List<Country>)countries.Countries.Where(p => p.Name.Contains(name)).ToList();
        }
        public List<Country> getTop10POP()
        {

            List<Country> temp = (List<Country>)countries.Countries.OrderByDescending(p => Int32.Parse(p.Population)).ToList();
            List<Country> temp1 = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                temp1.Add(temp.ElementAt(i));
            }
            return temp1;
        }

        public List<Country> getTop10AREA()
        {

            List<Country> temp = (List<Country>)countries.Countries.OrderByDescending(p => Int32.Parse(p.SurfaceArea)).ToList();
            List<Country> temp1 = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                temp1.Add(temp.ElementAt(i));
            }
            return temp1;
        }

    }

    [XmlTypeAttribute(AnonymousType = true)]
    public class CountryData
    {
        [XmlElement("ROW")]
        public List<Country> Countries { get; set; }

        public CountryData()
        {
            Countries = new List<Country>();
        }
    }
    public class Country
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Continent")]
        public string Continent { get; set; }

        [XmlElement(ElementName = "Population")]
        public string Population { get; set; }

        [XmlElement(ElementName = "LocalName")]
        public string LocalName { get; set; }

        [XmlElement(ElementName = "HeadOfState")]
        public string HeadOfState { get; set; }

        [XmlElement(ElementName = "SurfaceArea")]
        public string SurfaceArea { get; set; }
    }
}
