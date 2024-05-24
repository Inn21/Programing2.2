using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Module3;

//Зчитує дані з файлу employees.xml. Файл містить список співробітників у форматі XML, де кожен співробітник має такі властивості: Name, Position, HireDate.
//Сортує співробітників за датою прийому на роботу (від найстаріших до найновіших) за допомогою LINQ.
//Зберігає відсортований список співробітників у новий XML файл sorted_employees.xml.
//Записує інформацію про співробітників в текстовий файл employees.txt у наступному форматі:

class Program
{
    static void Main()
    {
        
        //XDocument xmlDoc = XDocument.Load("C:\\Users\\User\\source\\repos\\C#\\Programing2.2\\Module3\\employees.xml");
        XDocument xmlDoc = XDocument.Load("employees.xml");

        //---Реалізація через використання методів---
        //---Реалізація через використання методів---

        /*
        var sortedEmployees =   xmlDoc.Root.Elements("Employee")
                                .Select(e => new Employee()
                                {
                                    Name = e.Element("Name").Value,
                                    Position = e.Element("Position").Value,
                                    HireDate = DateTime.Parse(e.Element("HireDate").Value)
                                })
                                .OrderBy(e => e.HireDate)
                                .ToList();
        */

        //---Реалізація через запит---

        var sortedEmployees = from e in xmlDoc.Root.Elements("Employee")
                              orderby DateTime.Parse(e.Element("HireDate").Value)
                              select new Employee()
                              {
                                  Name = e.Element("Name").Value,
                                  Position = e.Element("Position").Value,
                                  HireDate = DateTime.Parse(e.Element("HireDate").Value)
                              };

        


        XDocument sortedXmlDoc = new XDocument(
            new XElement("Employees",
                sortedEmployees.Select(e =>
                    new XElement("Employee",
                        new XElement("Name", e.Name),
                        new XElement("Position", e.Position),
                        new XElement("HireDate", e.HireDate.ToString("yyyy-MM-dd"))
                    )
                )
            )
        );
        sortedXmlDoc.Save("sorted_employees.xml");



        using (StreamWriter writer = new StreamWriter("employees.txt"))
        {
            foreach (var employee in sortedEmployees)
            {
                writer.WriteLine(employee.ToString());
                Console.WriteLine(employee.ToString());
            }
        }

    }
}