using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace RegistrationForm
{
    class RegistrLogin
    {
        private List<User> existsUser;

        public void Registration()
        {
            existsUser = new List<User>();

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));

            if (File.Exists("./data.json"))
            {
                using (FileStream fs = new FileStream("./people.json", FileMode.Open))
                {
                    existsUser = (List<User>)jsonFormatter.ReadObject(fs);
                }
            }
        }

        public bool UserAuthorization(string email,string password)
        {
            foreach (User u in existsUser)
            {
                if (u.Email != email && u.Password != password)
                    return false;
            }
            return true;
        }

        public bool UserAuthentification(User user)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<User>));
            if(existsUser.Capacity!=0)
                foreach (User u in existsUser)
                {
                    if (u.Email == user.Email) return false;
                }

            existsUser.Add(user);
            using (FileStream fstream = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fstream, existsUser);
            }
            return true;
        }
       
    }
}
