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
        public long Phone { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int Age { get; set; }

        public User()
        {
            Email = string.Empty;
            Password = string.Empty;
            Phone = 0;
            City = string.Empty;
            Age = 0;
        }


    }
}
