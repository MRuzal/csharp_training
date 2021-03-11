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



        public int GetHashCode()
        {
          return firstname.GetHashCode();
        }

        public int GetHashCode1()
        {
          return lastname.GetHashCode();
        }

        public string ToString()
        {
          return firstname;
        }

        public string ToString1()
        {
          return lastname;
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

