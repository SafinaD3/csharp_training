using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
    public class ContactData : IEquatable<ContactData> , IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string lastname, string firstname, string address)
        {
            Lastname = lastname;
            Firstname = firstname;
            Address = address;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
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

        public string AllEmails { get; set; }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
        
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode() + Address.GetHashCode();
        }
        
        public override string ToString()
        {
            return "name=" + Firstname + Lastname + Address;
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
    }
}
