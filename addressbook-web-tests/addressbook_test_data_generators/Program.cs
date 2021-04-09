using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.Out.Write("Hello, world!");
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string datatype = args[3];

            if (datatype == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }
            else if (datatype == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(50))
                    {
                        Middlename = TestBase.GenerateRandomString(30),
                        HomePhone = TestBase.GenerateRandomString(30),
                        MobilePhone = TestBase.GenerateRandomString(30),
                        WorkPhone = TestBase.GenerateRandomString(30),
                        Email = TestBase.GenerateRandomString(30),
                        Email2 = TestBase.GenerateRandomString(30),
                        Email3 = TestBase.GenerateRandomString(30)
                    });
                }
                if (format == "excel")
                {
                    //writeGroupsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized datatype" + datatype);
            }
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9}",
                    contact.Lastname, contact.Firstname, contact.Address, contact.Middlename, 
                    contact.HomePhone, contact.MobilePhone, contact.WorkPhone, 
                    contact.Email, contact.Email2, contact.Email3));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
