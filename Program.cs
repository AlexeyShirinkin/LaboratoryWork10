using System.Collections.Generic;
using System.Xml;

namespace LaboratoryWork10
{
    class Program
    {
        static void Main()
        {
            var xDoc = new XmlDocument();
            xDoc.Load("Data.xml");
            var xmlRoot = xDoc.DocumentElement;

            var maxWeight = 0;
            var subjects = new List<Subject>();

            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Name == "maxWeight")
                {
                    maxWeight = int.Parse(xmlNode.InnerText);
                    continue;
                }

                var subject = new Subject(0, 0);
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    if (childNode.Name == "cost")
                        subject.Cost = int.Parse(childNode.InnerText);
                    if (childNode.Name == "weight")
                        subject.Weight = int.Parse(childNode.InnerText);
                }
                subjects.Add(subject);
            }

            BackpackTask.Solve(subjects, maxWeight);
        }
    }
}
