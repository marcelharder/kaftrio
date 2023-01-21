using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;

namespace api.DAL.data
{
    public class Dropdownlists
    {

        XDocument doc = XDocument.Load("DAL/dropdownlists.xml");


        public List<Class_Item> getReasonForUse()
        {
            var help = new List<Class_Item>();
            Class_Item cl;

            help.Clear();
            var selected_element = doc.Descendants("Indication");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {

                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getTypeSupport()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("TypeOfSupport");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getCannulationSite()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("CannulationSite");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }

        public List<Class_Item> getWeight()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            for (int x = 30; x < 180; x++)
            {
                cl = new Class_Item();
                cl.value = x;
                cl.description = x.ToString();
                help.Add(cl);
            }
            return help;
        }

        public List<Class_Item> getHeight()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            for (int x = 150; x < 220; x++)
            {
                cl = new Class_Item();
                cl.value = x;
                cl.description = x.ToString();
                help.Add(cl);
            }
            return help;
        }

        public List<Class_Item> getAge()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            for (int x = 1; x < 90; x++)
            {
                cl = new Class_Item();
                cl.value = x;
                cl.description = x.ToString();
                help.Add(cl);
            }
            return help;
        }

        public List<Class_Item> getGender()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("Gender");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getYN()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("YN");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getReasonDiscontinuing()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("ReasonDiscontinuing");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getReasonDeadOnECLS()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("ReasonDeadOnECLS");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getCannulaSiteRepair()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("CannulaSiteRepair");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getDischargeLocation()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("DischargeLocation");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getVenousSizes()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("Venous_Sizes");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getVVSizes()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("VV_Sizes");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getArterialSizes()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("Arterial_Sizes");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getArterialLength()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("Arterial_Length");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getVenousLength()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("Venous_Length");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getLLDPLength()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("LLDP_Length");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        public List<Class_Item> getLLDPDiameter()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            help.Clear();
            var selected_element = doc.Descendants("LLDP_Diam");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {
                cl = new Class_Item();
                cl.value = (int)x.Element("value");
                cl.description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
       

        public List<Class_Item> getHours()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            for (int x = 0; x < 24; x++)
            {
                cl = new Class_Item();
                cl.value = x;
                cl.description = x.ToString();
                help.Add(cl);
            }
            return help;

        }
        public List<Class_Item> getMinutes()
        {
            var help = new List<Class_Item>();
            Class_Item cl;
            for (int x = 0; x < 60; x++)
            {
                cl = new Class_Item();
                cl.value = x;
                cl.description = x.ToString();
                help.Add(cl);
            }
            return help;

        }





    }
}
