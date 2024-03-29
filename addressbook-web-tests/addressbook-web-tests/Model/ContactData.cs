﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;


namespace WebAddressbookTests 
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData> , IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
        }

        public ContactData(string lastname, string firstname, string address)
        {
            Lastname = lastname;
            Firstname = firstname;
            Address = address;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone, true) + CleanUp(MobilePhone, true) + CleanUp(WorkPhone, true)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email, false) + CleanUp(Email2, false) + CleanUp(Email3, false)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string data, bool isPhone)
        {
            if (data == null || data == "")
            {
                return "";
            }
            else
            {
                if (isPhone == true)
                {
                    return Regex.Replace(data, "[ ()-]", "") + "\r\n";
                }
                return data + "\r\n";
            }
        }

        public string AllPhonesForBagde
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (PhoheForBadge(HomePhone, 1) + "\r\n" + PhoheForBadge(MobilePhone, 2) + "\r\n" + PhoheForBadge(WorkPhone, 3)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string PhoheForBadge(string data, int phoneType)
        {
            if (data == null || data == "")
            {
                return "";
            }
            else
            {
                if (phoneType == 1)
                {
                    return "H: " + data;
                } 
                else if (phoneType == 2)
                {
                    return "M: " + data;
                }
                else if (phoneType == 3)
                {
                    return "W: " + data;
                }
                return data + "\r\n";
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this.Firstname, other.Firstname))
            {
                if (Object.ReferenceEquals(this.Lastname, other.Lastname))
                {
                    if (Object.ReferenceEquals(this.Address, other.Address))
                    {
                        return true;
                    }
                    return Address == other.Address;
                }
                return Lastname == other.Lastname;
            }
            return Firstname == other.Firstname;               
        }

        //тест AddingContactToGroupTest() валится на этом методе
        //public override int GetHashCode()
        //{
        //    return Firstname.GetHashCode() + Middlename.GetHashCode() + Lastname.GetHashCode() + Address.GetHashCode();
        //}

        public override string ToString()
        {
            return "name=" + Firstname + "\nmiddlename=" + Middlename + "\nlastname=" + Lastname + "\naddress=" + Address;
        }

        public int CompareTo(ContactData other)
        {
            if (other is null)
            {
                return 1;
            }             
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
