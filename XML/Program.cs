using System.Xml;
using System.Xml.Linq;

namespace XML;

class Program
{
    static void Main(string[] args)
    {
        string path = "C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml";
        
        // XmlDocument xDoc = new XmlDocument();
        // xDoc.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        //
        // // getting root element
        // XmlElement xRoot = xDoc.DocumentElement;
        // if (xRoot != null)
        // {
        //     foreach (XmlElement xNode in xRoot)
        //     {
        //         XmlNode? attr = xNode.Attributes.GetNamedItem("name");
        //         Console.WriteLine(attr?.Value);
        //
        //         foreach (XmlNode childNode in xNode.ChildNodes)
        //         {
        //             if(childNode.Name == "company")
        //                 Console.WriteLine($"Company: {childNode.InnerText}");
        //             if (childNode.Name == "age")
        //                 Console.WriteLine($"Age: {childNode.InnerText}");
        //         }
        //         Console.WriteLine();
        //     }
        // }
        //
        // // ---- Working with class and structs ----
        // var people = new List<Person>();
        //         
        // XmlDocument xmlDoc = new XmlDocument();
        // xmlDoc.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        //
        // XmlElement? xmlRoot = xmlDoc.DocumentElement;
        // if (xmlRoot is not null)
        // {
        //     foreach (XmlElement xmlNode in xmlRoot)
        //     {
        //         Person? person = new Person();
        //         XmlNode? att = xmlNode.Attributes.GetNamedItem("name");
        //         person.Name = att?.Value;
        //
        //         foreach (XmlNode childNode in xmlNode.ChildNodes)
        //         {
        //             if (childNode.Name == "company")
        //                 person.Company = childNode.InnerText;
        //             if (childNode.Name == "age")
        //                 person.Age = int.Parse(childNode.InnerText);
        //         }
        //         people.Add(person);
        //     }
        //     foreach(Person person in people)
        //         Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
        // }
        //
        // // ===================== Modifying an XML Document =====================
        // /*XmlDocument xD = new XmlDocument();
        // xD.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        // XmlElement? xR = xD.DocumentElement;
        //
        // // creating a new element
        // XmlElement personElem = xD.CreateElement("person");
        //
        // // creating attribute name
        // XmlAttribute nameAttr = xD.CreateAttribute("name");
        //
        // // creating elements company and age
        // XmlElement companyElem = xD.CreateElement("company");
        // XmlElement ageElem = xD.CreateElement("age");
        //
        // // creating text values for elements and attributes
        // XmlText nameText = xD.CreateTextNode("Mark");
        // XmlText companyText = xD.CreateTextNode("Facebook");
        // XmlText ageText = xD.CreateTextNode("30");
        //
        // // adding nodes
        // nameAttr.AppendChild(nameText);
        // companyElem.AppendChild(companyText);
        // ageElem.AppendChild(ageText);
        //
        // // adding attribute name
        // personElem.Attributes.Append(nameAttr);
        //
        // // adding elements company and age
        // personElem.AppendChild(companyElem);
        // personElem.AppendChild(ageElem);
        //
        // // adding in root element new element person
        // xR?.AppendChild(personElem);
        //
        // // save edited document to the file
        // xD.Save("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        //
        // // ----- Removing nodes ------
        // XmlDocument xmlDocument = new XmlDocument();
        // xmlDocument.Load("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");
        // XmlElement? _xmlRoot = xmlDocument.DocumentElement;
        // XmlNode? firstNode = _xmlRoot.FirstChild;
        // if(firstNode is not null) _xmlRoot.RemoveChild(firstNode);
        // xmlDocument.Save("C:\\Users\\HOME\\RiderProjects\\CSharp\\XML\\people.xml");*/
        //
        // // ==================== XPath ==================== 
        // XmlDocument xmlDocument = new XmlDocument();
        // xmlDocument.Load(path);
        // XmlElement root = xmlDocument.DocumentElement;
        //
        // // select all child elements
        // XmlNodeList? nodes = root.SelectNodes("person");
        // XmlNodeList? companyNode = root.SelectNodes("person");
        // if (nodes is not null)
        // {
        //     foreach(XmlNode node in companyNode)
        //         Console.WriteLine(node.OuterXml);
        // }
        
        // ==================== LINQ to XML =====================
        XDocument xDoc = new XDocument();
        
        // creating first element person
        XElement tom = new XElement("person");
        
        // creating attribute name
        XAttribute tomNameAttr = new XAttribute("name", "Tom");
        
        // creating two elements: company & age
        XElement tomCompanyElem = new XElement("company", "Microsoft");
        XElement tomAgeElem = new XElement("age", 37);
        
        // adding an attribute and elements to the fist element of person
        tom.Add(tomNameAttr);
        tom.Add(tomCompanyElem);
        tom.Add(tomAgeElem);
        
        
        // create second element person
        XElement bob = new XElement("person");
        
        // creating attribute name
        XAttribute bobNameAttr = new XAttribute("name", "Bob");
        
        // creating elements: company & age
        XElement bobCompanyElem = new XElement("company", "Google");
        XElement bobAgeElem = new XElement("age", 41);
        
        // adding
        bob.Add(bobNameAttr);
        bob.Add(bobCompanyElem);
        bob.Add(bobAgeElem);
        
        // creating root element
        XElement people = new XElement("people");
        
        // adding two element person to the root element
        people.Add(tom);
        people.Add(bob);
        
        // adding root element to the document
        xDoc.Add(people);
        // save document
        xDoc.Save(path);
        
        Console.WriteLine("Data saved");
        
        
    }
}
class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Company { get; set; }
}