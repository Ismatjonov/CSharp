using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
        /*XDocument xDoc = new XDocument();
        
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
        
        Console.WriteLine("Data saved");*/
        
        // ---- More advanced ---
        /*XDocument xDoc = new XDocument(new XElement("people",
            new XElement("person",
                new XAttribute("name", "Adolf"),
                new XElement("company", "JetBrains"),
                new XElement("age", 19)),
            new XElement("person",
                new XAttribute("name", "Mark"),
                new XElement("company", "Facebook"),
                new XElement("age", 18))
            ));
        xDoc.Save(path);

        Console.WriteLine("Data saved");*/
        
        
        // ======================= Selection elements in LINQ to XML ====================
        /*XDocument xDoc = XDocument.Load(path);
        
        // getting rootNode
        XElement? people = xDoc.Element("people");
        if (people is not null)
        {
            // all elements
            foreach (XElement person in people.Elements("person"))
            {
                
                XAttribute? name = person.Attribute("name");
                XElement? company = person.Element("company");
                XElement? age = person.Element("age");

                Console.WriteLine($"Person: {name?.Value}");
                Console.WriteLine($"Company: {company?.Value}");
                Console.WriteLine($"Age: {age?.Value}");

                Console.WriteLine();
            }
        }*/
        
        // ------- Processing --------
        /*XDocument xDocument = XDocument.Load(path);
        
        var microsoft = xDocument.Element("people")?
            .Elements("person").Where(p => p.Element("company").Value == "Microsoft")
            .Select(p => new
            {
                name = p.Attribute("name")?.Value,
                company = p.Element("company")?.Value,
                age = p.Element("age")?.Value
            });

        if (microsoft is not null)
        {
            foreach(var person in microsoft)
                Console.WriteLine($"Name: {person.name}, Age: {person.age}");
        }

        var tom = xDocument.Element("people")   // getting root element people
            .Elements("person") // getting all elements person
            .FirstOrDefault(p => p.Attribute("name")?.Value == "Tom");
        
        var _name = tom?.Attribute("name")?.Value;
        var _age = tom?.Element("age")?.Value;
        var _company = tom?.Element("company")?.Value;

        Console.WriteLine($"Name: {_name}, Age: {_age}, Company: {_company}");*/
        
        
        
        // =============== Modifying document in LINQ to XML ===============
        
        // Adding data
        /*XDocument xdoc = XDocument.Load(path);
        XElement? root = xdoc.Element("people");

        if (root is not null)
        {
            root.Add(new XElement("person",
                new XAttribute("name", "Bob"),
                new XElement("company", "Jetbrains"),
                new XElement("age", 28)));
            
            xdoc.Save(path);
        }

        Console.WriteLine(xdoc);
        
        // Editing data
        var tom = xdoc.Element("people")
            .Elements("person")
            .FirstOrDefault(p => p.Attribute("name")?.Value == "Tom");

        if (tom is not null)
        {
            var name = tom.Attribute("name");
            if (name != null) name.Value = "Tomas";
            
            var age = tom.Element("age");
            if (age != null) age.Value = "22";
            
            xdoc.Save(path);
        }
        Console.WriteLine(xdoc);
        
        // Removing data
        if (root is not null)
        {
            var bob = root.Elements("person")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "Bob");

            if (bob != null)
            {
                bob.Remove();
                xdoc.Save(path);
            }
        }
        Console.WriteLine(xdoc);*/
        
        
        // =============== Serialization in XML. XmlSerializer ===============
        
        // ---- Serialization ----
        // object for serialization
        Person person = new Person("Tom", 37);
 
        // passing in constructor type Person
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
 
        // getting a stream, where we record serialized object
        using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, person);
 
            Console.WriteLine("Object has been serialized");
        }
        
        // ---- Deserialization ----
        using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
        {
            Person? deserializedPerson = xmlSerializer.Deserialize(fs) as Person;
            Console.WriteLine($"Name: {deserializedPerson?.Name}, Age: {deserializedPerson?.Age}");
        }
        
        // ------ Serialization and Deserialization of collection ------
        Person[] people =
        {
            new Person("Tom", 37),
            new Person("Bob", 41),
        };
        
        XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, people);
        }

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            Person[]? newPeople = formatter.Deserialize(fs) as Person[];

            if (newPeople is not null)
            {
                foreach(Person p in newPeople)
                    Console.WriteLine($"Name: {p?.Name} --- Age: {p?.Age}");
            }
        }
    }
}
//[Serializable]
public class Person
{
    public string Name { get; set; } = "Undefined";
    public int Age { get; set; } = 1;
 
    public Person() { }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}