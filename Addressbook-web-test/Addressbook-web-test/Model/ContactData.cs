using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>
    {
        private string firstname = "";
        private string lastname = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return firstname == other.firstname;
        }

        public int CompareTo(ContactData other)
        {
            lastname.CompareTo(other.Lastname);

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            else 
            {
                firstname.CompareTo(other.Firstname);
            }
            return 0;

        }


        public override int GetHashCode()
        {
          return firstname.GetHashCode();
        }


        public override string ToString()
        {
            return "firstname = " + Firstname
                  + "\nlastname = " + Lastname;
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
    }
}

