using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
    public class ContactData : IEquatable<ContactData> , IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string address;
        //private string nickname = "";
        //private string title = "";
        //private string company = "";
        //private string home = "";
        //private string mobile = "";
        //private string work = "";
        //private string fax = "";
        //private string email = "";
        //private string email2 = "";
        //private string email3 = "";
        //private string homepage = "";
        //private string address2 = "";
        //private string phone2 = "";
        //private string notes = "";

        public ContactData(string lastname, string firstname, string address)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.address = address;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
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
