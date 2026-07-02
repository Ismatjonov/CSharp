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
                
                // ---- Working with class and structs ----
                var people = new List<Person>();
                
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");

                XmlElement? xmlRoot = xmlDoc.DocumentElement;
                if (xmlRoot is not null)
                {
                    foreach (XmlElement xmlNode in xmlRoot)
                    {
                        Person? person = new Person();
                        XmlNode? att = xmlNode.Attributes.GetNamedItem("name");
                        person.Name = att?.Value;

                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == "company")
                                person.Company = childNode.InnerText;
                            if (childNode.Name == "age")
                                person.Age = int.Parse(childNode.InnerText);
                        }
                        people.Add(person);
                    }
                    foreach(Person person in people)
                        Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
                }
            }
        }
    }
}
class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Company { get; set; }
}