using System.Xml;

namespace XML;

class Program
{
    static void Main(string[] args)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        
        // getting root element
        XmlElement xRoot = xDoc.DocumentElement;
        if (xRoot != null)
        {
            foreach (XmlElement xNode in xRoot)
            {
                XmlNode? attr = xNode.Attributes.GetNamedItem("name");
                Console.WriteLine(attr?.Value);

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    if(childNode.Name == "company")
                        Console.WriteLine($"Company: {childNode.InnerText}");
                    if (childNode.Name == "age")
                        Console.WriteLine($"Age: {childNode.InnerText}");
                }
                Console.WriteLine();
            }
        }
    }
}