using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace RegistrationForm
{
    [DataContract]
    class User
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int Age { get; set; }
        public bool SuccessAut = false;

        public User(string email,string password,string phone,string city,string age)
        {
            bool successAut = true;
            if(!CheckEmail(email)) successAut=false;
            Email = email;
            if (!CheckPassword(password)) successAut = false;
            else Password = password;
            if (!CheckPhone(phone)) successAut = false;
            else Phone = phone;
            City = city;
            if (!int.TryParse(age, out int resultAge)) successAut = false;
            else Age = resultAge;
            SuccessAut = successAut;
        }

        private bool CheckEmail(string email)
        {
            if (!email.Contains(".") && !email.Contains("@"))
                return false;
            else
                return true;
        }

        private bool CheckPhone(string phone)
        {
            foreach (var c in phone)
            {
                if (c < '0' || c > '9')
                    return false;
            }
                return true;
        }

        private bool CheckPassword(string password)
        {
            if (Password.Contains(" "))
                return false;
            else
            return true;
        }


    }
}
