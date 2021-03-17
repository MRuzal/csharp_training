using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
            return Firstname == other.Firstname;
        }

        public int CompareTo(ContactData other)
        {

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int result = Lastname.CompareTo(other.Lastname);
            {
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return Firstname.CompareTo(other.Firstname);
                }

        }   }


        public override int GetHashCode()
        {
          return Firstname.GetHashCode();
        }


        public override string ToString()
        {
            return "firstname = " + Firstname
                  + "\nlastname = " + Lastname;
        }
       

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

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
                    return (CleanUP(Email) + CleanUP(Email2) + CleanUP(Email3)).Trim();

                }
            }
            set
            {
                allEmails = value;
            }

        }




        public string AllPhones
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return  (CleanUP(HomePhone) + CleanUP(MobilePhone) + CleanUP(WorkPhone)).Trim();

                }
            }
            set
            {
                allPhones = value;
            }

        }

        private string CleanUP(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}

